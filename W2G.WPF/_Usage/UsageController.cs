using System.Windows;
using W2G.EF;
using W2G.WPF.Core;

namespace W2G.WPF
{
    public class UsageController : EntityController<UsageEntity>
    {
        public UsageController()
        {
        }
        public override IBoardControl<UsageEntity> GetBoard(EBoardMode mode, string search)
        {
            return new UsageBoard(mode, search);
        }
        public override IFormControl<UsageEntity> GetForm(EFormMode mode, UsageEntity entity = null)
        {
            return new UsageForm(mode, entity ?? new UsageEntity());
        }
        public override EntityPresentation<UsageEntity> GetPresentedEntity(UsageEntity entity)
        {
            return new UsagePresentation(this, entity);
        }

        public override bool DestroyEntity(UsageEntity entity)
        {
            #region Check Unit
            IQueryable<UnitEntity>? list = GetUnits(entity);
            if (list.Count() > 0)
            {
                MessageBox.Show("Impossible de supprimer l'état car il est utilisé par une ou plusieurs unités");
                return false;
            }
            #endregion

            return base.DestroyEntity(entity);
        }

        public IQueryable<UnitEntity> GetUnits(UsageEntity entity)
            => entity.Units(Context);
    }
}
