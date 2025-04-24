using System.Windows.Controls;
using W2G.EF;
using W2G.WPF.Core;

namespace W2G.WPF
{
    /// <summary>
    /// Logique d'interaction pour StateBoard.xaml
    /// </summary>
    public partial class StateBoard : UserControl, IBoardControl<StateEntity>
    {
        public BoardVM<StateEntity> VM { get; }
        public StateBoard(StateController controller, EBoardMode mode, string search)
        {
            VM = new BoardVM<StateEntity>(controller, mode, search);

            VM.DefaultEntityFunc = () => new StateEntity();

            VM.SearchFunc = SearchSource;
            DataContext = VM;
            InitializeComponent();
        }

        public StateBoard(EBoardMode mode, string search)
            : this(new StateController(), mode, search)
        {
        }

        public StateBoard()
            : this(new StateController(), EBoardMode.Extended, null)
        {
        }

        private bool SearchSource(string search, StateEntity entity)
        {
            return entity.MatchSearch(search);
        }

        private void DGrdMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
            => (this as IBoardControl<StateEntity>).DGrdMDC();
    }
}
