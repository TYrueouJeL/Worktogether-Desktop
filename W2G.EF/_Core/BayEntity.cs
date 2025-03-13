using Microsoft.EntityFrameworkCore;

namespace W2G.EF._Core
{
    public class BayEntity : WtgEntity
    {
        public string Reference { get; set; }

        public IQueryable<UnitEntity> Units(WtgContext context) => context.Unit.Where(item => item.BayId == Id);

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //throw new NotImplementedException();
        }
    }
}
