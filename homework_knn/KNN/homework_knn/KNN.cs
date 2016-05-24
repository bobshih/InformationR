using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_knn
{
    public class KNN
    {
        Dictionary<int, List<List<double>>> dataset;


        public void AddTrainingData(List<double> data, int category)
        {
            List<List<double>> value = dataset.GetOrCreate(category);
            value.Add(data);/*.clone if need*/
        }

        public int FindCategory(List<double> data, int N)
        {
            return
                DatasetEnumerator
                 .Select(x => new KeyValuePair<int, double>(x.Key, DistanceFunction(data, x.Value)))
                 .OrderByDescending(x => x.Value)
                 .Take(N)
                 .GroupBy(x => x.Key)
                 .OrderBy(x => x.Count())
                 .First().Key;
        }

        private double DistanceFunction(List<double> left, List<double> right)
        {
            throw new NotImplementedException();
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
