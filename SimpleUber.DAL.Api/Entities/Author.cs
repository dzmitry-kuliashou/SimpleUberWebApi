using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleUber.DAL.Api.Entities
{
    public class Author : EFEntity
    {
        public Author()
        {
            Comments = new HashSet<Comment>();
        }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
