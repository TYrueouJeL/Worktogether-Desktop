using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using W2G.WPF.Core;
using W2G.EF;

namespace W2G.WPF
{
    internal class UnitPresentation : EntityPresentation<UnitEntity>
    {
        public new UnitController Controller => (UnitController)base.Controller;

        #region Reference
        private string _Reference;
        public string Reference
        {
            get { return _Reference; }
            set
            {
                _Reference = value;
                ClearAndNotify();
                ValidatorTools.ValidateReference(this, _Reference);
            }
        }
        #endregion

        #region Bay
        private BayEntity? _Bay;
        public BayEntity? Bay
        {
            get { return _Bay; }
            set
            {
                _Bay = value;
                ClearAndNotify();
                ValidateBay();
            }
        }

        private void ValidateBay()
        {
            if (_Bay == null)
            {
                AddError(nameof(Bay), "Veuillez indiquer une baie");
            }
            else
            {
                var unitCount = _Bay.Units(Controller.Context).Count();
                if (unitCount >= 42)
                {
                    AddError(nameof(Bay), "La baie ne peut pas contenir plus de 42 unités");
                }
            }
        }

        public ICommand BayCommand { get; }
        #endregion

        #region State
        private StateEntity? _State;
        public StateEntity? State
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
            if (_State == null)
                AddError(nameof(State), "Veuillez indiquer un état");
        }

        public ICommand StateCommand { get; }
        #endregion

        #region Usage
        private UsageEntity? _Usage;
        public UsageEntity? Usage
        {
            get { return _Usage; }
            set
            {
                _Usage = value;
                ClearAndNotify();
                ValidateUsage();
            }
        }

        private void ValidateUsage()
        {
            if (_Usage == null)
                AddError(nameof(Usage), "Veuillez indiquer un usage");
        }

        public ICommand UsageCommand { get; }
        #endregion

        public CommandedUnitEntity? LastCommand { get; private set; }
        public OrderEntity? CurrentOrder => LastCommand?.Order;

        //public string CustomerName => CurrentOrder == null ? "" : CurrentOrder.User.FullName;
        //public string RentEndDate => CurrentOrder?.EndDate == null ? "" : CurrentOrder.EndDate.Value.ToString("dd/MM/yyyy");
        //public string InterventionCount => Entity.Interventions(Controller.Context).Count().ToString();

        public UnitPresentation(UnitController controller, UnitEntity entity) : base(controller, entity)
        {
            BayCommand = new RelayCommand(() =>
            {
                Bay = new BayController().ChooseEntity();
            });

            StateCommand = new RelayCommand(() =>
            {
                State = new StateController().ChooseEntity();
            });

            UsageCommand = new RelayCommand(() =>
            {
                Usage = new UsageController().ChooseEntity();
            });


            LastCommand = Controller.GetLastCommand(entity);
        }

        public override bool SaveFields()
        {
            if (!IsNew())
            {
                Entity.Bay   = Bay;
                Entity.State = State;
                Entity.Usage = Usage;
            }

            Entity.Reference = Reference;
            Entity.BayId     = Bay.Id;
            Entity.StateId   = State.Id;
            Entity.UsageId   = Usage.Id;

            return true;
        }

        public override void ResetFields()
        {
            Reference = Entity.Reference;
            Bay       = Entity.Bay;
            State     = Entity.State;
            Usage     = Entity.Usage;
        }
    }
}
