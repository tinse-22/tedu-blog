using TeduBlog.Core.Domain.Content;
using TeduBlog.Core.SeedWorks;

namespace TeduBlog.Core.Repositories
{
    public interface IPostRepository : IRepository<Post, Guid>
    {
        Task<IEnumerable<Post>> GetPopularPostsAsync(int count);
    }
}
