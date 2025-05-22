using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace W2G.EF
{
    public class UnitEntity : WtgEntity, IReferenceEntity
    {
        public override string Label => Reference;
        [Required]
        public string Reference { get; set; }

        [Column("state_id")]
        public int StateId { get; set; }
        public virtual StateEntity State { get; set; }

        [Column("bay_id")]
        public int BayId { get; set; }
        public virtual BayEntity Bay { get; set; }
        
        [Column("usage_id")]
        public int UsageId { get; set; }
        public virtual UsageEntity Usage { get; set; }

        public IQueryable<InterventionEntity> Interventions(WtgContext context) => context.Intervention.Where(item => item.UnitId == Id);
        public IQueryable<CommandedUnitEntity> CommandedUnits(WtgContext context) => context.CommandedUnit.Where(item => item.UnitId == Id);

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
