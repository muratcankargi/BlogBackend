using BlogBackend.Services;
using BlogBackend.Services.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace BlogBackend.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BlogService _service;
        public BlogController(BlogService service)
        {
            _service = service;
        }
        [EnableRateLimiting("fixed")]
        [HttpGet]
        public async Task<ActionResult<Result>> GetAllBlogs()
        {
            var blogs = await _service.GetAll();
            return Ok(blogs);
        }

        [HttpPost]
        public IActionResult CreateBlog(CreateBlogRequestDTO request)
        {
            var result = _service.Create(request);
            if (!result.Success)
                BadRequest(result.Message);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<Result> GetBlogById([FromRoute] int id)
        {
            var result = _service.GetById(id);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPut]
        public ActionResult<Result> UpdateBlog([FromBody] UpdateBlogRequest request)
        {
            var result = _service.Update(request);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteBlog(int id)
        {
            var result = _service.Delete(id);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result);
        }
    }
}
