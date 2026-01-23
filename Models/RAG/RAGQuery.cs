using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.RAG
{
    public class RAGQuery
    {
        public string QueryText { get; set; }
        public string StoreId { get; set; }
        public string MetadataFilter { get; set; }
        public int MaxResults { get; set; }

        #region Konstruktor
            public RAGQuery()
            {
                MaxResults = 5;
            }
        #endregion

    }
}
