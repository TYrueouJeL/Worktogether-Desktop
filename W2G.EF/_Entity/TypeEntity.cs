using Microsoft.EntityFrameworkCore;

namespace W2G.EF
{
    public class TypeEntity : WtgEntity
    {
        public override string Label => Type;
        public string Type { get; set; }

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //throw new NotImplementedException();
        }
    }
}
