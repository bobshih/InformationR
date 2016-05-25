using homework_knn;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestKNN
{
    [TestClass]
    public class KNNTest
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
                return new List<double>() { 5, 6, 7 };
            }
        }

        private List<double> SampleListCloseToList1MoreThan2
        {
            get
            {
                return new List<double>() { 0, 1, 2 };
            }
        }

        private List<double> SampleListEquallyCloseToList1AndList2
        {
            get
            {
                return new List<double>() { 3, 4, 5 };
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
        public void TestAddToSameClass()
        {
            knn.AddTrainingData(SampleList1, 1);
            knn.AddTrainingData(SampleList2, 1);
            knn.AddTrainingData(SampleList2, 2);
            Assert.AreEqual(1, knn.FindCategory(SampleListEquallyCloseToList1AndList2, 2));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestQueryFromZeroCategory()
        {
            knn.FindCategory(SampleList1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNegtiveK()
        {
            knn.AddTrainingData(SampleList1, 1);
            knn.FindCategory(SampleList1, -1);
        }

        [TestMethod]
        public void TestQueryFromZeroCategoryAndNegtiveK()
        {
            try
            {
                knn.FindCategory(SampleList1, -1);
                Assert.Fail("Should Have Some Exception");
            }
            catch (ArgumentException)
            {
            }
            catch (InvalidOperationException)
            {
            }
        }
    }
}
