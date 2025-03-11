using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeduBlog.Core.Domain.Content;
using TeduBlog.Core.Repositories;
using TeduBlog.Core.SeedWorks;
using TeduBlog.Data.SeedWorks;

namespace TeduBlog.Data.Repositories
{
    public class PostRepository : RepositoryBase<Post, Guid>, IPostRepository
    {
       // private readonly TeduBlogContext _context; k cần khai báo khi thằng cho để protected
        public PostRepository(TeduBlogContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Post>> GetPopularPostsAsync(int count)
        {
            return await _context.Posts.OrderByDescending(x => x.ViewCount).Take(count).ToListAsync();
        }
    }
}
