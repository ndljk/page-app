using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace page_app_back.Data.ViewModels
{
    public class StudentViewModel
    {
        public int Br_indeksa { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Godina { get; set; }

        public int StatusId { get; set; }
        public List<int> KursIds { get; set; }
    }

    public class StudentSaKursevimaViewModel
    {
        public int Br_indeksa { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Godina { get; set; }

        public string StatusStudenta { get; set; }
        public List<string> NaziviKurseva { get; set; }
    }
}
