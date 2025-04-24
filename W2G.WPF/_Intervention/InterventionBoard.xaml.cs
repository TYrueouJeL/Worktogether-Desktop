using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using W2G.EF;
using W2G.WPF.Core;

namespace W2G.WPF
{
    /// <summary>
    /// Logique d'interaction pour interventionBoard.xaml
    /// </summary>
    public partial class InterventionBoard : UserControl, IBoardControl<InterventionEntity>
    {
        #region UnitFilter
        public static readonly DependencyProperty UnitFilterProperty =
            DependencyProperty.Register("UnitFilter", typeof(UnitEntity), typeof(InterventionBoard), new PropertyMetadata(UnitFilterChanged));

        private static void UnitFilterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            InterventionBoard board = d as InterventionBoard;
            board.UnitFilter = e.NewValue as UnitEntity;
            board.VM.ReloadSource();
        }

        public UnitEntity UnitFilter
        {
            get { return (UnitEntity)GetValue(UnitFilterProperty); }
            set { SetValue(UnitFilterProperty, value); }
        }
        #endregion

        public BoardVM<InterventionEntity> VM { get; }
        public InterventionBoard(InterventionController controller, EBoardMode mode, string search)
        {
            VM = new BoardVM<InterventionEntity>(controller, mode, search);
            VM.FilterFunc = FilterSource;

            VM.DefaultEntityFunc = () => new InterventionEntity();

            VM.SearchFunc = SearchSource;
            DataContext = VM;
            InitializeComponent();
        }
        public InterventionBoard(EBoardMode mode, string search)
            : this(new InterventionController(), mode, search)
        {
        }
        public InterventionBoard()
            : this(new InterventionController(), EBoardMode.Extended, null)
        {
        }

        private bool FilterSource(InterventionEntity entity)
        {
            if (UnitFilter != null && entity.UnitId != UnitFilter)
                return false;
            return true;
        }

        private bool SearchSource(string search, InterventionEntity entity)
        {
            return entity.MatchSearch(search)
                || (entity.Type?.MatchSearch(search) ?? false)
                || (entity.Unit?.MatchSearch(search) ?? false);
        }

        private void DGrdMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
            => (this as IBoardControl<InterventionEntity>).DGrdMDC();
    }
}