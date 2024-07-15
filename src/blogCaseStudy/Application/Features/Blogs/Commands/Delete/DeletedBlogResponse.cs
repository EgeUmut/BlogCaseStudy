using NArchitecture.Core.Application.Responses;

namespace Application.Features.Blogs.Commands.Delete;

public class DeletedBlogResponse : IResponse
{
    public int Id { get; set; }
}