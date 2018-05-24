using Maksim.SearchUsingPredicates.Common;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Maksim.SearchUsingPredicates
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
            app.Run(async (context) => { await context.Response.WriteAsync("Hello World"); });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddJsonDataConection();
            services.AddNotebookService();
            services.AddPredicateParser();
            services.AddMvc();
        }
    }
}