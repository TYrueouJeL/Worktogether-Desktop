using System.Windows;
using System.Windows.Controls;
using W2G.EF;
using W2G.WPF.Core;

namespace W2G.WPF
{
    /// <summary>
    /// Logique d'interaction pour BayBoard.xaml
    /// </summary>
    public partial class BayBoard : UserControl, IBoardControl<BayEntity>
    {
        public BoardVM<BayEntity> VM { get; }
        public BayBoard(BayController controller, EBoardMode mode, string search)
        {
            VM = new BoardVM<BayEntity>(controller, mode, search);

            VM.DefaultEntityFunc = () => new BayEntity();
            
            VM.SearchFunc = SearchSource;
            DataContext = VM;
            InitializeComponent();
        }

        public BayBoard(EBoardMode mode, string search)
            : this(new BayController(), mode, search)
        {
        }

        public BayBoard()
            : this(new BayController(), EBoardMode.Extended, null)
        {
        }

        private bool SearchSource(string search, BayEntity entity)
        {
            return entity.MatchSearch(search);
        }

        private void DGrdMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
            => (this as IBoardControl<BayEntity>).DGrdMDC();
    }
}
