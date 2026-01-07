using Medical.Models.RAG;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medical.Services.Interfaces
{
    public interface IRAGService
    {
        Task<FileSearchStore> CreateStoreAsync(string displayName);
        
        Task<List<FileSearchStore>> GetAllStoresAsync();
        Task<bool> DeleteStoreAsync(string storeId);

        Task<DocumentMetadata> UploadDocumentAsync(
            string filePath,
            string storeId,
            DocumentMetadata metadata = null);

        Task<List<DocumentMetadata>> GetDocumentsInStoreAsync(string storeId);

        Task<RAGResponse> QueryAsync(RAGQuery query);
    }
}
