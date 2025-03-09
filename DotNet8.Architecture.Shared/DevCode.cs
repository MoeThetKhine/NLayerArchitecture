﻿
using Newtonsoft.Json;

namespace DotNet8.Architecture.Shared
{
	public static class DevCode
	{
		public static string ToJson(this object obj) =>
			JsonConvert.SerializeObject(obj, Formatting.Indented);
	}
}
