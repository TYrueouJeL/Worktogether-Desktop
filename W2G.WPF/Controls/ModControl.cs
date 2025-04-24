using System.Windows.Controls;
using W2G.WPF.Core;

namespace W2G.WPF.Controls
{
    public abstract class ModControl : UserControl
    {
        public ContentControl CCtrlPage => FindName("CCtrl_Page") as ContentControl;
        public ModControl()
        {

        }

        public void Btn_Page_Click(object sender, System.Windows.RoutedEventArgs e)
            => CCtrlPage.Content = (sender as PageButton)?.FuncGetPage?.Invoke();
    }
}
