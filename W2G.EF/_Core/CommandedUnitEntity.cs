using Microsoft.EntityFrameworkCore;
using W2G.EF._Core;

namespace W2G.EF
{
    public class CommandedUnitEntity : WtgEntity
    {
        public int UnitId { get; set; }
        public UnitEntity Unit { get; set; }
        public int OrderId { get; set; }
        public OrderEntity Order { get; set; }

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommandedUnitEntity>()
                .HasOne(cu => cu.Unit)
                .WithMany()
                .HasForeignKey(e => e.UnitId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CommandedUnitEntity>()
                .HasOne(cu => cu.Order)
                .WithMany()
                .HasForeignKey(e => e.OrderId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
