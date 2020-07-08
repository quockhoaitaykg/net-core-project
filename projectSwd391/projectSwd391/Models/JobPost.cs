using System;
using System.Collections.Generic;

namespace projectSwd391.Models
{
    public partial class JobPost
    {
        public JobPost()
        {
            Application = new HashSet<Application>();
            SavedJob = new HashSet<SavedJob>();
        }

        public int Id { get; set; }
        public int? JobId { get; set; }
        public int? SchoolBranchId { get; set; }
        public bool? DelFlg { get; set; }
        public long? Ver { get; set; }
        public int InsId { get; set; }
        public DateTime InsDateTime { get; set; }
        public int? UpdId { get; set; }
        public DateTime? UpdDateTime { get; set; }

        public virtual Job Job { get; set; }
        public virtual SchoolBranch SchoolBranch { get; set; }
        public virtual ICollection<Application> Application { get; set; }
        public virtual ICollection<SavedJob> SavedJob { get; set; }
    }
}
