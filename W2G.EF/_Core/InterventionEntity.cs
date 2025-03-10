using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W2G.EF._Core
{
    public class InterventionEntity : WtgEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public int TypeId { get; set; }
        public TypeEntity Type { get; set; }
        public int UnitId { get; set; }
        public UnitEntity Unit { get; set; }

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
