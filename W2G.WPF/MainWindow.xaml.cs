using MahApps.Metro.Controls;

namespace W2G.WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : MetroWindow
{
    public MainWindow()
    {
        InitializeComponent();
        NavigateToLogin();
    }

    internal void NavigateToLogin()
    {
        Content = new LoginPage(this);
    }

    internal void NavigateToHome()
    {
        Content = new HomePage(this);
    }
}