using CSharpEgitimKampi301.DataAccessLayer.Abstract;
using CSharpEgitimKampi301.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.DataAccessLayer.Repositories
{
    /*
     * DataAccessLayer/Abstract tarafında doluşturulan moethodların içlerinin 
     * doldurulması gerekiyor. (Insert,Update,Delete vb.)
     * 
     * EntityState aslında; update, delete, insert işlemlerini yapmamızı sağlayan bir enum değeridir.
     * Bu enum sayesinde basit bir şekilde yukarıdaki işlemleri yapmış oluruz. Okuma işlemlerinde 
     * entity işlemlerinde değişklik yapmayacağımız için kullanılmaz.
     */
    public class GenericRepositories<T> : IGenericDal<T> where T : class
    {
        CampContext context = new CampContext();
        private readonly DbSet<T> _object;

        public GenericRepositories()
        {
            _object = context.Set<T>();
        }

        // Delete

        public void Delete(T entity)
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _object.ToList();
        }

        public T GetById(int id)    
        {
            return _object.Find(id);
        }

        // Insert
        public void Insert(T entity)
        {
            var insertedEntity = context.Entry(entity); // ekleme yapacağımız entity'i hafızaya aldık
            insertedEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        // Update
        public void Update(T entity)
        {
            // EntityState sayesinde tek tek atama işlemi yapmadan değişiklikleri tabloya 
            // yansıtabiliriz.

            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
