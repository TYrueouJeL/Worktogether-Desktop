using W2G.EF;
using W2G.WPF.Core;

namespace W2G.WPF
{
    public class TypeController : EntityController<TypeEntity>
    {
        public TypeController()
        {

        }

        public override IBoardControl<TypeEntity> GetBoard(EBoardMode mode, string search)
        {
            return new TypeBoard(mode, search);
        }

        public override IFormControl<TypeEntity> GetForm(EFormMode mode, TypeEntity entity = null)
        {
            return new TypeForm(mode, entity ?? new TypeEntity());
        }

        public override EntityPresentation<TypeEntity> GetPresentedEntity(TypeEntity entity)
        {
            return new TypePresentation(this, entity);
        }
    }
}
