namespace BlogBackend.Services
{
    public record CreateBlogRequestDTO(string Description);

    public record ListBlogResponse(int Id, string Desciption, DateTime CreatedAt);

    public record UpdateBlogRequest(int Id, string Description);
}
