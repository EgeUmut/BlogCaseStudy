using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Comments.Queries.GetList;

public class GetListCommentListItemDto : IDto
{
    public int Id { get; set; }
    public string Context { get; set; }
    public Guid UserId { get; set; }
    public string UserUserName { get; set; }
    public int BlogId { get; set; }
    public DateTime CreatedDate { get; set; }
    public string BlogTitle { get; set; }
}