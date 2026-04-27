using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarieModele
{
    public class Client
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const char SEPARATOR_ISTORIC = ','; // Pentru a separa vizionările între ele
        private const char SEPARATOR_INTERN_VIZIONARE = '|'; // Pentru Film|Data

        public int IdClient { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public List<Vizionare> IstoricVizionari { get; set; } = new List<Vizionare>();
        // Constructor fără parametri
        public Client() { }

        // Constructor cu parametri
        public Client(int idClient, string nume, string prenume, string email, string telefon)
        {
            this.IdClient = idClient;
            this.Nume = nume;
            this.Prenume = prenume;
            this.Email = email;
            this.Telefon = telefon;
            this.IstoricVizionari = new List<Vizionare>();
        }
        public Client(string linieFisier)
        {
            var date = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            if (date.Length >= 5)
            {
                IdClient = int.Parse(date[0]);
                Nume = date[1];
                Prenume = date[2];
                Email = date[3];
                Telefon = date[4];

                
                if (date.Length > 5 && !string.IsNullOrEmpty(date[5]))
                {
                    var vizionariStr = date[5].Split(SEPARATOR_ISTORIC);
                    foreach (var v in vizionariStr)
                    {
                        var parti = v.Split(SEPARATOR_INTERN_VIZIONARE);
                        if (parti.Length == 2)
                            IstoricVizionari.Add(new Vizionare(parti[0], DateTime.ParseExact(parti[1], "dd/MM/yyyy", null)));
                    }
                }
            }

        }

        // Constructor pentru citirea din fișier (linie -> obiect)
       

        public string ConversieLaSirPentruFisier()
        {
            string istoric = string.Join(",", IstoricVizionari.Select(v => v.ToString()));
            return string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}",
                SEPARATOR_PRINCIPAL_FISIER, IdClient, Nume, Prenume, Email, Telefon, istoric);
        }
    }
}
