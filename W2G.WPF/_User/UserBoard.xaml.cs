using System.Windows;
using System.Windows.Controls;
using W2G.EF;
using W2G.WPF.Core;

namespace W2G.WPF
{
    /// <summary>
    /// Logique d'interaction pour UserBoard.xaml
    /// </summary>
    public partial class UserBoard : UserControl, IBoardControl<UserEntity>
    {
        public BoardVM<UserEntity> VM { get; }
        public UserBoard(UserController controller, EBoardMode mode, string search)
        {
            VM = new BoardVM<UserEntity>(controller, mode, search);

            VM.DefaultEntityFunc = () => new UserEntity();

            VM.SearchFunc = SearchSource;
            DataContext = VM;
            InitializeComponent();
        }
        public UserBoard(EBoardMode mode, string search)
            : this(new UserController(), mode, search)
        {
        }
        public UserBoard()
            : this(new UserController(), EBoardMode.Extended, null)
        {
        }

        private bool SearchSource(string searchTxt, UserEntity entity)
        {
            return entity.MatchSearch(searchTxt);
        }

        private void DGrdMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
            => (this as IBoardControl<UserEntity>).DGrdMDC();
    }
}
