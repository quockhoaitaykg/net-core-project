using System;
using System.Collections.Generic;

namespace projectSwd391.Models
{
    public partial class Application
    {
        public int TeacherId { get; set; }
        public int JobPostId { get; set; }
        public string ApplyTime { get; set; }
        public bool? DelFlg { get; set; }
        public long? Ver { get; set; }
        public int InsId { get; set; }
        public DateTime InsDateTime { get; set; }
        public int? UpdId { get; set; }
        public DateTime? UpdDateTime { get; set; }

        public virtual JobPost JobPost { get; set; }
        public virtual UserProfile Teacher { get; set; }
    }
}
