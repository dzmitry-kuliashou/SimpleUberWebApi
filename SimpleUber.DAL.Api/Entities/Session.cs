using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleUber.DAL.Api.Entities
{
    public class Session : EFEntity
    {
        [Required]
        public Guid Token { get; set; }

        [Required]
        public DateTime TokenExpired { get; set; }
    }
}
