using Microsoft.EntityFrameworkCore;

namespace W2G.EF
{
    public class UsageEntity : WtgEntity
    {
        public override string Label => Type;
        public string Type { get; set; }
        public string Color { get; set; }

        public IQueryable<UnitEntity> Units(WtgContext context) => context.Unit.Where(item => item.UsageId == Id);

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //throw new NotImplementedException();
        }
    }
}
