using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace page_app_back.Data.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int Br_indeksa { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Godina { get; set; }

        //Navigation props
        //1:n
        public int StatusId { get; set; }
        public Status Status { get; set; }
        //n:n - realizovana kao 1:n sa join tabelom
        public List<Student_Kurs> Studenti_Kursevi { get; set; }

    }
}
