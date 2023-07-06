using Domain.Data;
using Domain.Entities.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persons
{
    public interface IPersonRepository: IRepository<Person>
    {
    }
}
