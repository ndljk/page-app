using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace page_app_back.Data.Models
{
    public class Student_Kurs
    {
        public int Id { get; set; }

        //Navigation props
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int KursId { get; set; }
        public Kurs Kurs { get; set; }
    }
}
