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

	[HttpGet("GetBlogs")]
	public async Task<IActionResult> GetBlogAsync(int pageNo, int pageSize, CancellationToken cancellationToken)
	{
		var result = await _bL_Blog.GetBlogAsync(pageNo, pageSize, cancellationToken);
		return Content(result);
	}

	#endregion

	#region GetBlogByIdAsync

	[HttpGet("GetBlogsById/{id}")]

	public async Task<IActionResult> GetBlogByIdAsync(int id, CancellationToken cancellationToken)
	{
		var result = await _bL_Blog.GetBlogByIdAsync(id, cancellationToken);
		return Content(result);
	}

	#endregion

	#region CreateBlogAsync

	[HttpPost("CreateBlog")]
	public async Task<IActionResult> CreateBlogAsync([FromBody] BlogRequestModel blogRequestModel, CancellationToken cancellationToken)
	{
		var result = await _bL_Blog.AddBlogAsync(blogRequestModel, cancellationToken);
		return Content(result);
	}

	#endregion

	#region UpdateBlogAsync

	[HttpPut("UpdateBlog/{id}")]
	public async Task<IActionResult> UpdateBlogAsync(BlogRequestModel blogRequest, int id ,CancellationToken cancellationToken)
	{
		var result = await _bL_Blog.UpdateBlogAsync(blogRequest, id, cancellationToken);
		return Content(result);
	}

	#endregion

	#region DeleteBlogAsync

	[HttpDelete("DeleteBlog/{id}")]
	public async Task<IActionResult> DeleteBlogAsync(int id, CancellationToken cancellationToken)
	{
		var result = await _bL_Blog.DeleteBlogAsync(id, cancellationToken);
		return Content(result);
	}

	#endregion

}
