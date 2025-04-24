using System.Windows.Controls;
using W2G.WPF.Modules;
using W2G.WPF.Controls;

namespace W2G.WPF;

public partial class HomePage : UserControl
{
    public MainWindow Main { get; private set; }
    public HomePage(MainWindow main)
    {
        Main = main;
        InitializeComponent();

        BtnMod_Admin.GetModule = () => new AdminMod();
        BtnMod_Tech.GetModule = () => new TechMod();
        BtnMod_Compta.GetModule = () => new ComptaMod();

        switch (App.USER.Role)
        {
            case 2:
                BtnMod_Compta.Visibility = System.Windows.Visibility.Visible;
                Btn_Module_Click(BtnMod_Compta);
                break;
            case 3:
                BtnMod_Tech.Visibility = System.Windows.Visibility.Visible;
                Btn_Module_Click(BtnMod_Tech);
                break;
            case 4:
                BtnMod_Admin.Visibility = System.Windows.Visibility.Visible;
                BtnMod_Compta.Visibility = System.Windows.Visibility.Visible;
                BtnMod_Tech.Visibility = System.Windows.Visibility.Visible;
                Btn_Module_Click(BtnMod_Admin);
                break;
        }
    }
    private void Btn_Module_Click(object sender, System.Windows.RoutedEventArgs e = null)
        => CCtrl_Module.Content = (sender as ModButton)?.GetModule();
}