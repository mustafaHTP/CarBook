using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.RepositoryMappings
{
    public static class BlogMappings
    {
        public static readonly Dictionary<string, Expression<Func<Blog, object?>>> IncludeMappings =
            new(StringComparer.OrdinalIgnoreCase)
            {
                { "author", b => b.BlogAuthor },
                { "category", b => b.BlogCategory },
            };
    }
}
