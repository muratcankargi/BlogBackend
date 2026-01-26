using BlogBackend.Entities;
using BlogBackend.Services.DTO;

namespace BlogBackend.Repostories.Interfaces
{
    public interface IBlogRepository : IRepository<Blog>
    {
        Task<List<ListBlogResponse>> GetAllBlogList();

    }
}
