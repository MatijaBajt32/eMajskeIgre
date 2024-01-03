using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace web.Models
{
    public class Event
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EventID { get; set; }
        public string? EventTitle { get; set; }
        public string? EventDescription { get; set; }
        public DateTime EventDate { get; set; }
        public int PrizeFund { get; set; }
        public int? FirstPlace { get; set; }
        public int? SecondPlace { get; set; }
        public int? ThirdPlace { get; set; }

        public DateTime? DateCreated { get; set; }
        public DateTime? DateEdited { get; set; }
        public ApplicationUser? Owner { get; set; }
       
        

        public ICollection<Enrollment>? Enrollments { get; set; }
    }
}