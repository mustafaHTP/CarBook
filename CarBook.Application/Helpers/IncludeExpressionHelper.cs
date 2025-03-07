using CarBook.Application.RepositoryMappings;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Helpers
{
    public static class IncludeExpressionHelper
    {
        /// <summary>
        /// It returns the include expressions for the given includes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="includes"></param>
        /// <param name="includeMappings"></param>
        /// <returns></returns>
        public static IEnumerable<Expression<Func<Blog, object?>>> GetIncludeExpressions<T>(string? includes, Dictionary<string, Expression<Func<Blog, object?>>> includeMappings)
        {
            ICollection<Expression<Func<Blog, object?>>> includeExpressions = [];
            if (string.IsNullOrEmpty(includes))
            {
                return includeExpressions;
            }

            //Normalize the includes and ensure they are unique
            var uniqueIncludes = new HashSet<string>(includes.Split(',').Select(i => i.ToLower()));

            //Get the include mappings
            foreach (var uniqueInclude in uniqueIncludes)
            {
                if (includeMappings.ContainsKey(uniqueInclude))
                {
                    var includeExpression = BlogMappings.IncludeMappings[uniqueInclude];
                    includeExpressions.Add(includeExpression);
                }
            }

            return includeExpressions;
        }
    }
}
