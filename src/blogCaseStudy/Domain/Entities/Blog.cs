using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Blog : Entity<int>
{
    public string Title { get; set; }
    public string Context { get; set; }
    public string ImageUrl { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }

    public Blog(string title, string context, string ımageUrl, Guid userId, User user, ICollection<Comment> comments)
    {
        Title = title;
        Context = context;
        ImageUrl = ımageUrl;
        UserId = userId;
        User = user;
        Comments = comments;
    }

    public Blog()
    {
        
    }
}
