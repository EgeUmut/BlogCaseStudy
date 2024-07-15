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

namespace Application.Features.Blogs.Commands.Create;

public class CreateBlogCommand : IRequest<CreatedBlogResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Title { get; set; }
    public string Context { get; set; }
    public IFormFile File { get; set; }
    public Guid UserId { get; set; }

    public string[] Roles => [Admin, Write, BlogsOperationClaims.Create, UsersOperationClaims.UserRole];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBlogs"];

    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, CreatedBlogResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _blogRepository;
        private readonly BlogBusinessRules _blogBusinessRules;
        private readonly ImageServiceBase _ýmageServiceBase;

        public CreateBlogCommandHandler(IMapper mapper, IBlogRepository blogRepository,
                                         BlogBusinessRules blogBusinessRules, ImageServiceBase ýmageServiceBase)
        {
            _mapper = mapper;
            _blogRepository = blogRepository;
            _blogBusinessRules = blogBusinessRules;
            _ýmageServiceBase = ýmageServiceBase;
        }

        public async Task<CreatedBlogResponse> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            Blog blog = _mapper.Map<Blog>(request);
            blog.ImageUrl = await _ýmageServiceBase.UploadAsync(request.File);
            await _blogRepository.AddAsync(blog);

            CreatedBlogResponse response = _mapper.Map<CreatedBlogResponse>(blog);
            return response;
        }
    }
}