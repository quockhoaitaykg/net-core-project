using System;
using System.Collections.Generic;

namespace projectSwd391.Models
{
    public partial class JobSkill
    {
        public int JobId { get; set; }
        public int SkillId { get; set; }
        public bool? DelFlg { get; set; }
        public long? Ver { get; set; }
        public int InsId { get; set; }
        public DateTime InsDateTime { get; set; }
        public int? UpdId { get; set; }
        public DateTime? UpdDateTime { get; set; }

        public virtual Job Job { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
