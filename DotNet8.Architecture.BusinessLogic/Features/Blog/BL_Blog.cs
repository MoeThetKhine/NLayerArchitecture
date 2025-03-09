using DotNet8.Architecture.DataAccess.Features.Blog;
using DotNet8.Architecture.Shared;

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






}
