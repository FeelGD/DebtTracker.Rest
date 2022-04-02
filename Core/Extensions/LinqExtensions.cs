using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Core.Extensions
{
    public static class LinqExtensions
    {
        public static IQueryable<T> WhereStringContains<T>(this IQueryable<T> query, string propertyName, string contains)
        {
            propertyName = propertyName.FirstCharToUpper();
            var parameter = Expression.Parameter(typeof(T), "type");
            var propertyExpression = Expression.Property(parameter, propertyName);
            MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var someValue = Expression.Constant(contains.ToString(), typeof(string));
            var containsExpression = Expression.Call(propertyExpression, method, someValue);

            return query.Where(Expression.Lambda<Func<T, bool>>(containsExpression, parameter));
        }

        public static IQueryable<T> WhereBooleanEquals<T>(this IQueryable<T> query, string propertyName, bool value)
        {
            propertyName = propertyName.FirstCharToUpper();
            var parameter = Expression.Parameter(typeof(T), "type");
            var propertyExpression = Expression.Property(parameter, propertyName);
            MethodInfo method = typeof(bool).GetMethod("Equals", new[] { typeof(bool) });
            var someValue = Expression.Constant(value, typeof(bool));
            var containsExpression = Expression.Call(propertyExpression, method, someValue);

            return query.Where(Expression.Lambda<Func<T, bool>>(containsExpression, parameter));
        }

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> query, string propertyName)
        {
            propertyName = propertyName.FirstCharToUpper();
            var propertyType = typeof(T).GetProperty(propertyName).PropertyType;
            var parameter = Expression.Parameter(typeof(T), "type");
            var propertyExpression = Expression.Property(parameter, propertyName);
            var lambda = Expression.Lambda(propertyExpression, new[] { parameter });

            return typeof(Queryable).GetMethods()
                                    .Where(m => m.Name == "OrderBy" && m.GetParameters().Length == 2)
                                    .Single()
                                    .MakeGenericMethod(new[] { typeof(T), propertyType })
                                    .Invoke(null, new object[] { query, lambda }) as IOrderedQueryable<T>;
        }

        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> query, string propertyName)
        {
            propertyName = propertyName.FirstCharToUpper();
            var propertyType = typeof(T).GetProperty(propertyName).PropertyType;
            var parameter = Expression.Parameter(typeof(T), "type");
            var propertyExpression = Expression.Property(parameter, propertyName);
            var lambda = Expression.Lambda(propertyExpression, new[] { parameter });

            return typeof(Queryable).GetMethods()
                                    .Where(m => m.Name == "OrderByDescending" && m.GetParameters().Length == 2)
                                    .Single()
                                    .MakeGenericMethod(new[] { typeof(T), propertyType })
                                    .Invoke(null, new object[] { query, lambda }) as IOrderedQueryable<T>;
        }

    }
}