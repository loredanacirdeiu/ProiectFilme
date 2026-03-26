using InterfataUtilizator;
using LibrarieModele;
using NivelStocareDate;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        IStocareData admin = StocareFactory.GetAdministratorStocare();

        Film? filmNou = null;
        bool ruleaza = true;

        while (ruleaza)
        {
            Console.WriteLine("\n1. Adauga film");
            Console.WriteLine("2. Salveaza");
            Console.WriteLine("3. Afiseaza filme");
            Console.WriteLine("4. Cauta dupa gen");
            Console.WriteLine("5. Cauta film specific");
            Console.WriteLine("0. Iesire");

            string opt = Console.ReadLine();
            switch (opt)
            {
                case "1":
                    filmNou = AdaugaFilm();
                    break;
                case "2":
                    if (filmNou != null)
                    {
                        admin.AdaugaFilm(filmNou);
                        Console.WriteLine("Film salvat in fisier.");
                    }
                    else
                    {
                        Console.WriteLine("Trebuie sa cititi un film intai (optiunea 1).");
                    }
                    break;
                case "3":
                    AfiseazaLista(admin.GetFilme());
                    break;
                case "4":
                    // Trimitem admin ca parametru ca sa fie recunoscut in metoda
                    CautaFilmDupaGen(admin);
                    break;
                case "5":
                    // Trimitem admin ca parametru ca sa fie recunoscut in metoda
                    CautaFilmSpecific(admin);
                    break;
                case "0":
                    ruleaza = false;
                    break;
                default:
                    Console.WriteLine("Optiune inexistenta.");
                    break;
            }
        }
    }

    // Metoda ta: Am scos admin din interior si am pus return pentru filmNou
    static Film AdaugaFilm()
    {
        try
        {
            Console.Write("Titlu: ");
            string titlu = Console.ReadLine();

            Console.Write("Regizor: ");
            string regizor = Console.ReadLine();

            Console.Write("An: ");
            int an = int.Parse(Console.ReadLine());

            List<string> actori = new List<string>();
            string actor;
            do
            {
                Console.Write("Actor (ENTER pentru stop): ");
                actor = Console.ReadLine();
                if (!string.IsNullOrEmpty(actor)) actori.Add(actor);
            } while (!string.IsNullOrEmpty(actor));

            Console.WriteLine("Gen (0-Actiune,1-Comedie,2-Drama,3-Horror,4-SF): ");
            GenFilm gen = (GenFilm)int.Parse(Console.ReadLine());

            Console.WriteLine("Optiuni (1-Subtitrare,2-Dublat,4-3D,8-HD): ");
            OptiuniFilm opt = (OptiuniFilm)int.Parse(Console.ReadLine());

            // Returnam obiectul creat pentru a fi salvat ulterior sau afisat
            return new Film(0, titlu, regizor, an, actori, gen, opt);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Eroare: {ex.Message}");
            return null;
        }
    }

    static void AfiseazaLista(List<Film> filme)
    {
        foreach (var f in filme)
        {
            Console.WriteLine(f.Info());
        }
    }

    // Metoda ta: Am schimbat parametrul in IStocareData admin ca sa mearga apelul admin.CautaDupaGen
    static void CautaFilmDupaGen(IStocareData admin)
    {
        try
        {
            Console.WriteLine("Introdu genul (0-4): ");
            GenFilm gen = (GenFilm)int.Parse(Console.ReadLine());
            var rezultate = admin.CautaDupaGen(gen);
            AfiseazaLista(rezultate);
        }
        catch { Console.WriteLine("Gen invalid."); }
    }

    // Metoda ta: Am pastrat logica intacta, doar am asigurat accesul la admin
    static void CautaFilmSpecific(IStocareData admin)
    {
        Console.Write("\nTitlu film cautat: ");
        string t = Console.ReadLine();
        Console.Write("Regizor film cautat: ");
        string r = Console.ReadLine();

        Film filmGasit = admin.GetFilm(t, r);

        if (filmGasit != null)
        {
            Console.WriteLine("\nFILM GASIT:");
            Console.WriteLine(filmGasit.Info());
        }
        else
        {
            Console.WriteLine("\nFilmul nu a fost gasit in baza de date.");
        }
    }
}
