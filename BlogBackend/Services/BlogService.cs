using BlogBackend.Entities;
using BlogBackend.Repostories;
using BlogBackend.Repostories.Interfaces;
using BlogBackend.Services.DTO;
using BlogBackend.Validations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Metadata;

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

        public async Task<Result<List<ListBlogResponse>>> GetAll()
        {
            try
            {
                var blogs = await _repository.GetAllBlogList();

                if (blogs == null)
                    return Result<List<ListBlogResponse>>.Fail("blogs not found");

                return Result<List<ListBlogResponse>>.Ok(
                    blogs
                );
            }
            catch (Exception ex)
            {
                return Result<List<ListBlogResponse>>.Fail(ex.Message);
            }
        }


        public async Task<Result<Blog>> GetById(int id)
        {
            try
            {
                var blog = await _repository.GetById(id);

                if (blog == null)
                    return Result<Blog>.Fail("blog not found");

                return Result<Blog>.Ok(blog);

            }
            catch (Exception ex)
            {
                return Result<Blog>.Fail(ex.Message);
            }
        }

        public async Task<Result> Delete(int id)
        {
            try
            {
                var blog = await _repository.GetById(id);
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

        //public async Task<Result> SoftDelete(int id)
        //{
        //    try
        //    {
        //        var blog = await _repository.GetById(id);

        //        if (blog == null)
        //            return Result<Blog>.Fail("blog not found");

        //        //blog.SoftDelete();
        //        _repository.Update(blog);
        //        return Result.Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return Result.Fail(ex.Message);
        //    }
        //}


        public async Task<Result<Blog>> Update(UpdateBlogRequest request)
        {
            try
            {

                var blog = await _repository.GetById(request.Id);
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
