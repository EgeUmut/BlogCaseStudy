using Application.Features.Blogs.Commands.Create;
using Application.Features.Blogs.Commands.Delete;
using Application.Features.Blogs.Commands.Update;
using Application.Features.Blogs.Queries.GetById;
using Application.Features.Blogs.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Persistence.Dynamic;
using Application.Features.Blogs.Queries.Dynamic;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromForm] CreateBlogCommand createBlogCommand)
    {
        CreatedBlogResponse response = await Mediator.Send(createBlogCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromForm] UpdateBlogCommand updateBlogCommand)
    {
        UpdatedBlogResponse response = await Mediator.Send(updateBlogCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedBlogResponse response = await Mediator.Send(new DeleteBlogCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdBlogResponse response = await Mediator.Send(new GetByIdBlogQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBlogQuery getListBlogQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListBlogListItemDto> response = await Mediator.Send(getListBlogQuery);
        return Ok(response);
    }

    [HttpPost("dynamic")]
    public async Task<IActionResult> GetListDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery dynamic )
    {
        GetListBlogDynamicQuery getListBlogQuery = new() { PageRequest = pageRequest , Dynamic = dynamic};
        GetListResponse<GetListBlogListItemDto> response = await Mediator.Send(getListBlogQuery);
        return Ok(response);
    }
}