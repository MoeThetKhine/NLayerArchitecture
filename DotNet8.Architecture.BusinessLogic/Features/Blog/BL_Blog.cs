using DotNet8.Architecture.DataAccess.Features.Blog;
using DotNet8.Architecture.DTO.Feature.Blog;
using DotNet8.Architecture.Shared;
using DotNet8.Architecture.Utils;
using DotNet8.Architecture.Utils.Resources;

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





}
