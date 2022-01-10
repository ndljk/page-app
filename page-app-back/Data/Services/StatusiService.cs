using page_app_back.Data.Models;
using page_app_back.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace page_app_back.Data.Services
{
    public class StatusiService
    {
        private AppDbContext _context;
        public StatusiService(AppDbContext context)
        {
            _context = context;
        }
        public List<Status> DohvatiStatuse() => _context.Statusi.ToList();
    }
}
