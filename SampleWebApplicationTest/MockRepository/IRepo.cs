using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebApplicationTest
{
    //Defining an Interface IRepo that acts upon the TEntity. Here TEntity represents an entity (from a database model)
    public interface IRepo<TEntity> where TEntity : class
    {
        //Method for creating a database record
        void Create(TEntity entity);
        //Method for Editing current data
        void Edit(TEntity entity);
        //Method to Delete a record from the database
        void Delete(TEntity entity);

    }
}
