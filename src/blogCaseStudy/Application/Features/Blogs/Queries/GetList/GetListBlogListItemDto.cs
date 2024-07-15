using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Blogs.Queries.GetList;

public class GetListBlogListItemDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Context { get; set; }
    public string ImageUrl { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedDate { get; set; }
    public string UserUserName { get; set; }

}