﻿namespace DotNet8.Architecture.DataAccess.Features.Blog;

public class DA_Blog
{
	private readonly AppDbContext _context;

	public DA_Blog(AppDbContext context)
	{
		_context = context;
	}

	#region GetBlogsAsync

	public async Task<Result<BlogListModel>> GetBlogsAsync(int pageNo, int pageSize, CancellationToken cancellationToken)
	{
		Result<BlogListModel> response;

		try
		{
			var query = _context.TblBlogs.OrderByDescending(x => x.BlogId);
			var lst = await query
				.Skip((pageNo - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync(cancellationToken);

			var totalCount = await query.CountAsync(cancellationToken);
			var pageCount = totalCount / pageSize;

			if (totalCount % pageSize > 0)
			{
				pageCount++;
			}

			var pageSettingModel = new PageSettingModel(pageNo, pageSize, pageCount, totalCount);
			response = Result<BlogListModel>.Success(
			new BlogListModel
			{
				DataLst = lst.Select(x => x.ToModel()),
				PageSetting = pageSettingModel
			});

		}
		catch (Exception ex)
		{
			response = Result<BlogListModel>.Failure(ex);
		}
		return response;
	}

	#endregion

	#region GetBlogByIdAsync

	public async Task<Result<BlogModel>> GetBlogByIdAsync(int id, CancellationToken cancellationToken)
	{
		Result<BlogModel> response;

		try
		{
			var blog = await _context.TblBlogs.FindAsync([id], cancellationToken: cancellationToken);

			if(blog is null)
			{
				response = Result<BlogModel>.NotFound("Blog Not Found");
				goto result;
			}
			response = Result<BlogModel>.Success(blog.ToModel());
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
