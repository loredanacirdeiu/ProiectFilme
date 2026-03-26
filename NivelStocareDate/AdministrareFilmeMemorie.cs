using LibrarieModele;
using System.Collections.Generic;
using System.Linq;

namespace NivelStocareDate
{
    public class AdministrareFilmeMemorie : IStocareData
    {
        private List<Film> filme;

        public AdministrareFilmeMemorie()
        {
            filme = new List<Film>();
        }

        public void AdaugaFilm(Film f)
        {
            f.IdFilm = GetNextId();
            filme.Add(f);
        }

        public List<Film> GetFilme()
        {
            return filme;
        }

        public List<Film> CautaDupaGen(GenFilm gen)
        {
            return filme.Where(f => f.Gen == gen).ToList();
        }
        public Film GetFilm(int idFilm)
        {
            return filme.FirstOrDefault(f => f.IdFilm == idFilm);
        }

        public Film GetFilm(string titlu, string regizor)
        {
            return filme.FirstOrDefault(f => f.Titlu == titlu && f.Regizor == regizor);
        }

        public bool UpdateFilm(Film fActualizat)
        {
            int index = filme.FindIndex(f => f.IdFilm == fActualizat.IdFilm);
            if (index != -1)
            {
                filme[index] = fActualizat;
                return true;
            }
            return false;
        }

        private int GetNextId()
        {
            if (filme.Count == 0)
            {
                return 1;
            }
            return filme.Last().IdFilm + 1;
        }
    }
}