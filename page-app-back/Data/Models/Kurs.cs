using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace page_app_back.Data.Models
{
    public class Kurs
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        //Navigation props
        public List<Student_Kurs> Studenti_Kursevi { get; set; }
    }
}
