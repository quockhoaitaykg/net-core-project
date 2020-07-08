using System;
using System.Collections.Generic;

namespace projectSwd391.Models
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            Application = new HashSet<Application>();
            SavedJob = new HashSet<SavedJob>();
            TeacherSkill = new HashSet<TeacherSkill>();
        }

        public int Id { get; set; }
        public int LocationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Phone { get; set; }

        public virtual Location Location { get; set; }
        public virtual SchoolUser SchoolUser { get; set; }
        public virtual UserAccount UserAccount { get; set; }
        public virtual ICollection<Application> Application { get; set; }
        public virtual ICollection<SavedJob> SavedJob { get; set; }
        public virtual ICollection<TeacherSkill> TeacherSkill { get; set; }
    }
}
