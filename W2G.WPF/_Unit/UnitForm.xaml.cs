using System.Windows.Controls;
using W2G.EF;
using W2G.WPF.Core;

namespace W2G.WPF
{
    /// <summary>
    /// Logique d'interaction pour UnitForm.xaml
    /// </summary>
    public partial class UnitForm : UserControl, IFormControl<UnitEntity>
    {
        public FormVM<UnitEntity> VM { get; }
        public UnitForm(UnitController controller, EFormMode mode, UnitEntity e)
        {
            InitializeComponent();
            DataContext = VM = new  FormVM<UnitEntity>(controller, mode, e);
        }
        public UnitForm(EFormMode mode, UnitEntity e)
            : this(new UnitController(), mode, e)
        {

        }
    }
}
