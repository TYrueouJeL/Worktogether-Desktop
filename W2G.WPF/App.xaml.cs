using System.Configuration;
using System.Data;
using System.Windows;

namespace W2G.WPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public App()
    {
        Exit += App_Exit;
    }

    private void App_Exit(object sender, ExitEventArgs e)
    {
        
    }

    private void Application_Startup(object sender, StartupEventArgs e)
    {
        new MainWindow("Accueil").ShowDialog();
    }
}

