using System.Windows;
using W2G.EF;
using W2G.WPF.Core;

namespace W2G.WPF
{
    public class BayController : EntityController<BayEntity>
    {
        public BayController()
        {
        }

        public override IBoardControl<BayEntity> GetBoard(EBoardMode mode, string search)
        {
            return new BayBoard(this, mode, search);
        }

        public override IFormControl<BayEntity> GetForm(EFormMode mode, BayEntity entity = null)
        {
            return new BayForm(this, mode, entity ?? new BayEntity());
        }

        public override EntityPresentation<BayEntity> GetPresentedEntity(BayEntity entity)
        {
            return new BayPresentation(this, entity);
        }

        public override bool DestroyEntity(BayEntity entity)
        {
            #region Check Bay
            IQueryable<UnitEntity>? list = GetUnits(entity);

            if (list.Count() > 0)
            {
                MessageBox.Show("Impossible de supprimer la baie car elle contient des unités");
                return false;
            }
            #endregion

            return base.DestroyEntity(entity);
        }

        public IQueryable<UnitEntity> GetUnits(BayEntity entity)
            => entity.Units(Context);
    }
}
