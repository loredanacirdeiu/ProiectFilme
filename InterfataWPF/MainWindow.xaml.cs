using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using InterfataUtilizator;
namespace InterfataWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnFilme_Click(object sender, RoutedEventArgs e)
        {
            WindowFilme winFilme = new WindowFilme();
            winFilme.Show();
        }

        private void btnClienti_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Încerc să deschid fereastra Clienți...");
            WindowClienti winClienti = new WindowClienti();
            winClienti.Show();
        }
    }
}