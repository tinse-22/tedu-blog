using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TeduBlog.Core.Domain.Identity
{
    [Table("AppRoles")] 
    public class AppRole : IdentityRole<Guid> //Kiểu dữ liệu cho khóa chính
    {
        [Required]
        [MaxLength(250)]
        public string DisplayName { get; set; } // Add thêm DisplayName
    }
}
