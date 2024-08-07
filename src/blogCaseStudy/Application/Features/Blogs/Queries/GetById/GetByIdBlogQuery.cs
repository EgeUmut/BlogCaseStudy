using Application.Features.Blogs.Constants;
using Application.Features.Blogs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Blogs.Constants.BlogsOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Blogs.Queries.GetById;

public class GetByIdBlogQuery : IRequest<GetByIdBlogResponse>//, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdBlogQueryHandler : IRequestHandler<GetByIdBlogQuery, GetByIdBlogResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _blogRepository;
        private readonly BlogBusinessRules _blogBusinessRules;

        public GetByIdBlogQueryHandler(IMapper mapper, IBlogRepository blogRepository, BlogBusinessRules blogBusinessRules)
        {
            _mapper = mapper;
            _blogRepository = blogRepository;
            _blogBusinessRules = blogBusinessRules;
        }

        public async Task<GetByIdBlogResponse> Handle(GetByIdBlogQuery request, CancellationToken cancellationToken)
        {
            Blog? blog = await _blogRepository.GetAsync(
                predicate: b => b.Id == request.Id,
                cancellationToken: cancellationToken,
                include:p=>p.Include(p=>p.User)
                
                );
            await _blogBusinessRules.BlogShouldExistWhenSelected(blog);

            GetByIdBlogResponse response = _mapper.Map<GetByIdBlogResponse>(blog);
            return response;
        }
    }
}