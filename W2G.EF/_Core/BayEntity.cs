using Microsoft.EntityFrameworkCore;

namespace W2G.EF._Core
{
    public class BayEntity : WtgEntity
    {
        public string Reference { get; set; }

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //throw new NotImplementedException();
        }
    }
}
