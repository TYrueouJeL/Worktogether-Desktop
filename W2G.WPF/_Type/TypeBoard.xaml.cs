using System.Windows.Controls;
using W2G.EF;
using W2G.WPF.Core;

namespace W2G.WPF
{
    /// <summary>
    /// Logique d'interaction pour TypeBoard.xaml
    /// </summary>
    public partial class TypeBoard : UserControl, IBoardControl<TypeEntity>
    {
        public BoardVM<TypeEntity> VM { get; }
        public TypeBoard(TypeController controller, EBoardMode mode, string search)
        {
            VM = new BoardVM<TypeEntity>(controller, mode, search);

            VM.DefaultEntityFunc = () => new TypeEntity();

            VM.SearchFunc = SearchSource;
            DataContext = VM;
            InitializeComponent();
        }

        public TypeBoard(EBoardMode mode, string search)
            : this(new TypeController(), mode, search)
        {
        }

        public TypeBoard()
            : this(new TypeController(), EBoardMode.Extended, null)
        {
        }

        private bool SearchSource(string search, TypeEntity entity)
        {
            return entity.MatchSearch(search);
        }

        private void DGrdMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
            => (this as IBoardControl<TypeEntity>).DGrdMDC();
    }
}
