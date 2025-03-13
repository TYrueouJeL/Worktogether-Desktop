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
    /// Logique d'interaction pour TechMod.xaml
    /// </summary>
    public partial class TechMod : UserControl
    {
        public TechMod()
        {
            InitializeComponent();
        }

        private void Btn_Tech_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "Btn_Bay":
                    CCtrl_Page.Content = new AdminMod();
                    break;
                case "Btn_Unit":
                    CCtrl_Page.Content = new TechMod();
                    break;
                default:
                    CCtrl_Page.Content = null;
                    break;
            }
        }
    }
}
