using Maksim.SearchUsingPredicates.Interfaces;
using Maksim.SearchUsingPredicates.Services;

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
    }
}