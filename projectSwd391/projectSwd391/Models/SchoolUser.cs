using System;
using System.Collections.Generic;

namespace projectSwd391.Models
{
    public partial class SchoolUser
    {
        public int UserId { get; set; }
        public int SchoolId { get; set; }
        public bool? DelFlg { get; set; }
        public long? Ver { get; set; }
        public int InsId { get; set; }
        public DateTime InsDateTime { get; set; }
        public int? UpdId { get; set; }
        public DateTime? UpdDateTime { get; set; }

        public virtual School School { get; set; }
        public virtual UserProfile User { get; set; }
    }
}
