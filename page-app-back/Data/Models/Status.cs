using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace page_app_back.Data.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string Status_studenta { get; set; }

        //Navigation props - definisu relacije medju modelima
        public List<Student> Studenti { get; set; }
    }
}
