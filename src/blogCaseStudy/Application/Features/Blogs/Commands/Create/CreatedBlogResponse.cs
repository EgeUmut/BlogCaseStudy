using NArchitecture.Core.Application.Responses;

namespace Application.Features.Blogs.Commands.Create;

public class CreatedBlogResponse : IResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Context { get; set; }
    public string ImageUrl { get; set; }
    public Guid UserId { get; set; }
}