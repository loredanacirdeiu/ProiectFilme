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
using InterfataWPF.ViewModels;
namespace InterfataWPF
{
    /// <summary>
    /// Interaction logic for WindowClienti.xaml
    /// </summary>
    public partial class WindowClienti : Window
    {
        
        private const int MAX_LUNGIME = 15;
        private const int LUNG_TEL = 10;
        private const int MAX_LUNGIME_PRENUME = 15;
        IStocareData admin = StocareFactory.GetAdministratorStocareClienti();
        private ClientViewModel vm;
        public WindowClienti()
        {
            InitializeComponent();

            vm = new ClientViewModel();

            DataContext = vm;
            if (admin != null)
                RefreshGrid();
            else
                MessageBox.Show("Eroare la inițializarea stocării!");
        }

        private void btnSalveaza_Click(object sender, RoutedEventArgs e)
        {
            lblPrenume.Foreground = Brushes.Black;
         
            bool valid = true;
            lblNume.Foreground = Brushes.Black;
            lblTelefon.Foreground = Brushes.Black;

            if (txtNume.Text.Length > MAX_LUNGIME || txtNume.Text == "")
            {
                lblNume.Foreground = Brushes.Red; valid = false;
            }

            if (txtPrenume.Text.Length > MAX_LUNGIME_PRENUME || txtPrenume.Text == "")
            {
                lblPrenume.Foreground = Brushes.Red;
                valid = false;
            }

            if (txtTelefon.Text.Length != LUNG_TEL)
            {
                lblTelefon.Foreground = Brushes.Red; valid = false;
            }

            if (valid)
            {
                admin.AdaugaClient(new Client(0, txtNume.Text, txtPrenume.Text, txtEmail.Text, txtTelefon.Text));
                RefreshGrid();
            }
            else
            {
                MessageBox.Show("Date invalide!");
            }
        }

        private void btnCauta_Click(object sender, RoutedEventArgs e)
        {
            dgClienti.ItemsSource = admin.GetClienti().Where(c => c.Telefon.Contains(txtCauta.Text)).ToList();
        }

        private void RefreshGrid() { dgClienti.ItemsSource = admin.GetClienti(); }

        private void dgClienti_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}
