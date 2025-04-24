using MahApps.Metro.IconPacks;
using System.Windows;
using System.Windows.Controls;

namespace W2G.WPF.Core
{
    /// <summary>
    /// Logique d'interaction pour PageButton.xaml
    /// </summary>
    public partial class PageButton : Button
    {
        #region Kind
        // Using a DependencyProperty as the backing store for Kind.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty KindProperty =
            DependencyProperty.Register("Kind", typeof(PackIconMaterialKind), typeof(PageButton), new PropertyMetadata(PackIconMaterialKind.None));
        public PackIconMaterialKind Kind
        {
            get { return (PackIconMaterialKind)GetValue(KindProperty); }
            set { SetValue(KindProperty, value); }
        }
        #endregion

        #region Label
        // Using a DependencyProperty as the backing store for Label.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(PageButton), new PropertyMetadata("Button"));
        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }
        #endregion

        public Func<UserControl> FuncGetPage { get; set; }
        public PageButton()
        {
            InitializeComponent();
        }
    }
}
