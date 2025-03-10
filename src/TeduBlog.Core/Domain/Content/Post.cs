using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TeduBlog.Core.Domain.Content
{
    [Table("Posts")]
    [Index(nameof(Slug), IsUnique = true)]
    public class Post
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(250)]
        [Required]
        public required string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(250)")]
        public required string Slug { get; set; } //Đường dẫn thân thiện

        [MaxLength(500)]
        public string? Description { get; set; }

        
        [Required]
        public Guid CategoryId { get; set; }

        [MaxLength(500)]
        public string? Thumbnail { get; set; } //Hình ảnh đại diện

        public string? Content { get; set; }

        [MaxLength(250)]
        public Guid AuthorUserId { get; set; }

        [MaxLength(250)]
        public string? Source { get; set; }

        [MaxLength(250)]
        public string? Tag { get; set; }

        [MaxLength(160)]
        public string? SeoDescription { get; set; }

        public int ViewCount { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsPaid { get; set; }
        public decimal RoyaltyAmount { get; set; } //Tiền hoa hồng
        public PostStatus Status { get; set; }
    }
    public enum PostStatus
    {
        Draft = 1,
        Canceled = 2,
        WaitingForApproval = 3,
        Rejected = 4,
        WaitingForPublic = 5,
        Published = 6,
    }
}
