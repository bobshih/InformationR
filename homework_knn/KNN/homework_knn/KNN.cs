using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_knn
{
    public class KNN:KNN<int,List<double>>
    {
        /// <exception cref="InvalidOperationException">No Category Created Yet</exception>
        /// <exception cref="ArgumentException">K Must Bigget Than Zero</exception>
        public int FindCategory(List<double> data, int K)
        {
            return base.FindCategory(data, K, DistanceFunction.EuclideanDistanceSquare);
        }
    }

    public class KNN<CategoryType, DataType>
    {
        private List<KeyValuePair<CategoryType, DataType>> dataset;
        public IEqualityComparer<CategoryType> CategoryComparer
        {
            get;
            private set;
        }

        public KNN()
        {
            dataset = new List<KeyValuePair<CategoryType, DataType>>();
            CategoryComparer = EqualityComparer<CategoryType>.Default;
        }

        public KNN(IEqualityComparer<CategoryType> comparer)
        {
            dataset = new List<KeyValuePair<CategoryType, DataType>>();
            CategoryComparer = comparer;
        }

        public void AddTrainingData(DataType data, CategoryType category)
        {
            dataset.Add(new KeyValuePair<CategoryType, DataType>(category, data));
        }

        /// <summary>
        /// Find Category
        /// </summary>
        /// <param name="data">TestData</param>
        /// <param name="K">K</param>
        /// <param name="distanceFunction">Function To Calculate Distance Between DataType</param>
        /// <returns>Result Category</returns>
        /// <exception cref="InvalidOperationException">No Category Created Yet</exception>
        /// <exception cref="ArgumentException">K Must Bigget Than Zero</exception>
        public CategoryType FindCategory<DistanceType>(DataType data, int K, Func<DataType, DataType, DistanceType> distanceFunction)
        {
            return FindCategory(data, K, distanceFunction, Comparer<DistanceType>.Default);
        }

        /// <summary>
        /// Find Category With Custom DistanceComparer
        /// </summary>
        /// <param name="data">TestData</param>
        /// <param name="K">K</param>
        /// <param name="distanceFunction">Function To Calculate Distance Between DataType</param>
        /// <param name="distanceComparer">Function To Compare Distance</param>
        /// <returns>Result Category</returns>
        /// <exception cref="InvalidOperationException">No Category Created Yet</exception>
        /// <exception cref="ArgumentException">K Must Bigget Than Zero</exception>
        public CategoryType FindCategory<DistanceType>(DataType data, int K, Func<DataType, DataType, DistanceType> distanceFunction, IComparer<DistanceType> distanceComparer)
        {
            if (dataset.Count == 0)
            {
                throw new InvalidOperationException("No Category Created Yet");
            }
            if (K < 0)
            {
                throw new ArgumentException("K Must Bigget Than 0");
            }

            return
                DatasetEnumerator
                 .Select(x => new KeyValuePair<CategoryType, DistanceType>(x.Key, distanceFunction(data, x.Value)))
                 .OrderBy(x => x.Value, distanceComparer)
                 .Take(K)
                 .GroupBy(x => x.Key, CategoryComparer)
                 .OrderBy(x => x.Count())
                 .First().Key;
        }

        /// <summary>
        /// Return Enumerator Of Key-Value Pair Base On Each Value
        /// </summary>
        /// <remarks>If Internal Container 'dataset' Is List of keyValuePair, Just Enumerate The List</remarks>
        private IEnumerable<KeyValuePair<CategoryType, DataType>> DatasetEnumerator
        {
            get
            {
                return dataset;
            }
        }
    }
}
