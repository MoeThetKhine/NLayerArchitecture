using DotNet8.Architecture.DbService.AppDbContextModels;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.Architecture.Presentation.Extension
{
	public  static class DependencyInjection
	{

		private static IServiceCollection AddDbContextService(this IServiceCollection services, WebApplicationBuilder builder)
		{
			builder.Services.AddDbContext<AppDbContext>(opt =>
			{
				opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
				opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
			},
			ServiceLifetime.Transient
			);

			return services;
		}
	}
}
