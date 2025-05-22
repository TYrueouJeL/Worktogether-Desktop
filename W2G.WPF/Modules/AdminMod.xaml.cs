using System.Windows.Controls;
using W2G.WPF.Core;

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
            BtnPage_Users.FuncGetPage = () => new UserBoard();
        }

        private void Btn_Page_Click(object sender, System.Windows.RoutedEventArgs e)
        => CCtrl_Page.Content = (sender as PageButton)?.FuncGetPage();
    }
}
