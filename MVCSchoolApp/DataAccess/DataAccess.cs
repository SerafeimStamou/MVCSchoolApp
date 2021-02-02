using System.Collections.Generic;


namespace MVCSchoolApp.DataAccess
{
    public class DataAccess
    {
        public static MVCSchoolAppContext DbContextInitialize()
        {
            MVCSchoolAppContext context;
            return context = new MVCSchoolAppContext();
        }

        public static IEnumerable<T> Read<T>(T model) where T:class
        {
            return DbContextInitialize().Set<T>();
        }
    }
}