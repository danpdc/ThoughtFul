using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thoughtful.Domain.Model
{
    public class Blog
    {
        private Blog()
        {
            Contributors = new List<Author>();
        }
        public int Id { get; private set; }
        public string Name { get; private set; }    
        public string Description { get; private set; }
        public DateTime CreatedDate {  get; private set; }
        
        public int AuthorId { get; private set; }
        public Author Owner { get; private set; }

        public ICollection<Author> Contributors { get; private set; }

        public static Blog CreateBlog(string name, string description, int authorId)
        {
            return new Blog
            {
                Name = name,
                Description = description,
                AuthorId = authorId,
                CreatedDate = DateTime.Now
            };
        }

        public void UpdateBlogInfo(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void SetOwner(Author author)
        {
            Owner = author;
        }

        public void AddContributor(Author author)
        {
            if (!(Contributors.Any(c => c.Id == author.Id)))
                Contributors.Add(author);
        }

        public void RemoveContributor(Author author)
        {
            Contributors.Remove(author);
        }
    }
}
