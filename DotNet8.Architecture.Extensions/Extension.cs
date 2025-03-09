﻿using DotNet8.Architecture.DbService.AppDbContextModels;
using DotNet8.Architecture.DTO.Feature.Blog;

namespace DotNet8.Architecture.Extensions;

public static class Extension
{
	public static BlogModel ToModel(this TblBlog dataModel)
	{
		return new BlogModel
		{
			BlogId = dataModel.BlogId,
			BlogTitle = dataModel.BlogTitle,
			BlogAuthor = dataModel.BlogAuthor,
			BlogContent = dataModel.BlogContent,
		};
	}
}
