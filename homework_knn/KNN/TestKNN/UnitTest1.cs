using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework_knn;
using System.Collections.Generic;

namespace TestKNN
{
    [TestClass]
    public class UnitTest1
    {
        private List<double> SampleList1
        {
            get
            {
                return new List<double>() { 1, 2, 3 };
            }
        }

        private List<double> SampleList2
        {
            get
            {
                return new List<double>() { 4, 5, 6 };
            }
        }

        private List<double> SampleListCloseToList1MoreThan2
        {
            get
            {
                return new List<double>() { 0, 1, 2 };
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
            knn.AddTrainingData(SampleList1, 1);
            knn.AddTrainingData(SampleList2, 2);
            Assert.AreEqual(1, knn.FindCategory(SampleList1, 1));
            Assert.AreEqual(2, knn.FindCategory(SampleList2, 1));
        }

        [TestMethod]
        public void TestDifferentQueryAndSample()
        {
            knn.AddTrainingData(SampleList1, 1);
            knn.AddTrainingData(SampleList2, 2);
            Assert.AreEqual(1, knn.FindCategory(SampleListCloseToList1MoreThan2, 1));
        }

        [TestMethod]
        public void TestQueryKMoreThanSample()
        {
            knn.AddTrainingData(SampleList1, 1);
            knn.AddTrainingData(SampleList2, 2);
            Assert.AreEqual(1, knn.FindCategory(SampleList1, 10));
            Assert.AreEqual(2, knn.FindCategory(SampleList2, 10));
        }


        [TestMethod]
        public void TestQueryFromZeroCategory()
        {
            knn.AddTrainingData(SampleList1, 1);
            knn.AddTrainingData(SampleList2, 2);
            Assert.AreEqual(1, knn.FindCategory(SampleList1, 10));
            Assert.AreEqual(2, knn.FindCategory(SampleList2, 10));
        }
    }
}
