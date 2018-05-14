using System;
using System.Linq.Expressions;
using System.Reflection;

using Maksim.SearchUsingPredicates.Models;

namespace Maksim.SearchUsingPredicates.Common
{
    public static class QueryObject
    {
        public static Expression<Func<T, bool>> GetExpression<T>(
            ParsedSearchString parsedSearchString,
            string fieldName)
        {
            ParameterExpression param = Expression.Parameter(typeof(T));
            var member = Expression.Property(param, fieldName);

            //single expression
            if (parsedSearchString.SecondPredicate == null)
            {
                var expression = ApplyOperator(parsedSearchString.FirstPredicate, member);
                return Expression.Lambda<Func<T, bool>>(expression, param);
            }

            //Two expressions
            if (parsedSearchString.IsAndOperator)
            {
                BinaryExpression expression = Expression.AndAlso(
                    ApplyOperator(parsedSearchString.FirstPredicate, member),
                    ApplyOperator(parsedSearchString.SecondPredicate, member));
                return Expression.Lambda<Func<T, bool>>(expression, param);
            }
            else
            {
                BinaryExpression expression = Expression.OrElse(
                    ApplyOperator(parsedSearchString.FirstPredicate, member),
                    ApplyOperator(parsedSearchString.SecondPredicate, member));
                return Expression.Lambda<Func<T, bool>>(expression, param);
            }
        }

        private static Expression ApplyOperator(Predicate predicate, MemberExpression left)
        {
            var rightConstant = Expression.Constant(predicate.Value);
            if (predicate.IsNotNegative)
            {
                MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                return Expression.Call(left, method, rightConstant);
            }
            else
            {
                MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                return Expression.Not(Expression.Call(left, method, rightConstant));
            }
        }
    }
}