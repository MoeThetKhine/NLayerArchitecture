namespace DotNet8.Architecture.BusinessLogic.Features.Blog;

public class BL_Blog
{
	private readonly DA_Blog _dA_Blog;
	private readonly BlogValidator _blogValidator;

	public BL_Blog(DA_Blog dA_Blog, BlogValidator blogValidator)
	{
		_dA_Blog = dA_Blog;
		_blogValidator = blogValidator;
	}

	#region GetBlogAsync

	public async Task<Result<BlogListModel>> GetBlogAsync(int pageNo, int pageSize, CancellationToken cancellationToken)
	{
		Result<BlogListModel> response;

		try
		{
			if(pageNo <= 0)
			{
				response = Result<BlogListModel>.Fail(MessageResource.InvalidPageNo);
				goto result;
			}

			if(pageSize <= 0)
			{
				response = Result<BlogListModel>.Fail(MessageResource.InvalidPageSize);
				goto result;
			}

			response = await _dA_Blog.GetBlogsAsync(pageNo, pageSize, cancellationToken);
		}
		catch (Exception ex)
		{
			response = Result<BlogListModel>.Failure(ex);
		}
	result:
		return response;
	}

	#endregion

	#region GetBlogByIdAsync

	public async Task<Result<BlogModel>> GetBlogByIdAsync(int id, CancellationToken cancellationToken)
	{
		Result<BlogModel> response;

		try
		{
			if(id <= 0)
			{
				response = Result<BlogModel>.Fail(MessageResource.InvalidId);
				goto result;
			}

			response = await _dA_Blog.GetBlogByIdAsync(id, cancellationToken);
		}
		catch(Exception ex)
		{
			response = Result<BlogModel>.Failure(ex);
		}

		result:
		return response;
	}

	#endregion

	#region AddBlogAsync

	public async Task<Result<BlogModel>> AddBlogAsync(BlogRequestModel blogRequestModel, CancellationToken cancellationToken)
	{
		Result<BlogModel> response;

		try
		{
			var validationResult = await _blogValidator.ValidateAsync(blogRequestModel);
			if (!validationResult.IsValid)
			{
				string errors = string.Join("", validationResult.Errors.Select(x => x.ErrorMessage));
				response = Result<BlogModel>.Fail($"Error: {errors}");
				goto result;
			}

			response = await _dA_Blog.AddBlogAsync(blogRequestModel, cancellationToken);	
		}
		catch(Exception ex)
		{
			response = Result<BlogModel>.Failure(ex);
		}
		result:
		return response;
	}

	#endregion

	#region UpdateBlogAsync

	public async Task<Result<BlogModel>> UpdateBlogAsync(BlogRequestModel blogRequestModel, int id,  CancellationToken cancellationToken)
	{
		Result<BlogModel> response;

		try
		{
			var validationResult = await _blogValidator.ValidateAsync(blogRequestModel);
			if (!validationResult.IsValid)
			{
				string errors = string.Join("", validationResult.Errors.Select(x => x.ErrorMessage));
				response = Result<BlogModel>.Fail(errors);
				goto result;
			}

			if (id <= 0)
			{
				response = Result<BlogModel>.Fail(MessageResource.InvalidId);
				goto result;
			}

			response = await _dA_Blog.UpdateBlogAsyn(blogRequestModel,id, cancellationToken);
		}
		catch(Exception ex)
		{
			response = Result<BlogModel>.Failure(ex);
		}
		result:
		return response;
	}

	#endregion

}
