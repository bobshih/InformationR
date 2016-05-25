using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classifiers;

namespace TestKNN
{
    [TestClass]
    public class DistanceFunctionTest
    {
        [TestMethod]
        public void TestEuclideanDistance()
        {
            var distance = DistanceFunction.EuclideanDistanceSquare(new List<double>() { 0, 0, 0, 0 }, new List<double>() { 1, 2, 3, 4 });
            Assert.AreEqual(1 + 4 + 9 + 16, distance);
        }

        [TestMethod]
        public void TestEuclideanDistance2()
        {
            var distance = DistanceFunction.EuclideanDistanceSquare(new List<double>() { -1, -2, -3, -4 }, new List<double>() { 1, 2, 3, 4 });
            Assert.AreEqual(4 + 16 + 36 + 64, distance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestEuclideanDistanceDifferentSize()
        {
            var distance = DistanceFunction.EuclideanDistanceSquare(new List<double>() { 0, 0, 0, 0 }, new List<double>() { 1, 2, 3, 4, 5 });
        }
    }
}
