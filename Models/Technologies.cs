using System;
using System.Collections.Generic;

namespace ngcore.Models
{
    public partial class Technologies
    {
        public int TechId { get; set; }
        public int? ContactId { get; set; }
        public string TechName { get; set; }
        public int? YearsOfExperience { get; set; }

        public virtual Contacts Contact { get; set; }
    }
}
