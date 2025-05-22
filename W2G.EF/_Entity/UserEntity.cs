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
        public UserRole Role { get; set; } = UserRole.Client;
        public string Discr { get; set; } = "customer";
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }

        public string FullName => $"{FirstName} {LastName?.ToUpperInvariant()}";

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // penser à implémenter le JSON
        }
    }

    public enum UserRole
    {
        Client = 1,
        Comptable = 2,
        Technicien = 3,
        Administrateur = 4,
    }
}
