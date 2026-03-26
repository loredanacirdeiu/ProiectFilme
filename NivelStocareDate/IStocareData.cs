using LibrarieModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelStocareDate
{
    public interface IStocareData
    {
        void AdaugaFilm(Film f);
        List<Film> GetFilme();
        Film GetFilm(int idFilm);
        Film GetFilm(string titlu, string regizor);
        // Metoda mutata din Program.cs
        List<Film> CautaDupaGen(GenFilm gen);
        bool UpdateFilm(Film f);
    }
}
