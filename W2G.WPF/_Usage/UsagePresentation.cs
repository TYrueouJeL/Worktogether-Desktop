using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using W2G.WPF.Core;
using W2G.EF;

namespace W2G.WPF
{
    internal class UsagePresentation : EntityPresentation<UsageEntity>
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
                ValidateType(this, _Type);
            }
        }

        private void ValidateType(UsagePresentation usage, string type)
        {
            if (string.IsNullOrWhiteSpace(type))
                usage.AddError(nameof(Type), "Veuillez indiquer un type d'utilisation");
            else
                usage.ClearErrors(nameof(Type));
        }

        public ICommand TypeCommand { get; }
        #endregion

        #region Color
        private string _Color;
        public string Color
        {
            get { return _Color; }
            set
            {
                _Color = value;
                ClearAndNotify();
                ValidateColor(this, _Color);
            }
        }

        private void ValidateColor(UsagePresentation usage, string color)
        {
            if (string.IsNullOrWhiteSpace(color))
                usage.AddError(nameof(Color), "Veuillez indiquer une couleur");
            else
                usage.ClearErrors(nameof(Color));
        }

        public ICommand ColorCommand { get; }
        #endregion
        public UsagePresentation(UsageController controller, UsageEntity entity) : base(controller, entity)
        {
            TypeCommand = new RelayCommand(() =>
            {
                Type = new UsageController().ChooseEntity().Type;
            });

            ColorCommand = new RelayCommand(() =>
            {
                Color = new UsageController().ChooseEntity().Color;
            });
        }

        public override bool SaveFields()
        {
            Entity.Type = Type;
            Entity.Color = Color;
            return true;
        }

        public override void ResetFields()
        {
            Type = Entity.Type;
            Color = Entity.Color;
        }
    }
}
