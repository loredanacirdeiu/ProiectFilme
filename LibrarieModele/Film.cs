using System;
using System.Collections.Generic;
using System.Linq;
namespace LibrarieModele
{
    public class Film
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const char SEPARATOR_SECUNDAR_FISIER = ',';

        private const int ID = 0;
        private const int TITLU = 1;
        private const int REGIZOR = 2;
        private const int AN = 3;
        private const int GEN = 4;
        private const int OPTIUNI = 5;
        private const int ACTORI = 6;

        public int IdFilm { get; set; }
        public string Titlu { get; set; }
        public string Regizor { get; set; }
        public int An { get; set; }
        public List<string> ActoriPrincipali { get; set; }
        public GenFilm Gen { get; set; }
        public OptiuniFilm Optiuni { get; set; }
        public Film() 
        {
            Titlu = string.Empty;
            Regizor = string.Empty;
            ActoriPrincipali = new List<string>();
        }
        public Film(int id,string titlu, string regizor, int an, List<string> actori, GenFilm gen, OptiuniFilm optiuni)
        {
            this.IdFilm = id;
            Titlu = titlu; 
            Regizor = regizor; 
            An = an; 
            ActoriPrincipali = actori; 
            Gen = gen; 
            Optiuni = optiuni;
        }

        public Film(string linieFisier)
        {
            string[] date = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);
            
                IdFilm = int.Parse(date[ID]);
                Titlu = date[TITLU];
                Regizor = date[REGIZOR];
                An = int.Parse(date[AN]);
                Gen = (GenFilm)Enum.Parse(typeof(GenFilm), date[GEN]);
                Optiuni = (OptiuniFilm)Enum.Parse(typeof(OptiuniFilm), date[OPTIUNI]);
                ActoriPrincipali = date[ACTORI].Split(SEPARATOR_SECUNDAR_FISIER).ToList();
            
        }
        public string Info() {
            string actori = string.Join(", ", ActoriPrincipali); 
            return $"{Titlu} | {Regizor} | {An} | {actori} | {Gen} | {Optiuni}"; 
        }

        public string ConversieLaSirPentruFisier()
        {
            string sActori = string.Join(SEPARATOR_SECUNDAR_FISIER.ToString(), ActoriPrincipali);
            return string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}",
                SEPARATOR_PRINCIPAL_FISIER,
                IdFilm,
                Titlu,
                Regizor,
                An,
                (int)Gen,
                (int)Optiuni,
                sActori);
        }

    }
}
