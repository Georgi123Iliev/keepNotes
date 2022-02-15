using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Keep_Notes.Model
{
    public partial class Notes
    {
        public string Title { get; set; }
        [Column]
        public DateTime creation_date { get; set; }
        [Column]
        public DateTime latest_change { get; set; }
        public string Note { get; set; }
        public bool Private { get; set; }
        public string Password { get; set; }
        public string Keywords { get; set; }
        public string Color { get; set; }
        public int UserId { get; set; }

        public virtual Users User { get; set; }
    }
}
