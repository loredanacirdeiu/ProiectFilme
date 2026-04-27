using NivelStocareDate;
using System.Configuration;
using System.IO;
using System;

namespace InterfataUtilizator
{
    public static class StocareFactory
    {
        private const string FORMAT_SALVARE = "FormatSalvare";
        private const string NUME_FISIER = "NumeFisier";
        private const string NUME_FISIER_CLIENTI = "NumeFisierClienti";
        public static IStocareData GetAdministratorStocare()
        {
            string formatSalvare = ConfigurationManager.AppSettings[FORMAT_SALVARE] ?? "";
            string numeFisier = ConfigurationManager.AppSettings[NUME_FISIER] ?? "";

            // Determinare locație fișier în directorul soluției
            string locatieFisierSolutie = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName ?? "";
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

            if (formatSalvare != null)
            {
                switch (formatSalvare.ToLower())
                {
                    case "txt":
                        return new AdministrareFilmeFisierText(caleCompletaFisier + "." + formatSalvare);
                    case "memorie":
                    default:
                        return new AdministrareFilmeMemorie();
                }
            }

            return null;
        }

        public static IStocareData GetAdministratorStocareClienti()
        {
            string numeFisier = ConfigurationManager.AppSettings["NumeFisierClienti"] ?? "Clienti";

            string caleCompletaFisier = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, numeFisier + ".txt");

            return new AdministrareClientiFisierText(caleCompletaFisier);
        }
    }
}
    
