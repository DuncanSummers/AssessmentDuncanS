using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentDuncanS.Models
{
    // Make the create model for sending a message
    public class MessageCreate
    {
        [Required]
        public Guid Recipient { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Please type your message")]
        [MaxLength(1000, ErrorMessage = "Message exceeds character limit")]
        public string Content { get; set; }
    }
}
