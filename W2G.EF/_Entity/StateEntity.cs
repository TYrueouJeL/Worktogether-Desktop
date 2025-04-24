using Microsoft.EntityFrameworkCore;

namespace W2G.EF
{
    public class StateEntity : WtgEntity
    {
        public override string Label => State;
        public string State { get; set; }

        public IQueryable<UnitEntity> Units(WtgContext context) => context.Unit.Where(item => item.StateId == Id);

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //throw new NotImplementedException();
        }
    }
}
