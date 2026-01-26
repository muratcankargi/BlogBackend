namespace BlogBackend.Services.DTO
{
    public record CreateBlogRequestDTO(string Title, string Description);
    public record UpdateBlogRequest(int Id, string Title, string Description);
    public record ListBlogResponse(int Id, string Title, DateTime CreatedAt);
}
