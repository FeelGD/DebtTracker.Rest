using System.Linq;

namespace Core.Extensions
{
    public static class QueryableExtensions
    {
        public static int CalculatePageCount<TEntity>(this IQueryable<TEntity> dbSet, int pageSize) where TEntity : class, new()
        {
            int count;
            int countOfStaffs = dbSet.ToList().Count;
            count = countOfStaffs / pageSize;
            if (countOfStaffs % pageSize != 0)
            {
                count++;
            }
            return count;
        }

        /*public static IQueryable<TEntity> Filter<TEntity>(this IQueryable<TEntity> dbSet, List<Filter> filterList)
            where TEntity : class, new()
        {
            foreach (var filter in filterList)
            {
                dbSet = dbSet.WhereStringContains(filter.id, filter.value).AsQueryable();
            }

            return dbSet;
        }
        public static IQueryable<TEntity> Sort<TEntity>(this IQueryable<TEntity> dbSet, List<Sort> sortList)
            where TEntity : class, new()
        {
            if (sortList.Count != 0)
            {
                var sort = sortList[0];
                dbSet = sort.desc ? dbSet.OrderByDescending(sort.id).AsQueryable() : dbSet.OrderBy(sort.id).AsQueryable();
            }

            return dbSet;
        }*/
        public static IQueryable<TEntity> GetPage<TEntity>(this IQueryable<TEntity> dbSet, int page, int pageSize)
            where TEntity : class, new()
        {
            return dbSet.Skip(page * pageSize).Take(pageSize);
        }
    }
}