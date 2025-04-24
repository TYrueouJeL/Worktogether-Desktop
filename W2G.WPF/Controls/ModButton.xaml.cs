using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.IconPacks;

namespace W2G.WPF.Controls
{
    /// <summary>
    /// Logique d'interaction pour ModButton.xaml
    /// </summary>
    public partial class ModButton : Button
    {
        #region Kind
        public static readonly DependencyProperty KindProperty =
            DependencyProperty.Register("Kind", typeof(PackIconMaterialKind), typeof(ModButton), new PropertyMetadata(PackIconMaterialKind.None));
        public PackIconMaterialKind Kind
        {
            get { return (PackIconMaterialKind)GetValue(KindProperty); }
            set { SetValue(KindProperty, value); }
        }
        #endregion

        #region Label
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(ModButton), new PropertyMetadata("Button"));
        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }
        #endregion
        public Func<UserControl> GetModule { get; set; }
        public ModButton()
        {
            InitializeComponent();
        }
    }
}