using System.Windows;
using W2G.EF;
using W2G.WPF.Core;

namespace W2G.WPF
{
    public class StateController : EntityController<StateEntity>
    {
        public StateController()
        {
        }

        public override IBoardControl<StateEntity> GetBoard(EBoardMode mode, string search)
        {
            return new StateBoard(mode, search);
        }

        public override IFormControl<StateEntity> GetForm(EFormMode mode, StateEntity entity = null)
        {
            return new StateForm(mode, entity ?? new StateEntity());
        }

        public override EntityPresentation<StateEntity> GetPresentedEntity(StateEntity entity)
        {
            return new StatePresentation(this, entity);
        }

        public override bool DestroyEntity(StateEntity entity)
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

        public IQueryable<UnitEntity>? GetUnits(StateEntity entity)
            => entity.Units(Context);
    }
}
