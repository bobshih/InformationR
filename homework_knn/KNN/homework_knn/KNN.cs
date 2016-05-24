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
        Dictionary<int, List<List<double>>> dataset = new Dictionary<int, List<List<double>>>();


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
                 .Select(x => new KeyValuePair<int, double>(x.Key, DistanceFunction(data, x.Value)))
                 .OrderByDescending(x => x.Value)
                 .Reverse()
                 .Take(K)
                 .GroupBy(x => x.Key)
                 .OrderBy(x => x.Count())
                 .First().Key;
        }

        /// <summary>
        /// return RMS of two list
        /// </summary>
        /// <exception cref="ArgumentException">Size Not Match</exception>
        private double DistanceFunction(List<double> left, List<double> right)
        {
            if (left.Count != right.Count)
            {
                throw new ArgumentException("Size Not Match");
            }
            /*
            double sum = 0;
            int count = left.Count;
            for (int i = 0; i < left.Count; ++i)
            {
                double diff = left[i] - right[i];
                sum += diff * diff;
            }
            return Math.Sqrt(sum / left.Count);
            */
            return Math.Sqrt(left.Zip(right, (x, y) => x - y).Select(x => x * x).Sum() / left.Count);
        }

        /// <summary>
        /// Return Enumerator Of Key-Value Pair 
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
}
