using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentDuncanS.Models
{
    // after made controller created a model for ability to list messages sent using web app,
    // now to change controller index
    public class MessageListItem
    {
        public int MessageID { get; set; }
        public Guid Sender { get; set; }
        [Display(Name ="Time Sent")]
        public DateTimeOffset SentUTC { get; set; }
    }
}
