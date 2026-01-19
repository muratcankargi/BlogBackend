using BlogBackend.Entities;
using BlogBackend.Repostories;
using BlogBackend.Repostories.Interfaces;
using BlogBackend.Services.DTO;
using BlogBackend.Validations;

namespace BlogBackend.Services
{
    public class BlogService
    {
        private readonly IBlogRepository _repository;
        public BlogService(IBlogRepository repository)
        {
            _repository = repository;
        }

        public Result Create(CreateBlogRequestDTO model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.Description))
                    throw new ArgumentNullException("description cannot be empty");
                Blog blog = new Blog(model.Title, model.Description);
                _repository.Create(blog);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        public Result<IReadOnlyList<ListBlogResponse>> GelAll()
        {
            try
            {
                var blogs = _repository.GetAll();

                return Result<IReadOnlyList<ListBlogResponse>>.Ok(
                    blogs
                    .Select(x => new ListBlogResponse(x.Id, x.Title, x.Description, x.CreatedAt, x.UpdatedAt))
                    .OrderBy(b => b.Id)
                   .ToList()
                );

            }
            catch (Exception ex)
            {
                return Result<IReadOnlyList<ListBlogResponse>>.Fail(ex.Message);
            }
        }

        public Result<Blog> GetById(int id)
        {
            try
            {
                var blog = _repository.GetById(id);

                if (blog == null)
                    return Result<Blog>.Fail("blog not found");

                return Result<Blog>.Ok(blog);

            }
            catch (Exception ex)
            {
                return Result<Blog>.Fail(ex.Message);
            }
        }

        public Result Delete(int id)
        {
            try
            {
                var blog = _repository.GetById(id);
                if (blog == null)
                    return Result<Blog>.Fail("blog not found");

                _repository.Delete(blog);
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        public Result<Blog> Update(UpdateBlogRequest request)
        {
            try
            {

                var blog = _repository.GetById(request.Id);
                if (blog == null)
                    return Result<Blog>.Fail("blog not found");

                blog.SetDescription(request.Description);
                blog.SetTitle(request.Title);

                _repository.Update(blog);
                return Result<Blog>.Ok(blog);
            }
            catch (Exception ex)
            {
                return Result<Blog>.Fail(ex.Message);
            }
        }
    }
}
