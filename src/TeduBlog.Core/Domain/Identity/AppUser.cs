using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TeduBlog.Core.Domain.Identity
{
    [Table("AppUsers")]
    public class AppUser : IdentityUser<Guid>
    {
        [Required]
        [MaxLength(100)]
        public required string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public required string LastName { get; set; }
        public bool IsActive { get; set; }
        public string? RefreshToken { get; set; } //Token dùng để refresh token
        public DateTime? RefreshTokenExpiryTime { get; set; } //Thời gian hết hạn của token
        public DateTime DateCreated { get; set; }
        public DateTime? Dob { get; set; }

        [MaxLength(500)]
        public string? Avatar { get; set; }
        public DateTime? VipStartDate { get; set; }
        public DateTime? VipExpireDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public double Balance { get; set; }
        public double RoyaltyAmountPerPost { get; set; }
        public string GetFullName()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
