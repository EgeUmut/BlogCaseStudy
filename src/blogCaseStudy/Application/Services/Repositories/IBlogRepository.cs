using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBlogRepository : IAsyncRepository<Blog, int>, IRepository<Blog, int>
{
}