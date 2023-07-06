using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Cast
{
    public class CustomMovieCast
    {
        public int CastId { get; set; }
        public string CastName { get; set; }
        public string CharName { get; set; }
        public char CastGender { get; set; }
        public char CharGender { get; set; }
        public int CastOrder { get; set; }
    }
}
