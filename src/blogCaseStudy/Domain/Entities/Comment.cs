using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Comment:Entity<int>
{
    public string Context { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    public int BlogId { get; set; }
    public virtual Blog Blog { get; set; }

    public Comment(string context, Guid userId, User user, int blogId, Blog blog)
    {
        Context = context;
        UserId = userId;
        User = user;
        BlogId = blogId;
        Blog = blog;
    }

    public Comment()
    {
        
    }
}
