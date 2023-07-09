using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Persons
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }
        public char Gender { get; set; }
    }
}
