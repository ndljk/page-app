using page_app_back.Data.Models;
using page_app_back.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace page_app_back.Data.Services
{
    public class KurseviService
    {
        private AppDbContext _context;
        public KurseviService(AppDbContext context)
        {
            _context = context;
        }

        public void DodajKurs(KursViewModel kurs)
        {
            var _kurs = new Kurs()
            {
                Naziv = kurs.Naziv
            };
            _context.Kursevi.Add(_kurs);
            _context.SaveChanges();
            foreach (var id in kurs.StudentIds)
            {
                var _student_kurs = new Student_Kurs()
                {
                    StudentId = id,
                    KursId = _kurs.Id
                };

                _context.Studenti_Kursevi.Add(_student_kurs);
                _context.SaveChanges();
            }
        }

        public List<Kurs> DohvatiKurseve() => _context.Kursevi.ToList();

        public KursSaStudentimaViewModel DohvatiKurs(int kursId)
        {
            var _kurs = _context.Kursevi.Where(n => n.Id == kursId).Select(n => new KursSaStudentimaViewModel()
            {
                Naziv = n.Naziv,
                ImeStudenta = n.Studenti_Kursevi.Select(n => n.Student.Ime).ToList(),
                PrezimeStudenta = n.Studenti_Kursevi.Select(n => n.Student.Prezime).ToList()
            }).FirstOrDefault();

            return _kurs;
        }
        public void ObrisiKurs(int kursId)
        {
            var _kurs = _context.Kursevi.FirstOrDefault(n => n.Id == kursId);
            if (_kurs != null)
            {
                _context.Kursevi.Remove(_kurs);
                _context.SaveChanges();
            }
        }
    }
}
