using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ODataService.Modes;

namespace ODataService
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc(options => {
				options.EnableEndpointRouting = false;
			}).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
			services.AddOData();
			services.AddODataQueryFilter();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			var builder = new ODataConventionModelBuilder(app.ApplicationServices);
			builder.EntitySet<Product>("Products");

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();

			app.UseMvc(routeBuilder =>
			{
				// and this line to enable OData query option, for example $filter
				routeBuilder.Select().Expand().Filter().OrderBy().MaxTop(100).Count();
				routeBuilder.MapODataServiceRoute("ODataRoute", "odata", builder.GetEdmModel());
				// uncomment the following line to Work-around for #1175 in beta1
				routeBuilder.EnableDependencyInjection();
			});
		}
	}
}
