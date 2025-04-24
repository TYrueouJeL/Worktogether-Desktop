using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using W2G.WPF.Core;
using W2G.EF;

namespace W2G.WPF
{
    internal class InterventionPresentation : EntityPresentation<InterventionEntity>
    {
        #region Title
        private string _Title;
        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;
                ClearAndNotify();
                ValidateTitle();
            }
        }

        private void ValidateTitle()
        {
            if (string.IsNullOrWhiteSpace(_Title))
                AddError(nameof(Title), "Veuillez indiquer un titre");
        }

        public ICommand TitleCommand { get; }
        #endregion

        #region Description
        private string _Description;
        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
                ClearAndNotify();
                ValidateDescription();
            }
        }

        private void ValidateDescription()
        {
            if (string.IsNullOrWhiteSpace(_Description))
                AddError(nameof(Description), "Veuillez indiquer une description");
        }

        public ICommand DescriptionCommand { get; }
        #endregion

        #region Date
        private DateTime _Date;
        public DateTime Date
        {
            get { return _Date; }
            set
            {
                _Date = value;
                ClearAndNotify();
                ValidateDate();
            }
        }

        private void ValidateDate()
        {
            if (_Date == default)
                AddError(nameof(Date), "Veuillez indiquer une date");
        }

        public ICommand DateCommand { get; }
        #endregion

        #region Type
        private TypeEntity? _Type;
        public TypeEntity? Type
        {
            get { return _Type; }
            set
            {
                _Type = value;
                ClearAndNotify();
                ValidateType();
            }
        }

        private void ValidateType()
        {
            if (_Type == null)
                AddError(nameof(Type), "Veuillez indiquer un type");
        }

        public ICommand TypeCommand { get; }
        #endregion

        #region Unit
        private UnitEntity? _Unit;
        public UnitEntity? Unit
        {
            get { return _Unit; }
            set
            {
                _Unit = value;
                ClearAndNotify();
                ValidateUnit();
            }
        }

        private void ValidateUnit()
        {
            if (_Unit == null)
                AddError(nameof(Unit), "Veuillez indiquer une unité");
        }

        public ICommand UnitCommand { get; }
        #endregion

        #region DateString
        public string DateString
        {
            get { return Date.ToString("dd/MM/yyyy"); }
        }
        #endregion

        public InterventionPresentation(InterventionController controller, InterventionEntity entity) : base(controller, entity)
        {
            TitleCommand = new RelayCommand(() =>
            {
                Title = new InterventionController().ChooseEntity().Title;
            });

            DescriptionCommand = new RelayCommand(() =>
            {
                Description = new InterventionController().ChooseEntity().Description;
            });

            DateCommand = new RelayCommand(() =>
            {
                Date = new InterventionController().ChooseEntity().Date;
            });

            UnitCommand = new RelayCommand(() =>
            {
                Unit = new UnitController().ChooseEntity();
            });

            TypeCommand = new RelayCommand(() =>
            {
                Type = new TypeController().ChooseEntity();
            });
        }

        public override bool SaveFields()
        {
            Entity.Title = Title;
            Entity.Description = Description;
            Entity.Date = Date;
            Entity.Type = Type;
            Entity.Unit = Unit;

            return true;
        }

        public override void ResetFields()
        {
            Title = Entity.Title;
            Description = Entity.Description;
            Date = Entity.Date;
            Type = Entity.Type;
            Unit = Entity.Unit;
        }
    }
}
