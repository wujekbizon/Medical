using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.RAG
{
    public class DocumentMetadata
    {
        public string DocumentId { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public DateTime UploadDate { get; set; }
        public string IndexStatus { get; set; }
        public Dictionary<string, object> CustomMetadata { get; set; }

        #region Konstruktor
            public DocumentMetadata()
            {
                UploadDate = DateTime.Now;
                IndexStatus = "Pending";
                CustomMetadata = new Dictionary<string, object>();
            }
        #endregion
    }
}
