using System;
using System.Collections.Generic;

using Maksim.SearchUsingPredicates.Interfaces;
using Maksim.SearchUsingPredicates.Models;

namespace Maksim.SearchUsingPredicates.Common
{
    public class PredicateParser : IPredicateParser
    {
        private Dictionary<string, LogicalOperand> _operandMatching = new Dictionary<string, LogicalOperand>
                                                                          {
                                                                              { "&&", LogicalOperand.And },
                                                                              { "||", LogicalOperand.Or }
                                                                          };

        public ParsedSearchString Parse(string searchString)
        {
            string[] elements = searchString.Split(' ');
            var firstPredicate = elements[0];
            var secondPredicate = elements[2];
            var operand = elements[1];
            var firstParsedPredicate = this.ParsePredicate(firstPredicate);
            var secondParsedPredicate = this.ParsePredicate(secondPredicate);
            var parsedOperand = this.ParseOperand(operand);
            return new ParsedSearchString
            {
                FirstPredicate = new Predicate
                    {
                        IsInverted = firstParsedPredicate.Item1,
                        Value = firstParsedPredicate.Item2
                },
                SecondPredicate = new Predicate
                                     {
                                         IsInverted = secondParsedPredicate.Item1,
                                         Value = secondParsedPredicate.Item2
                                     },
                Operand = parsedOperand
            };
        }

        private Tuple<bool, string> ParsePredicate(string predicate)
        {
            return predicate.Trim().StartsWith("!")
                       ? new Tuple<bool, string>(true, predicate.Substring(1))
                       : new Tuple<bool, string>(false, predicate);
        }

        private LogicalOperand ParseOperand(string operand)
        {
            return this._operandMatching.TryGetValue(operand, out var returnedOperand) ?
                       returnedOperand :
                       default(LogicalOperand);
        }
    }
}
