using Domain.Data;
using Domain.Entities.Casts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Casts
{
    public class CastRepository : ICastRepository
    {
        public static List<Cast> lstCasts = new List<Cast>()
        {
           new Cast{  Id =1 ,CharName= "Cast1", CastOrder=1,CharGender='F' ,MovieId=1,PersonId=3 },
           new Cast{  Id =2 ,CharName= "Cast2", CastOrder=1,CharGender='M' ,MovieId=1,PersonId=4 },
           new Cast{  Id =3 ,CharName= "Cast3", CastOrder=2,CharGender='F' ,MovieId=1,PersonId=5 },

           new Cast{  Id =4 ,CharName= "Cast4", CastOrder=1,CharGender='F' ,MovieId=2,PersonId=6 },
           new Cast{  Id =5 ,CharName= "Cast5", CastOrder=2,CharGender='M' ,MovieId=2,PersonId=7 },
           new Cast{  Id =6 ,CharName= "Cast6", CastOrder=3,CharGender='M' ,MovieId=2,PersonId=8 }
        };

        public void Delete(Cast entity)
        {
            throw new NotImplementedException();
        }

        public Cast GetById(object id)
        {
            return lstCasts.Where(m => m.Id == (int)id).FirstOrDefault();
        }

        public Cast Insert(Cast entity)
        {
            throw new NotImplementedException();
        }

        public IList<Cast> Table
        {
            get
            {
                return lstCasts;
            }          
        }

        public void Update(Cast entity)
        {
            throw new NotImplementedException();
        }
    }
}
