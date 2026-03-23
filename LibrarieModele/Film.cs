using System;
namespace LibrarieModele
{
    public class Film
    {
        public string Titlu { get; set; }
        public string Regizor { get; set; }
        public int An { get; set; }
        public GenFilm Gen { get; set; }
        public OptiuniFilm Optiuni { get; set; }
        public Film() { }
        public Film(string titlu, string regizor, int an, GenFilm gen, OptiuniFilm optiuni)
        {
            Titlu = titlu; Regizor = regizor; An = an; Gen = gen; Optiuni = optiuni;
        }
        public string Info() { return $"{Titlu} | {Regizor} | {An} | {Gen} | {Optiuni}"; }
    }
}
