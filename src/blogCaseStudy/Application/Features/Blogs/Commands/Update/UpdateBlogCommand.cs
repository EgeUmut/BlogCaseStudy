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
using Microsoft.AspNetCore.Http;
using Application.Services.ImageService;
using Application.Features.Users.Constants;

namespace Application.Features.Blogs.Commands.Update;

public class UpdateBlogCommand : IRequest<UpdatedBlogResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Context { get; set; }
    public IFormFile? File { get; set; }
    public Guid UserId { get; set; }

    public string[] Roles => [Admin, Write, BlogsOperationClaims.Update, UsersOperationClaims.UserRole];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBlogs"];

    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, UpdatedBlogResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _blogRepository;
        private readonly BlogBusinessRules _blogBusinessRules;
        private readonly ImageServiceBase _ýmageServiceBase;

        public UpdateBlogCommandHandler(IMapper mapper, IBlogRepository blogRepository,
                                         BlogBusinessRules blogBusinessRules, ImageServiceBase ýmageServiceBase)
        {
            _mapper = mapper;
            _blogRepository = blogRepository;
            _blogBusinessRules = blogBusinessRules;
            _ýmageServiceBase = ýmageServiceBase;
        }

        public async Task<UpdatedBlogResponse> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            Blog? blog = await _blogRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _blogBusinessRules.BlogShouldExistWhenSelected(blog);

            if(request.File != null)
            {
                blog.ImageUrl = await _ýmageServiceBase.UpdateAsync(request.File , blog.ImageUrl);
            }

            blog = _mapper.Map(request, blog);

            await _blogRepository.UpdateAsync(blog!);

            UpdatedBlogResponse response = _mapper.Map<UpdatedBlogResponse>(blog);
            return response;
        }
    }
}