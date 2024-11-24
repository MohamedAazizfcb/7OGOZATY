using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Interfaces
{
    public interface IGenericRepository<T> :
          IAddRepository<T>,
          IDeleteRepository<T>,
          IUpdateRepository<T>,
          IRetrieveRepository<T>,
          IExistRepository<T>
          where T : class
    {
    }
}
