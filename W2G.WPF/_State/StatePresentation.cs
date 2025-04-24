using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using W2G.WPF.Core;
using W2G.EF;

namespace W2G.WPF
{
    internal class StatePresentation : EntityPresentation<StateEntity>
    {
        #region State
        private string _State;
        public string State
        {
            get { return _State; }
            set
            {
                _State = value;
                ClearAndNotify();
                ValidateState();
            }
        }

        private void ValidateState()
        {
            if (string.IsNullOrWhiteSpace(_State))
                AddError(nameof(State), "Veuillez indiquer un état");
        }

        public ICommand StateCommand { get; }
        #endregion

        public StatePresentation(StateController controller, StateEntity entity) : base(controller, entity)
        {
            StateCommand = new RelayCommand(() =>
            {
                State = new StateController().ChooseEntity().State;
            });
        }

        public override bool SaveFields()
        {
            Entity.State = State;

            return true;
        }

        public override void ResetFields()
        {
            State = Entity.State;
        }
    }
}
