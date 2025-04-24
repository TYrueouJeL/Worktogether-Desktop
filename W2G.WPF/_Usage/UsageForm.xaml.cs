using System.Windows.Controls;
using W2G.EF;
using W2G.WPF.Core;

namespace W2G.WPF
{
    /// <summary>
    /// Logique d'interaction pour UsageForm.xaml
    /// </summary>
    public partial class UsageForm : UserControl, IFormControl<UsageEntity>
    {
        public FormVM<UsageEntity> VM { get; }
        public UsageForm(UsageController controller, EFormMode mode, UsageEntity e)
        {
            DataContext = VM = new  FormVM<UsageEntity>(controller, mode, e);
            InitializeComponent();
        }

        public UsageForm(EFormMode mode, UsageEntity e)
            : this(new UsageController(), mode, e)
        {
        }
    }
}
