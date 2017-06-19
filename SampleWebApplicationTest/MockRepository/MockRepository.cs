using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebApplicationTest.IRepository
{
    //MockRepository Inherits off IRepo 
    class MockRepository<T> : IRepo<T> where T : class
    {

        
        public void Create(T entity)
        {
            throw new NotImplementedException();
        }

    
        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }


        public void Edit(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
