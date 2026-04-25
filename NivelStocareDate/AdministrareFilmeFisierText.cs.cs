using LibrarieModele;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelStocareDate
{
    public class AdministrareFilmeFisierText : IStocareData
    {
        private string numeFisier;
        public AdministrareFilmeFisierText(string numeFisier) 
        {
            this.numeFisier = numeFisier;
            Stream s=File.Open(numeFisier, FileMode.OpenOrCreate);
            s.Close();
        }

        public void AdaugaFilm(Film f)
        {
            f.IdFilm = GetNextId();
            using (StreamWriter sw = new StreamWriter(numeFisier, true))
            {
                sw.WriteLine(f.ConversieLaSirPentruFisier());
            }
        }

        public List<Film> GetFilme()
        {
            List<Film> filme = new List<Film>();
            using (StreamReader sr = new StreamReader(numeFisier))
            {
                string linie;
                while ((linie = sr.ReadLine()) != null)
                {
                    filme.Add(new Film(linie));
                }
            }
            return filme;
        }

        public List<Film> CautaDupaGen(GenFilm gen)
        {
            return GetFilme().Where(f => f.Gen == gen).ToList();
        }
        public Film GetFilm(int idFilm)
        {
            return GetFilme().FirstOrDefault(f => f.IdFilm == idFilm);
        }

        public Film GetFilm(string titlu, string regizor)
        {
            return GetFilme().FirstOrDefault(f => f.Titlu == titlu && f.Regizor == regizor);
        }

        public bool UpdateFilm(Film fActualizat)
        {
            List<Film> filme = GetFilme();
            bool succes = false;
            using (StreamWriter sw = new StreamWriter(numeFisier, false))
            {
                foreach (var f in filme)
                {
                    Film deScris = (f.IdFilm == fActualizat.IdFilm) ? fActualizat : f;
                    sw.WriteLine(deScris.ConversieLaSirPentruFisier());
                }
                succes = true;
            }
            return succes;
        }

        private int GetNextId()
        {
            var filme = GetFilme();
            if (filme.Count == 0)
            {
                return 1;
            }
            return filme.Last().IdFilm + 1;
        }

        public void AdaugaClient(Client c)
        {
            throw new NotImplementedException("Folositi AdministrareClientiFisierText pentru clienti.");
        }

        public List<Client> GetClienti()
        {
            return new List<Client>(); // Returnează listă goală pentru a nu crăpa aplicația
        }

      



    }
}
