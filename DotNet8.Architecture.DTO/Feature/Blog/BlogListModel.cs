using DotNet8.Architecture.DTO.Feature.PageSetting;

namespace DotNet8.Architecture.DTO.Feature.Blog
{
	#region BlogListModel

	public class BlogListModel
	{
		public IEnumerable<BlogModel> DataLst { get; set; }
		public PageSettingModel PageSetting { get; set; }
	}

	#endregion
}
