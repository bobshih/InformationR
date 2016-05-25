using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_knn
{
    public class KNN
    {
        private Dictionary<int, List<List<double>>> dataset = new Dictionary<int, List<List<double>>>();
        private Func<List<double>, List<double>, double> distanceFunction = DistanceFunction.EuclideanDistanceSquare;


        public void AddTrainingData(List<double> data, int category)
        {
            List<List<double>> value = dataset.GetOrCreate(category);
            value.Add(data);/*.clone if need*/
        }

        /// <exception cref="InvalidOperationException">No Category Created Yet</exception>
        /// <exception cref="ArgumentException">K Must Bigget Than Zero</exception>
        public int FindCategory(List<double> data, int K)
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
                 .Select(x => new KeyValuePair<int, double>(x.Key, distanceFunction(data, x.Value)))
                 .OrderBy(x => x.Value)
                 .Take(K)
                 .GroupBy(x => x.Key)
                 .OrderBy(x => x.Count())
                 .First().Key;
        }

        /// <summary>
        /// Return Enumerator Of Key-Value Pair Base On Each Value
        /// </summary>
        /// <remarks>If Internal Container 'dataset' Is List of keyValuePair, Just Enumerate The List</remarks>
        private IEnumerable<KeyValuePair<int, List<double>>> DatasetEnumerator
        {
            get
            {
                foreach (var category_datalist_pair in dataset)
                {
                    foreach (var data in category_datalist_pair.Value)
                    {
                        yield return new KeyValuePair<int, List<double>>(category_datalist_pair.Key, data);
                    }
                }
            }
        }
    }

    public class KNN<CategoryType, DataType>
    {
        private List<KeyValuePair<CategoryType, DataType>> dataset = new List<KeyValuePair<CategoryType, DataType>>();

        public void AddTrainingData(DataType data, CategoryType category)
        {
            dataset.Add(new KeyValuePair<CategoryType, DataType>(category, data));
        }

        /// <exception cref="InvalidOperationException">No Category Created Yet</exception>
        /// <exception cref="ArgumentException">K Must Bigget Than Zero</exception>
        public CategoryType FindCategory<DistanceType>(DataType data, int K, Func<DataType, DataType, DistanceType> distanceFunction)
        {
            return FindCategory(data, K, distanceFunction, Comparer<DistanceType>.Default, EqualityComparer<CategoryType>.Default);
        }

        /// <exception cref="InvalidOperationException">No Category Created Yet</exception>
        /// <exception cref="ArgumentException">K Must Bigget Than Zero</exception>
        public CategoryType FindCategory<DistanceType>(DataType data, int K, Func<DataType, DataType, DistanceType> distanceFunction)
        {
            return FindCategory(data, K, distanceFunction, Comparer<DistanceType>.Default, EqualityComparer<CategoryType>.Default);
        }

        /// <exception cref="InvalidOperationException">No Category Created Yet</exception>
        /// <exception cref="ArgumentException">K Must Bigget Than Zero</exception>
        public CategoryType FindCategory<DistanceType>(DataType data, int K, Func<DataType, DataType, DistanceType> distanceFunction, IComparer<DistanceType> distanceComparer, IEqualityComparer<CategoryType> categoryComparer)
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
                 .GroupBy(x => x.Key, categoryComparer)
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
