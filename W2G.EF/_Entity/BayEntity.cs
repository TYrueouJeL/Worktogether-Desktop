using Microsoft.EntityFrameworkCore;

namespace W2G.EF
{
    public class BayEntity : WtgEntity, IReferenceEntity
    {
        public override string Label => Reference;
        public string Reference { get; set; }

        public IQueryable<UnitEntity> Units(WtgContext context) => context.Unit.Where(item => item.BayId == Id);

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //throw new NotImplementedException();
        }
    }
}
