using Maksim.SearchUsingPredicates.Dal;
using Maksim.SearchUsingPredicates.DAL;
using Maksim.SearchUsingPredicates.Interfaces;
using Maksim.SearchUsingPredicates.Services;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Maksim.SearchUsingPredicates.Common
{
    public static class ServiceExtensions
    {
        public static void AddNotebookService(this IServiceCollection services)
        {
            services.AddTransient<INotebookService, NotebookService>();
        }

        public static void AddPredicateParser(this IServiceCollection services)
        {
            services.AddTransient<IPredicateParser, PredicateParser>();
        }

        public static void AddEfDataConection(this IServiceCollection services)
        {
            services.AddDbContext<SearchContext>(
                options => options.UseSqlServer("DefaultConnection"));
        }

        public static void AddJsonDataConection(this IServiceCollection services)
        {
            services.AddTransient<IDataAccess, SearchFromJsonContext>();
        }
    }
}