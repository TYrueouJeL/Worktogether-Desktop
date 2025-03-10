using Microsoft.EntityFrameworkCore;

namespace W2G.EF._Core
{
    public class OrderEntity : WtgEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsAnnual { get; set; }
        public int Duration { get; set; }
        public int Price { get; set; }

        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public int PackId { get; set; }
        public PackEntity Pack { get; set; }

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
