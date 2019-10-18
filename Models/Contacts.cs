using System;
using System.Collections.Generic;

namespace ngcore.Models
{
    public partial class Contacts
    {
        public Contacts()
        {
            Technologies = new HashSet<Technologies>();
        }

        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Technologies> Technologies { get; set; }
    }
}
