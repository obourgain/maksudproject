using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Text;

namespace CommonUtilities.Extensions
{
    public static class EntityFrameworkExtension
    {

        public static void DeleteObjects<T>(this ObjectContext context, ObjectQuery<T> query)
        {

            // Delete objects
            ObjectResult<T> result = query.Execute(MergeOption.AppendOnly);
            IEnumerator enumerator = result.GetEnumerator();
            while (enumerator.MoveNext())
            {
                T obj = (T)enumerator.Current;
                context.DeleteObject(obj);
            }

        } // DeleteObjects

        // DeleteObjects
        public static void DeleteObjects<T>(this ObjectContext context, IEnumerable<T> query)
        {

            // Delete objects      
            IEnumerator enumerator = query.GetEnumerator();
            while (enumerator.MoveNext())
            {
                T obj = (T)enumerator.Current;
                context.DeleteObject(obj);
            }

        } // DeleteObjects

        // DeleteObjects
        public static void DeleteObjects<T>(this ObjectContext context, IList<T> query)
        {

            // Delete objects      
            IEnumerator enumerator = query.GetEnumerator();
            while (enumerator.MoveNext())
            {
                T obj = (T)enumerator.Current;
                context.DeleteObject(obj);
            }

        } // DeleteObjects

        // DeleteObjects
        public static void DeleteObjects<T>(this ObjectContext context, IQueryable<T> query)
        {

            // Delete objects      
            IEnumerator enumerator = query.GetEnumerator();
            while (enumerator.MoveNext())
            {
                T obj = (T)enumerator.Current;
                context.DeleteObject(obj);
            }

        } // DeleteObjects
    }

}
