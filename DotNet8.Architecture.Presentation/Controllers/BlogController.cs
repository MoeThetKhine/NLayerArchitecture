﻿using DotNet8.Architecture.DTO.Feature.Blog;

namespace DotNet8.Architecture.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogController : BaseController
{
	private readonly BL_Blog _bL_Blog;

	public BlogController(BL_Blog bL_Blog)
	{
		_bL_Blog = bL_Blog;
	}

	#region GetBlogAsync

	[HttpGet]
	public async Task<IActionResult> GetBlogAsync(int pageNo, int pageSize, CancellationToken cancellationToken)
	{
		var result = await _bL_Blog.GetBlogAsync(pageNo, pageSize, cancellationToken);
		return Content(result);
	}

	#endregion

	#region GetBlogByIdAsync

	[HttpGet("{id}")]

	public async Task<IActionResult> GetBlogByIdAsync(int id, CancellationToken cancellationToken)
	{
		var result = await _bL_Blog.GetBlogByIdAsync(id, cancellationToken);
		return Content(result);
	}

	#endregion

	[HttpPost]
	public async Task<IActionResult> CreateBlogAsync([FromBody] BlogRequestModel blogRequestModel, CancellationToken cancellationToken)
	{
		var result = await _bL_Blog.AddBlogAsync(blogRequestModel, cancellationToken);
		return Content(result);
	}

}
