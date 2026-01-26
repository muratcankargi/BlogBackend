using BlogBackend.AppContext;
using BlogBackend.Entities;
using BlogBackend.Repostories.Interfaces;
using BlogBackend.Services.DTO;
using Microsoft.EntityFrameworkCore;

namespace BlogBackend.Repostories
{
    public class BlogRepository : EFRepository<Blog>, IBlogRepository
    {
        public BlogRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<List<ListBlogResponse>> GetAllBlogList()
        {
            var blogs = await _dbContext.Blogs
                .OrderByDescending(b => b.CreatedAt)
                .Select(b => new ListBlogResponse(b.Id, b.Title, b.CreatedAt))
                .ToListAsync();
            return blogs;
        }
    }
}
