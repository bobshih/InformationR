using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classifiers
{
    public static class DistanceFunction
    {
        /// <summary>
        /// return RMS of two list
        /// </summary>
        /// <exception cref="ArgumentException">Size Not Match</exception>
        public static double EuclideanDistanceSquare(List<double> left, List<double> right)
        {
            if (left.Count != right.Count)
            {
                throw new ArgumentException("Size Not Match");
            }
            return left.Zip(right, (x, y) => x - y).Select(x => x * x).Sum();
        }
    }
}
