using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thoughtful.Domain.Model
{
    public class Author
    {
        public Author()
        {
            
        }
        public int Id { get; set; } 
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName => FirstName + " " + LastName;
        public DateTime DateOfBirth { get; set; }
        public string? Bio { get; set; }

        public void UpdateAuthor(string firstName, string lastName, string bio, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            Bio = bio;
            DateOfBirth = dateOfBirth;
        }
    }
}
