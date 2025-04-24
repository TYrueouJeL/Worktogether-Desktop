using System.Windows.Controls;
using W2G.EF;
using W2G.WPF.Core;

namespace W2G.WPF
{
    /// <summary>
    /// Logique d'interaction pour BayForm.xaml
    /// </summary>
    public partial class BayForm : UserControl, IFormControl<BayEntity>
    {
        public FormVM<BayEntity> VM { get; }
        public BayForm(BayController controller, EFormMode mode, BayEntity e)
        {
            InitializeComponent();
            DataContext = VM = new FormVM<BayEntity>(controller, mode, e);
        }
        public BayForm()
            : this(new BayController(), EFormMode.Create, new BayEntity())
        {

        }
    }
}
