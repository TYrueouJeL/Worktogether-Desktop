using System.Windows;
using System.Windows.Controls;
using W2G.EF;

namespace W2G.WPF
{
    /// <summary>
    /// Logique d'interaction pour LoginPage.xaml
    /// </summary>
    public partial class LoginPage : UserControl
    {
        public MainWindow Main { get; private set; }
        public LoginPage(MainWindow main)
        {
            Main = main;
            InitializeComponent();
            TxtBox_Login.Text = Environment.UserName + "@" + Environment.UserName + ".com";
            PwBow_Password.Password = "testtest";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var login = TxtBox_Login.Text;
            var password = PwBow_Password.Password;

            if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Veuillez saisir un login", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Veuillez saisir un mot de passe", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var ctx =App.GetContext();
                var user = ctx?.User.FirstOrDefault(item => item.Email == login);

                if (user == null)
                {
                    MessageBox.Show("Utilisateur inconnu", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (user.Role == 0)
                {
                    MessageBox.Show("Vous n'êtes pas autorisé à vous connecter", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (!PasswordHelper.CheckPassword(password, user.Password))
                {
                    MessageBox.Show("Mot de passe incorrect", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    App.USER = user;
                    Main.Title = "W2G - " + user.FirstName + " " + user.LastName;
                    Main.NavigateToHome();
                }
            }
        }
    }
}
