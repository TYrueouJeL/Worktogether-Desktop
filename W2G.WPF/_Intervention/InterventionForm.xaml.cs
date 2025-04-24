using System.Windows.Controls;
using W2G.EF;
using W2G.WPF.Core;

namespace W2G.WPF
{
    /// <summary>
    /// Logique d'interaction pour InterventionForm.xaml
    /// </summary>
    public partial class InterventionForm : UserControl, IFormControl<InterventionEntity>
    {
        public FormVM<InterventionEntity> VM { get; }
        public InterventionForm(InterventionController controller, EFormMode mode, InterventionEntity e)
        {
            InitializeComponent();
            DataContext = VM = new FormVM<InterventionEntity>(controller, mode, e);
        }
        public InterventionForm(EFormMode mode, InterventionEntity e)
            : this(new InterventionController(), mode, e)
        {
        }
    }
}
