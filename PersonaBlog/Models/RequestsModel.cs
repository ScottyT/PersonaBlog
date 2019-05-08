using PersonaBlog.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonaBlog.Models
{
    public class RequestsModel : IEntityBase
    {
        [Key]
        public string Id { get; set; }

        public string UserId { get; set; }
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "Subject is required.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Content of the request is required.")]
        [StringLength(250, ErrorMessage = "The request cannot be higher than 250 characters.")]
        public string Content { get; set; }
        public bool AcceptRequest { get; set; }
    }
}
