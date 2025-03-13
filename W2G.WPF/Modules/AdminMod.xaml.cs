using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        private void Btn_Page_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "Btn_Admin":
                    CCtrl_Module.Content = new AdminMod();
                    break;
                case "Btn_Tech":
                    CCtrl_Module.Content = new TechMod();
                    break;
                case "Btn_Compta":
                    CCtrl_Module.Content = new ComptaMod();
                    break;
                default:
                    CCtrl_Module.Content = null;
                    break;
            }
        }
    }
}
