using System.Windows.Controls;
using W2G.EF;
using W2G.WPF.Core;

namespace W2G.WPF
{
    /// <summary>
    /// Logique d'interaction pour TypeForm.xaml
    /// </summary>
    public partial class TypeForm : UserControl, IFormControl<TypeEntity>
    {
        public FormVM<TypeEntity> VM { get; }
        public TypeForm(TypeController controller, EFormMode mode, TypeEntity e)
        {
            InitializeComponent();
            DataContext = VM = new FormVM<TypeEntity>(controller, mode, e);
        }
        public TypeForm(EFormMode mode, TypeEntity e)
            : this(new TypeController(), mode, e)
        {
        }
    }
}
