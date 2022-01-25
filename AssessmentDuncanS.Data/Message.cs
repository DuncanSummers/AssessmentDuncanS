using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentDuncanS.Data
{
    // set up properties of messages in data layer
    public class Message
    {
        [Key]
        public int MessageID { get; set; }

        [Required]
        public Guid Sender { get; set; }

        [Required]
        public Guid Recipient { get; set; }

        [Required]
        [MinLength(1, ErrorMessage ="Please type your message")]
        [MaxLength(1000, ErrorMessage ="Message exceeds character limit")]
        public string Content { get; set; }
        [Required]
        [Display(Name ="Time Sent")]
        public DateTimeOffset SentUTC { get; set; }
    }
}
