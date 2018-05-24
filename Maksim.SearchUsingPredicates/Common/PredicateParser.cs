using System;

using Maksim.SearchUsingPredicates.Interfaces;
using Maksim.SearchUsingPredicates.Models;

namespace Maksim.SearchUsingPredicates.Common
{
    public class PredicateParser : IPredicateParser
    {
        public ParsedSearchString Parse(string searchString)
        {
            Predicate firstPredicate = null;
            Predicate secondPredicate = null;
            bool parsedOperand = false;

            string[] elements = searchString.Split(new[] { "&&", "||" }, StringSplitOptions.None);

            if (elements.Length > 0)
            {
                firstPredicate = this.ParsePredicate(elements[0].Trim());
                if (elements.Length > 1)
                {
                    secondPredicate = this.ParsePredicate(elements[1].Trim());
                    parsedOperand = searchString.Contains("&&");
                }
            }

            return new ParsedSearchString
                       {
                           FirstPredicate = firstPredicate,
                           SecondPredicate = secondPredicate,
                           IsAndOperator = parsedOperand
                       };
        }

        private Predicate ParsePredicate(string predicateString)
        {
            return predicateString.StartsWith("!")
                       ? new Predicate(false, predicateString.Substring(1))
                       : new Predicate(true, predicateString);
        }
    }
}