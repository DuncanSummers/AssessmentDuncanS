using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentDuncanS.Models
{
    // Add message detail model
    public class MessageDetail
    {
        public int MessageID { get; set; }
        public string Content { get; set; }
        [Display(Name="Time Sent")]
        public DateTimeOffset SentUTC { get; set; }
    }
}
