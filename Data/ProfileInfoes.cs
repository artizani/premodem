using System;
using System.Collections.Generic;

namespace Data
{
    public partial class ProfileInfoes
    {
        public ProfileInfoes()
        {
            AspNetUsers = new HashSet<AspNetUsers>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public Loans Loans { get; set; }
        public ICollection<AspNetUsers> AspNetUsers { get; set; }
    }
}
