using System.Windows.Controls;

namespace W2G.WPF.Modules
{
    /// <summary>
    /// Logique d'interaction pour AdminMod.xaml
    /// </summary>
    public partial class AdminMod : UserControl
    {
        public AdminMod()
        {
            InitializeComponent();
        }

        private void Btn_Page_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Button button = (Button)sender;
            switch (button.Name)
            {
                case "Btn_Page_Right":
                    //CCtrl_Page.Content = new RightPage();
                    break;
                case "Btn_Page_Users":
                    //CCtrl_Page.Content = new UserPage();
                    break;
                default:
                    CCtrl_Page.Content = null;
                    break;
            }
        }
    }
}
