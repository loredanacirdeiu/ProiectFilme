using LibrarieModele;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NivelStocareDate
{
    public class AdministrareClientiFisierText : IStocareData
    {
        private string numeFisier;

        public AdministrareClientiFisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            // Creăm fișierul dacă nu există
            Stream s = File.Open(numeFisier, FileMode.OpenOrCreate);
            s.Close();
        }

        public void AdaugaClient(Client c)
        {
            using (StreamWriter sw = new StreamWriter(numeFisier, true))
            {
                sw.WriteLine(c.ConversieLaSirPentruFisier());
            }
        }

        public List<Client> GetClienti()
        {
            List<Client> listaClienti = new List<Client>();
            using (StreamReader sr = new StreamReader(numeFisier))
            {
                string linie;
                while ((linie = sr.ReadLine()) != null)
                {
                    listaClienti.Add(new Client(linie));
                }
            }
            return listaClienti;
        }
        private int GetNextIdClient()
        {
            var clienti = GetClienti();
            return clienti.Count == 0 ? 1 : clienti.Last().IdClient + 1;
        }

        public void AdaugaFilm(Film f) => throw new NotImplementedException();
        public List<Film> GetFilme() => new List<Film>();
        public List<Film> CautaDupaGen(GenFilm gen) => new List<Film>();
        public Film GetFilm(int idFilm) => null;
        public Film GetFilm(string titlu, string regizor) => null;
        public bool UpdateFilm(Film f) => false;

    }
}
