using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogFeatures.Commands
{
    public class DeleteBlogCategoryCommand
    {
        public int Id { get; set; }

        public DeleteBlogCategoryCommand(int id)
        {
            Id = id;
        }
    }
}
