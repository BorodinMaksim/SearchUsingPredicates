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

            string[] elements = searchString.Split(' ');

            if (elements.Length > 0)
            {
                var firstStringPredicate = elements[0];
                firstPredicate = this.ParsePredicate(firstStringPredicate);
                if (elements.Length > 2)
                {
                    var secondStringPredicate = elements[2];
                    secondPredicate = this.ParsePredicate(secondStringPredicate);
                    var operand = elements[1];
                    parsedOperand = operand.Equals("&&", StringComparison.CurrentCultureIgnoreCase);
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
            return predicateString.Trim().StartsWith("!")
                       ? new Predicate(false, predicateString.Substring(1))
                       : new Predicate(true, predicateString);
        }
    }
}