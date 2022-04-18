using System.Collections.Generic;
using System.Linq;

/*
 Requirements
    Total Accts - 10000
    Batching of Accts - 100
    Delay in Secs/Batch - 1 sec
    Delay in Secs/Accts - 300ms

    No Parallelism
    Enable Cloud Monitoring
 */
namespace JobSystemDemoApi.Extensions
{
    public static class LinqExtension
    {
        #region IQueryable Extensions
        public static IEnumerable<IQueryable<T>> Batch<T>(this IQueryable<T> query, int batchSize)
        {
            int count = query.Count();
            int batchCount = count <= batchSize ? 1 : count % batchSize == 0 ? count / batchSize : count / batchSize + 1;

            for (int i = 0; i < batchCount; i++)
                yield return query.Skip(i * batchSize).Take(batchSize);

        }

        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> query, int batchSize)
        {
            int count = query.Count();
            int batchCount = count <= batchSize ? 1 : count % batchSize == 0 ? count / batchSize : count / batchSize + 1;

            for (int i = 0; i < batchCount; i++)
                yield return query.Skip(i * batchSize).Take(batchSize);

        }
        #endregion
    }
}
