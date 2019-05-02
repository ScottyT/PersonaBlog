using System;
using System.ComponentModel.DataAnnotations;

namespace PersonaBlog.Models
{
    public class RequestsModel
    {
        [Key]
        public Guid RequestId { get; set; }
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "Subject is required.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Content of the request is required.")]
        [StringLength(250, ErrorMessage = "The request cannot be higher than 250 characters.")]
        public string Content { get; set; }
        public bool AcceptRequest { get; set; }
    }
}
