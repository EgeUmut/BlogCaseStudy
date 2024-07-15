using FluentValidation;

namespace Application.Features.Blogs.Commands.Create;

public class CreateBlogCommandValidator : AbstractValidator<CreateBlogCommand>
{
    public CreateBlogCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Context).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
    }
}