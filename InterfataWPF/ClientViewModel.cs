using LibrarieModele;

namespace InterfataWPF.ViewModels
{
    public class ClientViewModel
    {
        public Client ClientCurent { get; set; }

        public ClientViewModel()
        {
            ClientCurent = new Client();
        }
    }
}