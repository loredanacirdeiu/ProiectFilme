using LibrarieModele;
using NivelStocareDate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using InterfataUtilizator;

namespace InterfataWPF
{
    /// <summary>
    /// Interaction logic for WindowFilme.xaml
    /// </summary>
    public partial class WindowFilme : Window
    {
        IStocareData adminFilme = StocareFactory.GetAdministratorStocare();

        public WindowFilme()
        {
            InitializeComponent();
            dgFilme.ItemsSource = adminFilme.GetFilme();
        }

        private void btnAdaugaFilm_Click(object sender, RoutedEventArgs e)
        {
            Film filmNou = new Film(0, txtTitlu.Text, txtRegizor.Text, 2024, new List<string>(), GenFilm.Actiune, OptiuniFilm.None);
            adminFilme.AdaugaFilm(filmNou); dgFilme.ItemsSource = adminFilme.GetFilme();
            dgFilme.ItemsSource = null;
            dgFilme.ItemsSource = adminFilme.GetFilme();

            MessageBox.Show("Film adăugat!");
        }
    }

}
