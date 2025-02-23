using CarBook.Domain.Entities;

namespace CarBook.WebApp.Models
{
    public class CreateBlogCommentViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
    }
}
