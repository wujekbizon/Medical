using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Medical.Models.RAG;
using Medical.Services.Interfaces;

namespace Medical.Services
{
    public class GeminiRAGService : IRAGService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://generativelanguage.googleapis.com/v1beta";
        private readonly string _uploadBaseUrl = "https://generativelanguage.googleapis.com/upload/v1beta";
        private readonly RAGPromptService _promptService;
        public GeminiRAGService(string apiKey)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("x-goog-api-key", apiKey);
            _promptService = new RAGPromptService();
        }

        #region Store Management

        public async Task<FileSearchStore> CreateStoreAsync(string displayName)
        {
            try
            {
                var requestBody = new { displayName };
                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{_baseUrl}/fileSearchStores", content);
                response.EnsureSuccessStatusCode();

                var responseJson = await response.Content.ReadAsStringAsync();
                var result = JObject.Parse(responseJson);

                return new FileSearchStore
                {
                    StoreId = result["name"]?.ToString(),
                    DisplayName = displayName,
                    CreatedDate = DateTime.Now,
                    TotalDocuments = 0,
                    Status = "Active"
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create file search store: {ex.Message}", ex);
            }
        }

        public async Task<List<FileSearchStore>> GetAllStoresAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/fileSearchStores");
                response.EnsureSuccessStatusCode();

                var responseJson = await response.Content.ReadAsStringAsync();
                var result = JObject.Parse(responseJson);

                var stores = new List<FileSearchStore>();
                var storesArray = result["fileSearchStores"] as JArray;

                if (storesArray != null)
                {
                    foreach (var storeToken in storesArray)
                    {
                        var store = new FileSearchStore
                        {
                            StoreId = storeToken["name"]?.ToString(),
                            DisplayName = storeToken["displayName"]?.ToString(),
                            CreatedDate = DateTime.TryParse(storeToken["createTime"]?.ToString(), out var dt)
                                ? dt : DateTime.Now,
                            TotalDocuments = int.TryParse(storeToken["activeDocumentsCount"]?.ToString(), out var count)
                                ? count : 0,
                            Status = "Active"
                        };

                        stores.Add(store);
                    }
                }

                return stores;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve stores: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteStoreAsync(string storeId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync(
                    $"{_baseUrl}/{storeId}?force=true"
                );

                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete store: {ex.Message}", ex);
            }
        }

        #endregion

        #region Document Management

        public async Task<DocumentMetadata> UploadDocumentAsync(
            string filePath,
            string storeId,
            DocumentMetadata metadata = null)
        {
            try
            {
                if (!File.Exists(filePath))
                    throw new FileNotFoundException($"File not found: {filePath}");

                metadata = metadata ?? new DocumentMetadata
                {
                    FileName = Path.GetFileName(filePath),
                    FileType = Path.GetExtension(filePath),
                    IndexStatus = "Indexing"
                };

                var fileBytes = File.ReadAllBytes(filePath);
                var mimeType = GetMimeType(filePath);

                var initiateUrl = $"{_uploadBaseUrl}/{storeId}:uploadToFileSearchStore";

                var metadataBody = new { displayName = metadata.FileName };
                var metadataJson = JsonConvert.SerializeObject(metadataBody);

                var initiateRequest = new HttpRequestMessage(HttpMethod.Post, initiateUrl);
                initiateRequest.Headers.Add("X-Goog-Upload-Protocol", "resumable");
                initiateRequest.Headers.Add("X-Goog-Upload-Command", "start");
                initiateRequest.Headers.Add("X-Goog-Upload-Header-Content-Length", fileBytes.Length.ToString());
                initiateRequest.Headers.Add("X-Goog-Upload-Header-Content-Type", mimeType);
                initiateRequest.Content = new StringContent(metadataJson, Encoding.UTF8, "application/json");

                var initiateResponse = await _httpClient.SendAsync(initiateRequest);
                if (!initiateResponse.IsSuccessStatusCode)
                {
                    var error = await initiateResponse.Content.ReadAsStringAsync();
                    throw new Exception($"Upload initiation failed: {error}");
                }

                var uploadUrl = initiateResponse.Headers.GetValues("X-Goog-Upload-URL").FirstOrDefault();
                if (string.IsNullOrEmpty(uploadUrl))
                    throw new Exception("No upload URL in response headers");

                var uploadRequest = new HttpRequestMessage(HttpMethod.Post, uploadUrl);
                uploadRequest.Headers.Add("X-Goog-Upload-Offset", "0");
                uploadRequest.Headers.Add("X-Goog-Upload-Command", "upload, finalize");
                uploadRequest.Content = new ByteArrayContent(fileBytes);

                var uploadResponse = await _httpClient.SendAsync(uploadRequest);
                if (!uploadResponse.IsSuccessStatusCode)
                {
                    var error = await uploadResponse.Content.ReadAsStringAsync();
                    throw new Exception($"File upload failed: {error}");
                }

                var uploadJson = await uploadResponse.Content.ReadAsStringAsync();
                var uploadResult = JObject.Parse(uploadJson);
                var operationName = uploadResult["name"]?.ToString();

                if (string.IsNullOrEmpty(operationName))
                    throw new Exception($"No operation name in response");

                bool done = false;
                int attempt = 0;
                int maxAttempts = 60;

                while (!done && attempt < maxAttempts)
                {
                    await Task.Delay(5000);

                    var operationResponse = await _httpClient.GetAsync($"{_baseUrl}/{operationName}");
                    if (!operationResponse.IsSuccessStatusCode)
                    {
                        var error = await operationResponse.Content.ReadAsStringAsync();
                        throw new Exception($"Polling failed: {error}");
                    }

                    var operationJson = await operationResponse.Content.ReadAsStringAsync();
                    var operation = JObject.Parse(operationJson);

                    done = operation["done"]?.Value<bool>() ?? false;
                    attempt++;

                    if (done)
                    {
                        var error = operation["error"];
                        if (error != null)
                            throw new Exception($"Operation failed: {error}");
                    }
                }

                if (!done)
                    throw new TimeoutException("Indexing timed out after 5 minutes");

                metadata.DocumentId = operationName;
                metadata.IndexStatus = "Indexed";
                return metadata;
            }
            catch (Exception ex)
            {
                if (metadata != null)
                    metadata.IndexStatus = "Failed";
                throw new Exception($"Upload failed: {ex.Message}", ex);
            }
        }

        public async Task<List<DocumentMetadata>> GetDocumentsInStoreAsync(string storeId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/{storeId}/documents");
                response.EnsureSuccessStatusCode();

                var responseJson = await response.Content.ReadAsStringAsync();
                var result = JObject.Parse(responseJson);

                var documents = new List<DocumentMetadata>();
                var documentsArray = result["documents"] as JArray;

                if (documentsArray != null)
                {
                    foreach (var docToken in documentsArray)
                    {
                        var doc = new DocumentMetadata
                        {
                            DocumentId = docToken["name"]?.ToString(),
                            FileName = docToken["displayName"]?.ToString(),
                            FileType = docToken["mimeType"]?.ToString(),
                            IndexStatus = docToken["state"]?.ToString() == "STATE_ACTIVE" ? "Indexed" : "Pending",
                            UploadDate = DateTime.TryParse(docToken["createTime"]?.ToString(), out var dt)
                                ? dt : DateTime.Now
                        };

                        documents.Add(doc);
                    }
                }

                return documents;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve documents: {ex.Message}", ex);
            }
        }

        #endregion

        #region Query

        public async Task<RAGResponse> QueryAsync(RAGQuery query)
        {
            var stopwatch = Stopwatch.StartNew();

            try
            {
                var enhancedQuery = _promptService.EnhanceUserQuery(query.QueryText);

                var requestBody = new
                {
                    system_instruction = new
                    {
                        parts = new[]
                        {
                    new { text = _promptService.BuildSystemPrompt() }
                }
                    },

                    contents = new[]
                    {
                new
                {
                    parts = new[]
                    {
                        new { text = enhancedQuery }
                    }
                }
            },

                    tools = new[]
                    {
                new
                {
                    fileSearch = new
                    {
                        fileSearchStoreNames = new[] { query.StoreId }
                    }
                }
            }
                };

                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(
                    $"{_baseUrl}/models/gemini-2.5-flash:generateContent",
                    content
                );

                response.EnsureSuccessStatusCode();
                var responseJson = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine("=== FULL RESPONSE ===");
                System.Diagnostics.Debug.WriteLine(responseJson);
                System.Diagnostics.Debug.WriteLine("=== END RESPONSE ===");

                var result = JObject.Parse(responseJson);

                stopwatch.Stop();

                var ragResponse = new RAGResponse
                {
                    ProcessingTimeMs = (int)stopwatch.ElapsedMilliseconds,
                    QueryDate = DateTime.Now
                };

                var candidates = result["candidates"] as JArray;
                System.Diagnostics.Debug.WriteLine($"Candidates count: {candidates?.Count ?? 0}");

                if (candidates != null && candidates.Count > 0)
                {
                    var candidate = candidates[0];
                    var contentResult = candidate["content"];
                    var parts = contentResult["parts"] as JArray;

                    System.Diagnostics.Debug.WriteLine($"Parts count: {parts?.Count ?? 0}");

                    if (parts != null && parts.Count > 0)
                    {
                        var textParts = new List<string>();
                        foreach (var part in parts)
                        {
                            var text = part["text"]?.ToString();
                            System.Diagnostics.Debug.WriteLine($"Part text length: {text?.Length ?? 0}");
                            System.Diagnostics.Debug.WriteLine($"Part text: {text}");

                            if (!string.IsNullOrEmpty(text))
                                textParts.Add(text);
                        }
                        ragResponse.ResponseText = string.Join("\n\n", textParts);
                        System.Diagnostics.Debug.WriteLine($"Final ResponseText length: {ragResponse.ResponseText?.Length ?? 0}");
                    }

                    var groundingMetadata = candidate["groundingMetadata"];
                    if (groundingMetadata != null)
                    {
                        var groundingChunks = groundingMetadata["groundingChunks"] as JArray;
                        if (groundingChunks != null)
                        {
                            foreach (var chunk in groundingChunks)
                            {
                                var retrievedContext = chunk["retrievedContext"];
                                var citation = new Citation
                                {
                                    SourceDocument = retrievedContext?["title"]?.ToString() ?? "Unknown",
                                    Excerpt = retrievedContext?["text"]?.ToString()?.Substring(0,
                                        Math.Min(200, retrievedContext["text"].ToString().Length)) ?? ""
                                };
                                ragResponse.Citations.Add(citation);
                            }
                        }
                    }
                }

                return ragResponse;
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                throw new Exception($"Query failed: {ex.Message}", ex);
            }
        }

        #endregion

        #region Helper Methods

        private string GetMimeType(string filePath)
        {
            var extension = Path.GetExtension(filePath).ToLowerInvariant();

            switch (extension)
            {
                case ".txt":
                    return "text/plain";
                case ".md":
                    return "text/markdown";
                case ".pdf":
                    return "application/pdf";
                case ".doc":
                    return "application/msword";
                case ".docx":
                    return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                case ".json":
                    return "application/json";
                case ".html":
                    return "text/html";
                case ".csv":
                    return "text/csv";
                default:
                    return "application/octet-stream";
            }
        }

        #endregion
    }
}