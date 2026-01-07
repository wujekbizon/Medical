using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.RAG
{
    public class FileSearchStore
    {
        public string StoreId { get; set; }
        public string DisplayName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int TotalDocuments { get; set; }
        public string Status { get; set; }

        #region Konstruktor
            public FileSearchStore()
            {
                Status = "Active";
                CreatedDate = DateTime.Now;
            }
        #endregion
    }
}
