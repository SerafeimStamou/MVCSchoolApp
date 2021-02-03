using System.Collections.Generic;


namespace MVCSchoolApp.DataAccess
{
    public class DataAccess
    {
        public static IEnumerable<T> Read<T>(T model) where T:class
        {
            MVCSchoolAppContext context = new MVCSchoolAppContext();

            return context.Set<T>();
        }

        public static void Create<T>(T model) where T:class
        {
            MVCSchoolAppContext context = new MVCSchoolAppContext();

            context.Set<T>().Add(model);
            context.SaveChanges();
        }
    }
}