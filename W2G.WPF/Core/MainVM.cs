using System.ComponentModel;
using System.Runtime.CompilerServices;
using W2G.EF;

namespace W2G.WPF.Core
{
    public abstract class MainVM : INotifyPropertyChanged
    {
        public WtgContext Context { get; set; } = new WtgContext();

        #region NPC
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
