using System;
using System.Collections.Generic;
namespace LibrarieModele
{
    public class Film
    {
        public string Titlu { get; set; }
        public string Regizor { get; set; }
        public int An { get; set; }
        public List<string> ActoriPrincipali { get; set; }
        public GenFilm Gen { get; set; }
        public OptiuniFilm Optiuni { get; set; }
        public Film() { }
        public Film(string titlu, string regizor, int an, List<string> actori, GenFilm gen, OptiuniFilm optiuni)
        {   
            Titlu = titlu; Regizor = regizor; An = an; ActoriPrincipali = actori; Gen = gen; Optiuni = optiuni;
        }
        public string Info() {
            string actori = string.Join(", ", ActoriPrincipali); 
            return $"{Titlu} | {Regizor} | {An} | {actori} | {Gen} | {Optiuni}"; }
    }
}
