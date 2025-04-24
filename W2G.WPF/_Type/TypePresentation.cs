using System.Windows.Input;
using W2G.WPF.Core;
using W2G.EF;
using CommunityToolkit.Mvvm.Input;

namespace W2G.WPF
{
    internal class TypePresentation : EntityPresentation<TypeEntity>
    {
        #region Type
        private string _Type;
        public string Type
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
            if (string.IsNullOrEmpty(_Type))
                AddError(nameof(Type), "Veuillez indiquer un type");
        }

        public ICommand TypeCommand { get; }
        #endregion

        public TypePresentation(TypeController controller, TypeEntity entity) : base(controller, entity)
        {
            TypeCommand = new RelayCommand(() =>
            {
                Type = new TypeController().ChooseEntity().Type;
            });
        }

        public override bool SaveFields()
        {
            Entity.Type = Type;
            return true;
        }

        public override void ResetFields()
        {
            Type = Entity.Type;
        }
    }
}
