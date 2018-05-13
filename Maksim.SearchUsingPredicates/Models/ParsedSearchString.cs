using Maksim.SearchUsingPredicates.Common;

namespace Maksim.SearchUsingPredicates.Models
{
    public class ParsedSearchString
    {
        public Predicate FirstPredicate { get; set; }

        public LogicalOperand Operand { get; set; }

        public Predicate SecondPredicate { get; set; }
    }
}