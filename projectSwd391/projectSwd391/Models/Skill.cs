using System;
using System.Collections.Generic;

namespace projectSwd391.Models
{
    public partial class Skill
    {
        public Skill()
        {
            JobSkill = new HashSet<JobSkill>();
            TeacherSkill = new HashSet<TeacherSkill>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? DelFlg { get; set; }
        public long? Ver { get; set; }
        public int InsId { get; set; }
        public DateTime InsDateTime { get; set; }
        public int? UpdId { get; set; }
        public DateTime? UpdDateTime { get; set; }

        public virtual ICollection<JobSkill> JobSkill { get; set; }
        public virtual ICollection<TeacherSkill> TeacherSkill { get; set; }
    }
}
