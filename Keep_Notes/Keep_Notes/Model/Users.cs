using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Keep_Notes.Model
{
    public partial class Users
    {
        public Users()
        {
            Notes = new HashSet<Notes>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int CityId { get; set; }
        public int AgeGroupId { get; set; }

        public virtual AgeGroups AgeGroup { get; set; }
        public virtual Cities City { get; set; }
        public virtual ICollection<Notes> Notes { get; set; }
    }
}
