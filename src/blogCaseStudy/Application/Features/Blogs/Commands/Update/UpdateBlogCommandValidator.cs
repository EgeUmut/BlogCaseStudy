using FluentValidation;

namespace Application.Features.Blogs.Commands.Update;

public class UpdateBlogCommandValidator : AbstractValidator<UpdateBlogCommand>
{
    public UpdateBlogCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Context).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
    }
}