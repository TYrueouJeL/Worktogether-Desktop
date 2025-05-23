using System.Windows.Controls;
using W2G.WPF.Core;

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
            BtnPage_Pack.FuncGetPage = () => new PackBoard();
            BtnPage_Order.FuncGetPage = () => new OrderBoard();
        }

        private void Btn_Page_Click(object sender, System.Windows.RoutedEventArgs e)
        => CCtrl_Page.Content = (sender as PageButton)?.FuncGetPage();
    }
}
