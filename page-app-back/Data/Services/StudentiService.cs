using page_app_back.Data.Models;
using page_app_back.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace page_app_back.Data.Services
{
    public class StudentiService
    {
        private AppDbContext _context;
        public StudentiService(AppDbContext context)
        {
            _context = context;
        }
        public void DodajStudenta(StudentViewModel student)
        {
            var _student = new Student()
            {
                Br_indeksa = student.Br_indeksa,
                Ime = student.Ime,
                Prezime = student.Prezime,
                Godina = student.Godina,
                StatusId = student.StatusId
            };
            _context.Studenti.Add(_student);
            _context.SaveChanges();

            foreach (var id in student.KursIds)
            {
                var _student_kurs = new Student_Kurs()
                {
                    StudentId = _student.Id,
                    KursId = id
                };

                _context.Studenti_Kursevi.Add(_student_kurs);
                _context.SaveChanges();
            }
        }

        public List<Student> DohvatiSveStudente() => _context.Studenti.ToList(); // isto sto i {return _context.Studenti.ToList();}

        public StudentSaKursevimaViewModel DohvatiStudenta(int studentId)
        {
            var _studentsakursevima = _context.Studenti.Where(n=>n.Id==studentId).Select(student => new StudentSaKursevimaViewModel()
            {
                Br_indeksa = student.Br_indeksa,
                Ime = student.Ime,
                Prezime = student.Prezime,
                Godina = student.Godina,
                StatusStudenta = student.Status.Status_studenta,
                NaziviKurseva = student.Studenti_Kursevi.Select(n => n.Kurs.Naziv).ToList()
            }).FirstOrDefault();

            return _studentsakursevima;
        }

        public Student UpdateStudenta(int studentId, StudentViewModel student)
        {
            var _student = _context.Studenti.FirstOrDefault(n => n.Id == studentId); //provjeravamo prvo da li student postoji
            if(_student!=null)
            {
                _student.Br_indeksa = student.Br_indeksa;
                _student.Ime = student.Ime;
                _student.Prezime = student.Prezime;
                _student.Godina = student.Godina;
                _student.StatusId = student.StatusId;

                _context.SaveChanges();
            }
            return _student;
        }

        public void ObrisiStudenta(int studentId)
        {
            var _student = _context.Studenti.FirstOrDefault(n => n.Id == studentId);
            if (_student != null)
            {
                _context.Studenti.Remove(_student);
                _context.SaveChanges();
            }
        }
    }
}
