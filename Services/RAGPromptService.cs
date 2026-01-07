using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Services
{
    public class RAGPromptService
    {
        public string BuildSystemPrompt()
        {
            return @"You are an AI assistant for medical emergency services called Medical.

                    YOUR KNOWLEDGE SOURCE:
                    - You have access to uploaded medical documents via file search
                    - Documents are in Polish and contain: protocols, statistics, team performance data, medical procedures
                    - Documents include emergency response data, ambulance equipment, and treatment guidelines

                    ANSWER GUIDELINES:
                    1. ONLY use information from the retrieved documents
                    2. If the answer is NOT in the documents, respond in Polish: 'Nie mam tej informacji w dostępnej dokumentacji'
                    3. Always cite the source document name in your answer
                    4. For statistics, include exact numbers and percentages
                    5. For medical procedures, list steps in order with proper medical terminology
                    6. If documents conflict, mention both perspectives
                    7. Use proper Polish medical terminology";
        }

        public string EnhanceUserQuery(string userQuery, string additionalContext = null)
        {
            var enhancedQuery = $@"Na podstawie dostępnej dokumentacji medycznej: {userQuery}";

            if (!string.IsNullOrWhiteSpace(additionalContext))
            {
                enhancedQuery += $"\n\nDodatkowy kontekst: {additionalContext}";
            }
             
            enhancedQuery += @"Proszę o szczegółową odpowiedź zawierającą:
                               - Konkretne dane i statystyki jeśli dostępne
                               - Procedury krok po kroku jeśli dotyczy
                               - Cytowanie źródłowych dokumentów
                               WAŻNE: Odpowiedź MUSI być po polsku.";

            return enhancedQuery;
        }

        public string BuildContextualPrompt(string userQuery, string documentContext)
        {
            return $@"KONTEKST Z DOKUMENTÓW: {documentContext} PYTANIE UŻYTKOWNIKA: {userQuery}
                    INSTRUKCJE:
                    Odpowiedz TYLKO na podstawie powyższego kontekstu. Jeśli odpowiedzi nie ma w kontekście, powiedz o tym.
                    ODPOWIEDŹ MUSI BYĆ PO POLSKU.";
        }
        public string GetNoDataFoundMessage()
        {
            return "Nie znalazłem tej informacji w dostępnych dokumentach. Proszę spróbować przesłać dokumenty zawierające te informacje lub zadać inne pytanie.";
        }

        public string GetErrorMessage()
        {
            return "Wystąpił błąd podczas przetwarzania zapytania. Proszę spróbować ponownie.";
        }
    }
}
