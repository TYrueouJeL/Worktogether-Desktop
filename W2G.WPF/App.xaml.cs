using System.Windows;
using W2G.EF;

namespace W2G.WPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static UserEntity USER { get; internal set; }
    public App()
    {
        Exit += App_Exit;
        //Shutdown();
    }

    private void App_Startup(object sender, StartupEventArgs e)
    {
        new MainWindow().ShowDialog();
    }
    private void App_Exit(object sender, ExitEventArgs e)
    {

    }

    internal static WtgContext? GetContext()
    {
        return new WtgContext();
    }
}

