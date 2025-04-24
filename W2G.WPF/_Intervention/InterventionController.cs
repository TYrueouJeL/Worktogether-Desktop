using W2G.EF;
using W2G.WPF.Core;

namespace W2G.WPF
{
    public class InterventionController : EntityController<InterventionEntity>
    {
        public InterventionController()
        {
        }
        public override IBoardControl<InterventionEntity> GetBoard(EBoardMode mode, string search)
        {
            return new InterventionBoard(mode, search);
        }
        public override IFormControl<InterventionEntity> GetForm(EFormMode mode, InterventionEntity entity = null)
        {
            return new InterventionForm(mode, entity ?? new InterventionEntity());
        }
        public override EntityPresentation<InterventionEntity> GetPresentedEntity(InterventionEntity entity)
        {
            return new InterventionPresentation(this, entity);
        }
    }
}
