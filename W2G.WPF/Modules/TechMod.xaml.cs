using System.Windows.Controls;
using W2G.WPF.Core;

namespace W2G.WPF.Modules
{
    /// <summary>
    /// Logique d'interaction pour TechMod.xaml
    /// </summary>
    public partial class TechMod : UserControl
    {
        public TechMod()
        {
            InitializeComponent();
            BtnPage_Bay.FuncGetPage = () => new BayBoard();
            BtnPage_Unit.FuncGetPage = () => new UnitBoard();
            BtnPage_Interventions.FuncGetPage = () => new InterventionBoard();
            BtnPage_Type.FuncGetPage = () => new TypeBoard();
            BtnPage_State.FuncGetPage = () => new StateBoard();
            BtnPage_Usage.FuncGetPage = () => new UsageBoard();
        }

        private void Btn_Page_Click(object sender, System.Windows.RoutedEventArgs e)
        => CCtrl_Page.Content = (sender as PageButton)?.FuncGetPage();
    }
}
