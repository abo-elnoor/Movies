using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Movies
{
    public class Movie :BaseEntity
    {
        public string Title { get; set; }
        public int DirectorId { get; set; }
    }
}
