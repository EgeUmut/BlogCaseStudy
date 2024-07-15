using Application.Features.Blogs.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Blogs.Constants.BlogsOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Blogs.Queries.GetList;

public class GetListBlogQuery : IRequest<GetListResponse<GetListBlogListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListBlogs({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetBlogs";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListBlogQueryHandler : IRequestHandler<GetListBlogQuery, GetListResponse<GetListBlogListItemDto>>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public GetListBlogQueryHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBlogListItemDto>> Handle(GetListBlogQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Blog> blogs = await _blogRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken,
                include: p=>p.Include(p=>p.User)
            );

            GetListResponse<GetListBlogListItemDto> response = _mapper.Map<GetListResponse<GetListBlogListItemDto>>(blogs);
            return response;
        }
    }
}