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
        private Film filmSelectat;
        public WindowFilme()
        {
            InitializeComponent();
            cmbGen.ItemsSource = Enum.GetValues(typeof(GenFilm));
            dgFilme.ItemsSource = adminFilme.GetFilme();
        }

        private void btnAdaugaFilm_Click(object sender, RoutedEventArgs e)
        {
            try
            {    // VALIDARE TITLU
                if (string.IsNullOrWhiteSpace(txtTitlu.Text))
                {
                    MessageBox.Show("Introdu titlul!");
                    return;
                }

                // VALIDARE REGIZOR
                if (string.IsNullOrWhiteSpace(txtRegizor.Text))
                {
                    MessageBox.Show("Introdu regizorul!");
                    return;
                }

                // VALIDARE AN
                if (!int.TryParse(txtAn.Text, out int an))
                {
                    MessageBox.Show("An invalid!");
                    return;
                }

                // VALIDARE GEN
                if (cmbGen.SelectedItem == null)
                {
                    MessageBox.Show("Selectează genul!");
                    return;
                }

                GenFilm genSelectat = (GenFilm)cmbGen.SelectedItem;

                List<string> actori =
                    txtActori.Text.Split(' ').ToList();

                OptiuniFilm optiuni = OptiuniFilm.None;

                if (chk3D.IsChecked == true)
                    optiuni |= OptiuniFilm.Format3D;

                if (chkSubtitrat.IsChecked == true)
                    optiuni |= OptiuniFilm.Subtitrat;

                if (chkDublat.IsChecked == true)
                    optiuni |= OptiuniFilm.Dublat;

                Film filmNou = new Film(
                    0,
                    txtTitlu.Text,
                    txtRegizor.Text,
                    int.Parse(txtAn.Text),
                    actori,
                    genSelectat,
                    optiuni
                );


                adminFilme.AdaugaFilm(filmNou);

                dgFilme.ItemsSource = null;
                dgFilme.ItemsSource = adminFilme.GetFilme();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCautaGen_Click(object sender, RoutedEventArgs e)
        {
            if (cmbGen.SelectedItem != null)
            {
                GenFilm genSelectat = (GenFilm)cmbGen.SelectedItem;

                dgFilme.ItemsSource = null;
                dgFilme.ItemsSource = adminFilme.CautaDupaGen(genSelectat);
            }
            else
            {
                MessageBox.Show("Selectează un gen!");
            }
        }

        private void dgFilme_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgFilme.SelectedItem != null)
            {
                filmSelectat = (Film)dgFilme.SelectedItem;

                txtTitlu.Text = filmSelectat.Titlu;
                txtRegizor.Text = filmSelectat.Regizor;
                txtAn.Text = filmSelectat.An.ToString();

                txtActori.Text =
                    string.Join(",", filmSelectat.ActoriPrincipali);

                cmbGen.SelectedItem = filmSelectat.Gen;

                chk3D.IsChecked =
                    filmSelectat.Optiuni.HasFlag(OptiuniFilm.Format3D);

                chkSubtitrat.IsChecked =
                    filmSelectat.Optiuni.HasFlag(OptiuniFilm.Subtitrat);

                chkDublat.IsChecked =
                    filmSelectat.Optiuni.HasFlag(OptiuniFilm.Dublat);
            }
        }

        private void btnModificaFilm_Click(object sender, RoutedEventArgs e)
        {
            if (filmSelectat != null)
            {
                filmSelectat.Titlu = txtTitlu.Text;
                filmSelectat.Regizor = txtRegizor.Text;
                filmSelectat.An = int.Parse(txtAn.Text);

                filmSelectat.ActoriPrincipali =
                    txtActori.Text.Split(',').ToList();

                filmSelectat.Gen =
                    (GenFilm)cmbGen.SelectedItem;

                OptiuniFilm optiuni = OptiuniFilm.None;

                if (chk3D.IsChecked == true)
                    optiuni |= OptiuniFilm.Format3D;

                if (chkSubtitrat.IsChecked == true)
                    optiuni |= OptiuniFilm.Subtitrat;

                if (chkDublat.IsChecked == true)
                    optiuni |= OptiuniFilm.Dublat;

                filmSelectat.Optiuni = optiuni;

                adminFilme.UpdateFilm(filmSelectat);
             
                dgFilme.ItemsSource = null;
                dgFilme.ItemsSource = adminFilme.GetFilme();

                
            }
        }

        private void btnStergeFilm_Click(object sender, RoutedEventArgs e)
        {
            if (dgFilme.SelectedItem != null)
            {
                Film filmDeSters = (Film)dgFilme.SelectedItem;

                adminFilme.DeleteFilm(filmDeSters.IdFilm);

                dgFilme.ItemsSource = null;
                dgFilme.ItemsSource = adminFilme.GetFilme();

                
            }
            else
            {
                MessageBox.Show("Selectează un film!");
            }
        }

        private void cmbGen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}
