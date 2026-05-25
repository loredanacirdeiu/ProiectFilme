using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Linq;

namespace LibrarieModele
{
    public class Client : INotifyPropertyChanged, IDataErrorInfo
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const char SEPARATOR_ISTORIC = ','; // Pentru a separa vizionările între ele
        private const char SEPARATOR_INTERN_VIZIONARE = '|'; // Pentru Film|Data
        private const int ID = 0;
        private string nume;

        private string telefon;
        private string email;
        public int IdClient { get; set; }
        public string Nume
        {
            get => nume;
            set
            {
                nume = value;
                OnPropertyChanged();
            }
        }

       

        public string Telefon
        {
            get => telefon;
            set
            {
                telefon = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        private bool acordDate;
        public bool AcordDate
        {
            get => acordDate;
            set
            {
                acordDate = value;
                OnPropertyChanged();
            }
        }

        private string tipAbonament;
        public string TipAbonament
        {
            get => tipAbonament;
            set
            {
                tipAbonament = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Nume):

                        if (string.IsNullOrWhiteSpace(Nume))
                            return "Numele este obligatoriu";

                        break;

                    case nameof(Prenume):

                        if (string.IsNullOrWhiteSpace(Prenume))
                            return "Prenumele este obligatoriu";

                        break;

                    case nameof(Email):

                        if (string.IsNullOrWhiteSpace(Email))
                            return "Email obligatoriu";

                        if (!Email.Contains("@"))
                            return "Email invalid";

                        break;

                    case nameof(Telefon):

                        if (string.IsNullOrWhiteSpace(Telefon))
                            return "Telefon obligatoriu";

                        if (Telefon.Length != 10)
                            return "Telefonul trebuie să aibă 10 cifre";

                        if (!Telefon.All(char.IsDigit))
                            return "Telefonul trebuie să conțină doar cifre";

                        break;
                }

                return null;
            }
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
{
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
        public string Prenume { get; set; }
      
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
