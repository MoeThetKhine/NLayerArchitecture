using DotNet8.Architecture.DbService.AppDbContextModels;

namespace DotNet8.Architecture.DataAccess.Features.Blog;

public class DA_Blog
{
	private readonly AppDbContext _context;

	public DA_Blog(AppDbContext context)
	{
		_context = context;
	}

	public async Task<Result<>>
}
