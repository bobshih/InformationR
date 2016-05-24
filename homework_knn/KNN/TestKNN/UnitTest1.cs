using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework_knn;
using System.Collections.Generic;

namespace TestKNN
{
    [TestClass]
    public class UnitTest1
    {
        private List<double> list1
        {
            get
            {
                return new List<double>() { 1, 2, 3 };
            }
        }

        private List<double> list2
        {
            get
            {
                return new List<double>() { 4, 5, 6 };
            }
        }

        private KNN knn;

        [TestInitialize]
        public void Initialize()
        {
            knn = new KNN();
        }

        [TestMethod]
        public void TestSameQueryAndSample()
        {
            knn.AddTrainingData(list1, 1);
            knn.AddTrainingData(list2, 2);
            Assert.AreEqual(1, knn.FindCategory(list1, 1));
            Assert.AreEqual(2, knn.FindCategory(list2, 1));
        }

        [TestMethod]
        public void TestQueryKMoreThanSample()
        {
            knn.AddTrainingData(list1, 1);
            knn.AddTrainingData(list2, 2);
            Assert.AreEqual(1, knn.FindCategory(list1, 10));
            Assert.AreEqual(2, knn.FindCategory(list2, 10));
        }
    }
}
