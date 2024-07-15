using Application.Features.Blogs.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Blogs.Queries.Dynamic;
public class GetListBlogDynamicQuery : IRequest<GetListResponse<GetListBlogListItemDto>>//, ISecuredRequest//, ICachableRequest
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery Dynamic { get; set; }

    //public string[] Roles => [Admin, Read];

    //public bool BypassCache { get; }
    //public string? CacheKey => $"GetListBlogsDynamic({PageRequest.PageIndex},{PageRequest.PageSize})";
    //public string? CacheGroupKey => "GetBlogs";
    //public TimeSpan? SlidingExpiration { get; }

    public class GetListBlogDynamicQueryHandler : IRequestHandler<GetListBlogDynamicQuery, GetListResponse<GetListBlogListItemDto>>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public GetListBlogDynamicQueryHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBlogListItemDto>> Handle(GetListBlogDynamicQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Blog> blogs = await _blogRepository.GetListByDynamicAsync(
                request.Dynamic,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken,
                include: p => p.Include(p => p.User)
                );

            GetListResponse<GetListBlogListItemDto> response = _mapper.Map<GetListResponse<GetListBlogListItemDto>>(blogs);
            return response;
        }
    }
}
