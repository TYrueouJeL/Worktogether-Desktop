using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        [EnumDataType(typeof(EUserKind))]
        public EUserKind Kind { get; set; }
        [Required]
        public string Login { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, PasswordPropertyText]
        public string Password { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public string Role { get; set; }

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().Property(e => e.Login);
        }
    }
}
