using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.RAG
{
    public class RAGResponse
    {
        public string ResponseText { get; set; }
        public List<Citation> Citations { get; set; }
        public int ProcessingTimeMs { get; set; }
        public DateTime QueryDate { get; set; }

        #region Konstruktor
        public RAGResponse()
        {
            Citations = new List<Citation>();
            QueryDate = DateTime.Now;
        }
        #endregion
    }

    public class Citation
    {
        public string SourceDocument { get; set; }
        public string Excerpt { get; set; }
        public string DocumentUrl { get; set; }
    }
}
