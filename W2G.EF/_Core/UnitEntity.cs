using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace W2G.EF._Core
{
    public class UnitEntity : WtgEntity
    {
        [Required]
        public string Reference { get; set; }

        public int StateId { get; set; }
        public StateEntity State { get; set; }
        public int BayId { get; set; }
        public BayEntity Bay { get; set; }
        public int UsageId { get; set; }
        public UsageEntity Usage { get; set; }

        public ICollection<InterventionEntity> Interventions { get; set; } = new List<InterventionEntity>();
        public ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UnitEntity>()
                .HasOne(u => u.Bay)
                .WithMany()
                .HasForeignKey(e => e.BayId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UnitEntity>()
                .HasOne(u => u.Usage)
                .WithMany()
                .HasForeignKey(e => e.UsageId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UnitEntity>()
                .HasOne(u => u.State)
                .WithMany()
                .HasForeignKey(e => e.StateId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public static IQueryable<UnitEntity> Source(WtgContext context)
        {
            return context.Unit
                .Include(unit => unit.Bay)
                .Include(unit => unit.Reference);
        }
    }
}
