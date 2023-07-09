using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Casts
{
    public class Cast : BaseEntity
    {
        public int PersonId { get; set; }
        public string CharName { get; set; }
        public int CastOrder { get; set; }
        public char CharGender { get; set; }
        public int MovieId { get; set; }
    }
}
