using System;
using System.Collections.Generic;

namespace projectSwd391.Models
{
    public partial class SchoolBranch
    {
        public SchoolBranch()
        {
            JobPost = new HashSet<JobPost>();
        }

        public int Id { get; set; }
        public int SchoolId { get; set; }
        public int LocationId { get; set; }
        public string Phone { get; set; }
        public bool? DelFlg { get; set; }
        public long? Ver { get; set; }
        public int InsId { get; set; }
        public DateTime InsDateTime { get; set; }
        public int? UpdId { get; set; }
        public DateTime? UpdDateTime { get; set; }

        public virtual Location Location { get; set; }
        public virtual School School { get; set; }
        public virtual ICollection<JobPost> JobPost { get; set; }
    }
}
