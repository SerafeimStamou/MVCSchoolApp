using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace MVCSchoolApp.DataAccess
{
    public class DbConnection
    {
        public async Task Create<T>(T model) where T : class
        {
            MVCSchoolAppContext context = new MVCSchoolAppContext();

            try
            {
                context.Set<T>().Add(model);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (context != null)
                {
                    context.Dispose();
                }
            }
        }

        public async Task<List<T>> Read<T>() where T:class
        {
            MVCSchoolAppContext context = new MVCSchoolAppContext();

            try
            {
              return await context.Set<T>().ToListAsync();
            }
            catch (Exception)
            {
              throw;
            }
            finally
            {
                if(context != null)
                {
                    context.Dispose();
                }
            }
        }

        public async Task Update<T>(T model, int id) where T : class
        {
            MVCSchoolAppContext context = new MVCSchoolAppContext();

            try
            {
                T modelFound = await context.Set<T>().FindAsync(id);

                if (modelFound != null)
                {
                    context.Entry(modelFound).CurrentValues.SetValues(model);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (context != null)
                {
                    context.Dispose();
                }
            }
        }

        public async Task Delete<T>(int id) where T:class
        {
            MVCSchoolAppContext context = new MVCSchoolAppContext();

            try
            {
                var result = await context.Set<T>().FindAsync(id);

                context.Set<T>().Remove(result);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
              throw;
            }
            finally
            {
                if (context != null)
                {
                    context.Dispose();
                }
            }
        }

        public async Task<T> SearchById<T>(int? id) where T:class
        {
            MVCSchoolAppContext context = new MVCSchoolAppContext();

            try
            {
                return await context.Set<T>().FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if(context != null)
                {
                    context.Dispose();
                }
            }
        }    
    }
}