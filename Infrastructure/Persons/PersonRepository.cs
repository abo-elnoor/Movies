using Domain.Data;
using Domain.Entities.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persons
{
    public class PersonRepository : IPersonRepository
    {
        public static List<Person> lstPersons = new List<Person>()
        {
           new Person{  Id =1 ,Name= "Director1", Gender='F'},
           new Person{  Id =2 ,Name= "Director2", Gender='M'},

           new Person{  Id =3 ,Name= "Person3", Gender='F'},
           new Person{  Id =4 ,Name= "Person4", Gender='M'},
           new Person{  Id =5 ,Name= "Person5", Gender='M'},

           new Person{  Id =6 ,Name= "Person6", Gender='F'},
           new Person{  Id =7 ,Name= "Person7", Gender='M'},
           new Person{  Id =8 ,Name= "Person8", Gender='M'}
        };
        public void Delete(Person entity)
        {
            throw new NotImplementedException();
        }

        public Person GetById(object id)
        {
            return lstPersons.Where(m => m.Id == (int)id).FirstOrDefault();
        }

        public Person Insert(Person entity)
        {
            throw new NotImplementedException();
        }

        public IList<Person> Table
        {
            get
            {
                return lstPersons;
            }          
        }

        public void Update(Person entity)
        {
            throw new NotImplementedException();
        }
    }
}
