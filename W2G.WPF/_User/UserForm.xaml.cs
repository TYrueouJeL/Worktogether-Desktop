using System.Windows.Controls;
using W2G.EF;
using W2G.WPF.Core;

namespace W2G.WPF
{
    /// <summary>
    /// Logique d'interaction pour UserForm.xaml
    /// </summary>
    public partial class UserForm : UserControl, IFormControl<UserEntity>
    {
        public FormVM<UserEntity> VM { get; }
        public UserForm(UserController controller, EFormMode mode, UserEntity e)
        {
            InitializeComponent();
            DataContext = VM = new FormVM<UserEntity>(controller, mode, e);
        }
        public UserForm(EFormMode mode, UserEntity e)
            : this(new UserController(), mode, e)
        {
        }
    }
}
