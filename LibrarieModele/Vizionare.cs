using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Vizionare
    {
        public string TitluFilm { get; set; }
        public DateTime Data { get; set; }

        public Vizionare(string titlu, DateTime data)
        {
            TitluFilm = titlu;
            Data = data;
        }

        // Metodă folosită pentru a salva frumos în interiorul liniei clientului
        public override string ToString()
        {
            return $"{TitluFilm}|{Data.ToString("dd/MM/yyyy")}";
        }
    }
}
