using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thoughtful.Domain.Model
{
    public class Article
    {
        public Article()
        {
            Categories = new List<Category>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Subtitle { get; set; }
        public string Body { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdated { get; set; }
        public int NumberOfLikes { get; set; }
        public int NumberOfShares { get; set; }
        public ICollection<Category> Categories { get; set;}
    }
}
