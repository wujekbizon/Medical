using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.EntitiesForView
{
    public class OcenaZespoluForAllView
    {
        public int IdOceny { get; set; }
        public int Ocena { get; set; }
        public DateTime DataOceny { get; set; }
        public string Komentarz { get; set; }
        public string KryteriumOceny { get; set; }
        public int? WagaOceny { get; set; }
        public int? OcenaCzasuReakcji { get; set; }
        public int? OcenaProfesjonalizmu { get; set; }
        public int? OcenaSkutecznosci { get; set; }
        public string PacjentDalOpinie { get; set; }
        public string SugerowaneUlepszenia { get; set; }
        public int? OcenaStosowaniaStandardow { get; set; }
        public string NazwaZespolu { get; set; }
        public string Oceniajacy { get; set; }
        public string AdresZdarzenia { get; set; }

        public OcenaZespoluForAllView()
        {
        }
    }
}