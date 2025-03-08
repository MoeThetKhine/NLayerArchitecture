using DotNet8.Architecture.DTO.Feature.PageSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
