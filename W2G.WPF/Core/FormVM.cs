using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using W2G.EF;

namespace W2G.WPF.Core
{
    public interface IFormControl<E> where E : WtgEntity, new()
    {
        FormVM<E> VM { get; }

        void ReloadVM(EFormMode mode, E entity)
            => VM.ReloadVM(mode, entity);
    }
    public class FormVM<E> : EntityVM<E> where E: WtgEntity, new()
    {
        public EFormMode Mode { get; private set; }
        private EntityPresentation<E> _Presentation = null;
        public EntityPresentation<E> Presentation
        {
            get {  return  _Presentation; }
            set
            {
                _Presentation = value;
                OnPropertyChanged();

                SaveCommand = _Presentation.SaveCommand;
                OnPropertyChanged(nameof(SaveCommand));

                ResetCommand = _Presentation.ResetCommand;
                OnPropertyChanged(nameof(ResetCommand));

                HelpCommand = _Presentation.HelpCommand;
                OnPropertyChanged(nameof(HelpCommand));
            }
        }

        
        public ICommand SaveCommand { get; private set; }
        public ICommand ResetCommand { get; private set; }

        public ICommand CancelCommand { get; private set; }
        public Action OnCancel
        {
            set
            {
                CancelCommand = new RelayCommand(value);
                OnPropertyChanged(nameof(CancelCommand));
            }
        }

        public ICommand HelpCommand { get; private set; }

        public FormVM(EntityController<E> controller)
            : base(controller)
        {
            
        }
        public FormVM(EntityController<E> controller, EFormMode mode, E entity)
            : this(controller)
        {
            ReloadVM(mode, entity);
        }

        public virtual void ReloadVM(EFormMode mode, E entity)
        {
            Mode = mode;
            Presentation = Controller.GetPresentedEntity(entity);
        }
    }
}
