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
        private KNN knn;

        [TestInitialize]
        public void Initialize()
        {
            knn = new KNN();
        }

        [TestMethod]
        public void TestSameQueryAndSample()
        {
            var list1 = 
            var list2 = new List<double>() { 4, 5, 6 };
            knn.AddTrainingData(list1, 1);
            knn.AddTrainingData(list2, 2);
            Assert.AreEqual(knn.FindCategory(list1, 1), 1);
            Assert.AreEqual(knn.FindCategory(list2, 1), 2);
        }

        [TestMethod]
        public void TestQueryKMoreThanSample()
        {
            var list1 = new List<double>() { 1, 2, 3 };
            var list2 = new List<double>() { 4, 5, 6 };
            knn.AddTrainingData(list1, 1);
            knn.AddTrainingData(list2, 2);
            Assert.AreEqual(knn.FindCategory(list1, 1), 1);
            Assert.AreEqual(knn.FindCategory(list2, 1), 2);
        }
    }
}
