using System.Windows.Controls;
using W2G.EF;
using W2G.WPF.Core;
namespace W2G.WPF
{
    /// <summary>
    /// Logique d'interaction pour UsageBoard.xaml
    /// </summary>
    public partial class UsageBoard : UserControl, IBoardControl<UsageEntity>
    {
        public BoardVM<UsageEntity> VM { get; }
        public UsageBoard(UsageController controller, EBoardMode mode, string search)
        {
            VM = new BoardVM<UsageEntity>(controller, mode, search);

            VM.DefaultEntityFunc = () => new UsageEntity();

            VM.SearchFunc = SearchSource;
            DataContext = VM;
            InitializeComponent();
        }

        public UsageBoard(EBoardMode mode, string search)
            : this(new UsageController(), mode, search)
        {
        }

        public UsageBoard()
            : this(new UsageController(), EBoardMode.Extended, null)
        {
        }

        private bool SearchSource(string search, UsageEntity entity)
        {
            return entity.MatchSearch(search);
        }

        private void DGrdMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
            => (this as IBoardControl<UsageEntity>).DGrdMDC();
    }
}
