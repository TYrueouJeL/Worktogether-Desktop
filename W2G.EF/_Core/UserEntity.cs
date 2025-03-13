using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Nodes;

namespace W2G.EF._Core
{
    public enum EUserKind
    {
        None     = 0,
        Customer = 1,
        User     = 2,
        Admin    = 3,
    }
    public class UserEntity : WtgEntity
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, PasswordPropertyText]
        public string Password { get; set; }
        public string Role { get; set; } = "[]";
        public string Discr {  get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // penser à implémenter le JSON
        }
    }
}
