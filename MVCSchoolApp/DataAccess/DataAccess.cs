using System.Collections.Generic;

namespace MVCSchoolApp.DataAccess
{
    public class DataAccess
    {
        public static MVCSchoolAppContext context = new MVCSchoolAppContext();

        public static IEnumerable<T> Read<T>(T model) where T:class
        {
          return context.Set<T>();
        }

        public static void Create<T>(T model) where T:class
        {
           context.Set<T>().Add(model);
        }

        public static void Delete<T>(int id) where T:class
        {
            var model = context.Set<T>().Find(id);
            context.Set<T>().Remove(model);
        }
    }
}