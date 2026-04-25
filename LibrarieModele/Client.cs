namespace LibrarieModele
{
    public class Client
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';

        public int IdClient { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }

        // Constructor fără parametri
        public Client() { }

        // Constructor cu parametri
        public Client(int idClient, string nume, string prenume)
        {
            this.IdClient = idClient;
            this.Nume = nume;
            this.Prenume = prenume;
        }

        // Constructor pentru citirea din fișier (linie -> obiect)
        public Client(string linieFisier)
        {
            var date = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);
            IdClient = int.Parse(date[0]);
            Nume = date[1];
            Prenume = date[2];
        }

        public string ConversieLaSirPentruFisier()
        {
            return string.Format("{1}{0}{2}{0}{3}",
                SEPARATOR_PRINCIPAL_FISIER, IdClient, Nume, Prenume);
        }
    }
}
