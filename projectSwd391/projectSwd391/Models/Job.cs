using System;
using System.Collections.Generic;

namespace projectSwd391.Models
{
    public partial class Job
    {
        public Job()
        {
            JobPost = new HashSet<JobPost>();
            JobSkill = new HashSet<JobSkill>();
        }

        public int Id { get; set; }
        public int MajorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int Quantity { get; set; }
        public double? MinSalary { get; set; }
        public double? MaxSalary { get; set; }
        public bool? DelFlg { get; set; }
        public long? Ver { get; set; }
        public int InsId { get; set; }
        public DateTime InsDateTime { get; set; }
        public int? UpdId { get; set; }
        public DateTime? UpdDateTime { get; set; }

        public virtual Major Major { get; set; }
        public virtual ICollection<JobPost> JobPost { get; set; }
        public virtual ICollection<JobSkill> JobSkill { get; set; }
    }
}
