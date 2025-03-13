using MahApps.Metro.Controls;
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
using W2G.WPF.Modules;

namespace W2G.WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : MetroWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public MainWindow(string title)
    {
        InitializeComponent();
        Title = title;
    }

    private void Btn_Module_Click(object sender, RoutedEventArgs e)
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