using Maksim.SearchUsingPredicates.Models;

namespace Maksim.SearchUsingPredicates.Interfaces
{
    public interface IPredicateParser
    {
        ParsedSearchString Parse(string searchString);
    }
}