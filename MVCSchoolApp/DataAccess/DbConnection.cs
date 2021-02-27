using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace MVCSchoolApp.DataAccess
{
    public class DbConnection
    {
        public async Task<List<T>> Read<T>() where T:class
        {
            using (MVCSchoolAppContext context = new MVCSchoolAppContext())
            {
                return await context.Set<T>().ToListAsync();
            }
        }

        public async Task Create<T>(T model) where T : class
        {
            using (MVCSchoolAppContext context = new MVCSchoolAppContext())
            {
                context.Set<T>().Add(model);

                await context.SaveChangesAsync();
            }
        }
            
        public async Task Delete<T>(int id) where T:class
        {
            using (MVCSchoolAppContext context = new MVCSchoolAppContext())
            {
                var result = await context.Set<T>().FindAsync(id);
                context.Set<T>().Remove(result);

                await context.SaveChangesAsync();
            }
        }

        public async Task<T> SearchById<T>(int? id) where T:class
        {
            using (MVCSchoolAppContext context = new MVCSchoolAppContext())
            {
                return await context.Set<T>().FindAsync(id);
            }
        }

        public async Task SaveDbChanges()
        {
            using (MVCSchoolAppContext context = new MVCSchoolAppContext())
            {
               await context.SaveChangesAsync();
            }
        }
    }
}