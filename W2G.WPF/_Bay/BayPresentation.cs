using W2G.WPF.Core;
using W2G.EF;

namespace W2G.WPF
{
    internal class BayPresentation : EntityPresentation<BayEntity>
    {
        #region Reference
        private string _Reference;

        public string Reference
        {
            get { return _Reference; }
            set
            {
                _Reference = value;
                ClearAndNotify();
                ValidatorTools.ValidateReference(this, value);
            }
        }
        #endregion

        public int UnitsCount => Entity?.Units(Controller.Context)?.Count()??0;

        public BayPresentation(EntityController<BayEntity> controller, BayEntity entity) : base(controller, entity)
        {
        }

        public override void ResetFields()
        {
            Reference = Entity.Reference;
        }

        public override bool SaveFields()
        {
            Entity.Reference = Reference;

            return true;
        }
    }
}
