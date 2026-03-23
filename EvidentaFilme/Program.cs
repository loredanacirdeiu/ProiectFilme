using LibrarieModele;
using NivelStocareDate;
using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        AdministrareFilme admin = new AdministrareFilme();
        bool ruleaza = true;
        while (ruleaza)
        {
            Console.WriteLine("\n1. Adauga film");
            Console.WriteLine("2. Afiseaza filme");
            Console.WriteLine("3. Cauta dupa gen");
            Console.WriteLine("0. Iesire");
            string opt = Console.ReadLine();
            switch (opt)
            {
                case "1": AdaugaFilm(admin); break;
                case "2": AfiseazaLista(admin.GetFilme()); break;
                case "3": CautaFilm(admin); break;
                case "0": ruleaza = false; break;
            }
        }
    }
    static void AdaugaFilm(AdministrareFilme admin)
    {
        Console.Write("Titlu: ");
        string titlu = Console.ReadLine();

        Console.Write("Regizor: ");
        string regizor = Console.ReadLine();

        Console.Write("An: ");
        int an = int.Parse(Console.ReadLine());

        Console.WriteLine("Gen (0-Actiune,1-Comedie,2-Drama,3-Horror,4-SF): ");
        GenFilm gen = (GenFilm)int.Parse(Console.ReadLine());

        Console.WriteLine("Optiuni (1-Subtitrare,2-Dublat,4-3D,8-HD): ");
        OptiuniFilm opt = (OptiuniFilm)int.Parse(Console.ReadLine());

        Film film = new Film(titlu, regizor, an, gen, opt);
        admin.AdaugaFilm(film);
    }
    static void AfiseazaLista(List<Film> filme)
    {
        foreach (var f in filme) { Console.WriteLine(f.Info()); }
    }
    static void CautaFilm(AdministrareFilme admin)
    {
        Console.WriteLine("Introdu gen (0-4): ");
        GenFilm gen = (GenFilm)int.Parse(Console.ReadLine());
        var rezultate = admin.CautaDupaGen(gen);
        AfiseazaLista(rezultate);
    }
}