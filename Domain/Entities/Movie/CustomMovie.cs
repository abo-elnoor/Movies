using Domain.Entities.Cast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Movies
{
    public class CustomMovie
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string DirectorName { get; set; }
        public char DirectorGender { get; set; }
        public List<CustomMovieCast> Casts { get; set; }
    }
}
