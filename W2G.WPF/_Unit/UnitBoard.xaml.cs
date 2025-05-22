using System.Windows;
using System.Windows.Controls;
using W2G.EF;
using W2G.WPF.Core;

namespace W2G.WPF
{
    /// <summary>
    /// Logique d'interaction pour UnitBoard.xaml
    /// </summary>
    public partial class UnitBoard : UserControl, IBoardControl<UnitEntity>
    {
        #region BayFilter
        public static readonly DependencyProperty BayFilterProperty =
            DependencyProperty.Register("BayFilter", typeof(BayEntity), typeof(UnitBoard), new PropertyMetadata(BayFilterChanged));

        private static void BayFilterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UnitBoard board = d as UnitBoard;
            board.BayFilter = e.NewValue as BayEntity;
            board.VM.ReloadSource();
        }

        public BayEntity BayFilter
        {
            get { return (BayEntity)GetValue(BayFilterProperty); }
            set { SetValue(BayFilterProperty, value); }
        }
        #endregion

        public BoardVM<UnitEntity> VM { get; }
        public UnitBoard(UnitController controller, EBoardMode mode, string search)
        {
            VM = new BoardVM<UnitEntity>(controller, mode, search);
            VM.FilterFunc = FilterSource;

            VM.DefaultEntityFunc = () => new UnitEntity() { Bay = BayFilter };

            VM.SearchFunc = SearchSource;
            DataContext = VM;
            InitializeComponent();
        }

        public UnitBoard(EBoardMode mode, string search)
            : this(new UnitController(), mode, search)
        {
        }

        public UnitBoard()
           : this(new UnitController(), EBoardMode.Extended, null)
        {
        }

        private bool FilterSource(UnitEntity entity)
        {
            if (BayFilter != null && entity.BayId != BayFilter)
            {
                return false;
            }
            return true;
        }

        private bool SearchSource(string searchTxt, UnitEntity entity)
        {
            return entity.MatchSearch(searchTxt)
                || (entity.Bay?.MatchSearch(searchTxt) ?? false)
                || (entity.State?.MatchSearch(searchTxt) ?? false)
                || (entity.Usage?.MatchSearch(searchTxt) ?? false);
        }

        private void DGrdMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
            => (this as IBoardControl<UnitEntity>).DGrdMDC();
    }
}
