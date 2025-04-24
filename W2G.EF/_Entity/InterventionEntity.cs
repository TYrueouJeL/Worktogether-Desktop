using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace W2G.EF
{
    public class InterventionEntity : WtgEntity
    {
        public override string Label => Title;
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        [Column("type_id")]
        public int TypeId { get; set; }
        public virtual TypeEntity Type { get; set; }
        [Column("unit_id")]
        public int UnitId { get; set; }
        public virtual UnitEntity Unit { get; set; }

        public IQueryable<UnitEntity> Units(WtgContext context) => context.Unit.Where(item => item.Id == UnitId);

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InterventionEntity>()
                .HasOne(i => i.Type)
                .WithMany()
                .HasForeignKey(e => e.TypeId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<InterventionEntity>()
                .HasOne(i => i.Unit)
                .WithMany()
                .HasForeignKey(e => e.UnitId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
