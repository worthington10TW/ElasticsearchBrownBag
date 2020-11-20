using System;
using System.Collections.Generic;

namespace DataLoader
{
    public static class IEnumerableExtensions
    {
        public static void BatchForEach<T>
            (this IEnumerable<T> data,
            Action<IEnumerable<T>> action,
            int batchSize)
        {
            var batches = Batch(data, batchSize);
            Console.WriteLine(
                $"Split list of {typeof(T).Name} into batches of {batchSize}");
            foreach (IEnumerable<T> item in batches)
                action(item);
        }


        private static IEnumerable<IEnumerable<T>> Batch<T>
          (this IEnumerable<T> data, int size)
        {
            List<T> nextbatch = new List<T>(size);
            foreach (T item in data)
            {
                nextbatch.Add(item);
                if (nextbatch.Count == size)
                {
                    yield return nextbatch;
                    nextbatch = new List<T>();
                }
            }

            if (nextbatch.Count > 0)
                yield return nextbatch;
        }
    }
}