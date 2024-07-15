using Application.Features.Blogs.Constants;
using Application.Features.Blogs.Constants;
using Application.Features.Blogs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Blogs.Constants.BlogsOperationClaims;
using Application.Features.Users.Constants;

namespace Application.Features.Blogs.Commands.Delete;

public class DeleteBlogCommand : IRequest<DeletedBlogResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, BlogsOperationClaims.Delete, UsersOperationClaims.UserRole];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBlogs"];

    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, DeletedBlogResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _blogRepository;
        private readonly BlogBusinessRules _blogBusinessRules;

        public DeleteBlogCommandHandler(IMapper mapper, IBlogRepository blogRepository,
                                         BlogBusinessRules blogBusinessRules)
        {
            _mapper = mapper;
            _blogRepository = blogRepository;
            _blogBusinessRules = blogBusinessRules;
        }

        public async Task<DeletedBlogResponse> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            Blog? blog = await _blogRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _blogBusinessRules.BlogShouldExistWhenSelected(blog);

            await _blogRepository.DeleteAsync(blog!, permanent: true);

            DeletedBlogResponse response = _mapper.Map<DeletedBlogResponse>(blog);
            return response;
        }
    }
}