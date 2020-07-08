using System;
using System.Collections.Generic;

namespace projectSwd391.Models
{
    public partial class Location
    {
        public Location()
        {
            SchoolBranch = new HashSet<SchoolBranch>();
            UserProfile = new HashSet<UserProfile>();
        }

        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool? DelFlg { get; set; }
        public long? Ver { get; set; }
        public int InsId { get; set; }
        public DateTime InsDateTime { get; set; }
        public int? UpdId { get; set; }
        public DateTime? UpdDateTime { get; set; }
        public int? DistrictId { get; set; }

        public virtual District District { get; set; }
        public virtual ICollection<SchoolBranch> SchoolBranch { get; set; }
        public virtual ICollection<UserProfile> UserProfile { get; set; }
    }
}
