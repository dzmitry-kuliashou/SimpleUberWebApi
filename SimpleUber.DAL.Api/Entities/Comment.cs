using System.ComponentModel.DataAnnotations;

namespace SimpleUber.DAL.Api.Entities
{
    public class Comment : EFEntity
    {
        [Required]
        public string Text { get; set; }

        [Required]
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }
    }
}
