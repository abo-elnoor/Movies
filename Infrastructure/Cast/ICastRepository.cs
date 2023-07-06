using Domain.Data;
using Domain.Entities.Casts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Casts
{
    public interface ICastRepository : IRepository<Cast>
    {
    }
}
