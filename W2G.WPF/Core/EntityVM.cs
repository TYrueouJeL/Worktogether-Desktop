using System.ComponentModel;
using System.Runtime.CompilerServices;
using W2G.EF;

namespace W2G.WPF.Core
{
    public abstract class EntityVM<E> : INotifyPropertyChanged
        where E : WtgEntity, new()
    {
        public EntityController<E> Controller { get; }
        
        protected EntityVM(EntityController<E> controller)
        {
            Controller = controller;
        }

        #region NPC
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
