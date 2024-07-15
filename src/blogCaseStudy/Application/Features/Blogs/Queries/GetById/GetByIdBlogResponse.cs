using NArchitecture.Core.Application.Responses;

namespace Application.Features.Blogs.Queries.GetById;

public class GetByIdBlogResponse : IResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Context { get; set; }
    public string ImageUrl { get; set; }
    public Guid UserId { get; set; }
    public string UserUserName { get; set; }
    public DateTime CreatedDate { get; set; }
}