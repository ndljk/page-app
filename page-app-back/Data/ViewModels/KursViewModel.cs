using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace page_app_back.Data.ViewModels
{
    public class KursViewModel
    {
        public string Naziv { get; set; }
        public List<int> StudentIds { get; set; }
    }
    public class KursSaStudentimaViewModel
    {
        public string Naziv { get; set; }
        public List<string> ImeStudenta { get; set; }
        public List<string> PrezimeStudenta { get; set; }
    }
}
