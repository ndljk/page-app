using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace page_app_back.Data.Models
{
    public class JWTSettings
    {
        public string SecretKey { get; set; }
        //Ova klasa je kreirana da se ne bi svaki put tajni kljuc vadio iz appsettings.json
    }
}
