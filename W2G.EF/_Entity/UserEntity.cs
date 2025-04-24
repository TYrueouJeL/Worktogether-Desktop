using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace W2G.EF
{
    public class UserEntity : WtgEntity
    {
        public override string Label => Email;
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, PasswordPropertyText]
        public string Password { get; set; }
        public int Role { get; set; }
        public string Discr { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }

        public string FullName => $"{FirstName} {LastName.ToUpperInvariant()}";

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // penser à implémenter le JSON
        }
    }
}
