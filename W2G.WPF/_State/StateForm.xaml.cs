using System.Windows.Controls;
using W2G.EF;
using W2G.WPF.Core;

namespace W2G.WPF
{
    /// <summary>
    /// Logique d'interaction pour StateForm.xaml
    /// </summary>
    public partial class StateForm : UserControl, IFormControl<StateEntity>
    {
        public FormVM<StateEntity> VM { get; }
        public StateForm(StateController controller, EFormMode mode, StateEntity e)
        {
            InitializeComponent();
            DataContext = VM = new  FormVM<StateEntity>(controller, mode, e);
        }

        public StateForm(EFormMode mode, StateEntity e)
            : this(new StateController(), mode, e)
        {
        }
    }
}
