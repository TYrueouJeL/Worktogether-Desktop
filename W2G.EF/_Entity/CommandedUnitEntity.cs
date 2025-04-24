using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace W2G.EF
{
    [Table("commanded_unit")]
    public class CommandedUnitEntity : WtgEntity
    {
        public override string Label => $"{Order?.Label} : {Unit?.Label}";

        [Column("orders_id")]
        public int OrderId { get; set; }
        public virtual OrderEntity Order { get; set; }

        [Column("unit_id")]
        public int UnitId { get; set; }
        public virtual UnitEntity Unit { get; set; }

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
