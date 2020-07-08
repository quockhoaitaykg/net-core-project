﻿using System;
using System.Collections.Generic;

namespace projectSwd391.Models
{
    public partial class City
    {
        public City()
        {
            District = new HashSet<District>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? DelFlg { get; set; }
        public long? Ver { get; set; }
        public int InsId { get; set; }
        public DateTime InsDateTime { get; set; }
        public int? UpdId { get; set; }
        public DateTime? UpdDateTime { get; set; }

        public virtual ICollection<District> District { get; set; }
    }
}
