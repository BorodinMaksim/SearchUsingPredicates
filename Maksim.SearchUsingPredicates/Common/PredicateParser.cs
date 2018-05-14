using System;

using Maksim.SearchUsingPredicates.Interfaces;
using Maksim.SearchUsingPredicates.Models;

namespace Maksim.SearchUsingPredicates.Common
{
    public class PredicateParser : IPredicateParser
    {
        public ParsedSearchString Parse(string searchString)
        {
            string[] elements = searchString.Split(' ');
            var firstPredicate = elements[0];
            var secondPredicate = elements[2];
            var operand = elements[1];
            Tuple<bool, string> firstParsedPredicate = this.ParsePredicate(firstPredicate);
            Tuple<bool, string> secondParsedPredicate = this.ParsePredicate(secondPredicate);
            var parsedOperand = operand.Equals("&&", StringComparison.CurrentCultureIgnoreCase);
            return new ParsedSearchString
                {
                   FirstPredicate = new Predicate
                       {
                           IsNotNegative = firstParsedPredicate.Item1,
                           Value = firstParsedPredicate.Item2
                       },
                   SecondPredicate = new Predicate
                       {
                           IsNotNegative = secondParsedPredicate.Item1,
                           Value = secondParsedPredicate.Item2
                       },
                   IsAndOperator = parsedOperand
                };
        }

        private Tuple<bool, string> ParsePredicate(string predicate)
        {
            return predicate.Trim().StartsWith("!")
                       ? new Tuple<bool, string>(false, predicate.Substring(1))
                       : new Tuple<bool, string>(true, predicate);
        }
    }
}