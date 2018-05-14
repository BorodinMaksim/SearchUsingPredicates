using Maksim.SearchUsingPredicates.Common;

namespace Maksim.SearchUsingPredicates.Models
{
    public class ParsedSearchString
    {
        public Predicate FirstPredicate { get; set; }

        public bool IsAndOperator { get; set; }

        public Predicate SecondPredicate { get; set; }
    }
}