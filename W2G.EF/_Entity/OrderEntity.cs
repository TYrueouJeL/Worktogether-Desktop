using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace W2G.EF
{
    public class OrderEntity : WtgEntity
    {
        public override string Label => $"{User?.Label} : {Pack?.Label}";
        [Column("start_date")]
        public DateTime StartDate { get; set; }
        [Column("end_date")]
        public DateTime? EndDate { get; set; }
        [Column("is_annual")]
        public bool IsAnnual { get; set; }
        public int Duration { get; set; }
        public int Price { get; set; }
        [Column("customer_id")]
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; }
        [Column("pack_id")]
        public int PackId { get; set; }
        public virtual PackEntity Pack { get; set; }

        public IQueryable<CommandedUnitEntity> CommandedUnits(WtgContext context) => context.CommandedUnit.Where(item => item.OrderId == Id);

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderEntity>()
                .HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderEntity>()
                .HasOne(o => o.Pack)
                .WithMany()
                .HasForeignKey(e => e.PackId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
