using System.Windows.Controls;

namespace W2G.WPF.Modules
{
    /// <summary>
    /// Logique d'interaction pour ComptaMod.xaml
    /// </summary>
    public partial class ComptaMod : UserControl
    {
        public ComptaMod()
        {
            InitializeComponent();
        }

        private void Btn_Page_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Button button = (Button)sender;
            switch (button.Name)
            {
                case "Btn_Page_Customer":
                    //CCtrl_Page.Content = new CustomerPage();
                    break;
                case "Btn_Page_Contract":
                    //CCtrl_Page.Content = new ContractPage();
                    break;
                case "Btn_Page_Offer":
                    //CCtrl_Page.Content = new OfferPage();
                    break;
                default:
                    CCtrl_Page.Content = null;
                    break;
            }
        }
    }
}
