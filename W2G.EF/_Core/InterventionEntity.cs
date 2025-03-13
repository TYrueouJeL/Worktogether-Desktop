using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W2G.EF._Core
{
    public class InterventionEntity : WtgEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [Column("type_id")]
        public int TypeId { get; set; }
        public TypeEntity Type { get; set; }
        [Column("user_id")]
        public int UnitId { get; set; }
        public UnitEntity Unit { get; set; }

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
