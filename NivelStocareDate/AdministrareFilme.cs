using LibrarieModele;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace NivelStocareDate
{
    public class AdministrareFilme
    {
        private const string fisier = "filme.txt";
        private List<Film> filme = new List<Film>();
        public void AdaugaFilm(Film film) { filme.Add(film); File.AppendAllText(fisier, film.Info() + "\n"); }
        public List<Film> GetFilme() { return filme; }
        public List<Film> CautaDupaGen(GenFilm gen) { return filme.Where(f => f.Gen == gen).ToList(); }
    }
}
