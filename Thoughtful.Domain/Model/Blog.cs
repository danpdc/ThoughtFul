using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thoughtful.Domain.Model
{
    public class Blog
    {
        public Blog()
        {
            Contributors = new List<Author>();
        }
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }
        public DateTime CreatedDate {  get; set; }
        
        public int AuthorId { get; set; }
        public Author Owner { get; set; }

        public ICollection<Author> Contributors { get; set; }
    }
}
