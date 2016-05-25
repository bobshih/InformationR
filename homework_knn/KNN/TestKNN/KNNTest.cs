using homework_knn;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestKNN
{
    public abstract class KNNTestBase<CType, DType>
    {
        public abstract DType Sample1
        {
            get;
        }
        public abstract DType Sample2
        {
            get;
        }
        public abstract DType SampleCloseTo1
        {
            get;
        }
        public abstract DType SampleEquallyCloseTo1And2
        {
            get;
        }
        public abstract IComparer<CType> CategoryComparer
        {
            get;
        }
    }
    
    //[TestClass]
    public abstract class KNNTestBase<CType,DType,DDType>
    { 
        protected abstract Func<DType, DType, DDType> DistanceFunction{
        get;}
                protected abstract CType Class1
        {
            get;
        }

        protected abstract CType Class2
        {
            get;
        }

        protected abstract DType Sample1
        {
            get;
        }

        protected abstract DType Sample2
        {
            get;
        }

        protected abstract DType SampleCloseTo1
        {
            get;
        }

        protected abstract DType SampleEquallyCloseTo1And2
        {
            get;
        }

        protected abstract KNN<CType,DType> KnnKernal{get;}

        [TestMethod]
        public void TestSameQueryAndSample()
        {
            KnnKernal.AddTrainingData(Sample1, Class1);
            KnnKernal.AddTrainingData(Sample2, Class2);
            Assert.AreEqual(1, KnnKernal.FindCategory(Sample1, 1, DistanceFunction));
            Assert.AreEqual(2, KnnKernal.FindCategory(Sample2, 1, DistanceFunction));
        }

        [TestMethod]
        public void TestDifferentQueryAndSample()
        {
            KnnKernal.AddTrainingData(Sample1, 1);
            KnnKernal.AddTrainingData(Sample2, 2);
            Assert.AreEqual(1, KnnKernal.FindCategory(SampleCloseTo1, 1, DistanceFunction));
        }

        [TestMethod]
        public void TestQueryKMoreThanSample()
        {
            KnnKernal.AddTrainingData(Sample1, 1);
            KnnKernal.AddTrainingData(Sample2, 2);
            Assert.AreEqual(1, KnnKernal.FindCategory(Sample1, 10, DistanceFunction));
            Assert.AreEqual(2, KnnKernal.FindCategory(Sample2, 10, DistanceFunction));
        }

        [TestMethod]
        public void TestAddToSameClass()
        {
            KnnKernal.AddTrainingData(Sample1, 1);
            KnnKernal.AddTrainingData(Sample2, 1);
            KnnKernal.AddTrainingData(Sample2, 2);
            Assert.AreEqual(1, KnnKernal.FindCategory(SampleEquallyCloseTo1And2, 2, DistanceFunction));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestQueryFromZeroCategory()
        {
            KnnKernal.FindCategory(Sample1, 1, DistanceFunction);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNegtiveK()
        {
            KnnKernal.AddTrainingData(Sample1, 1);
            KnnKernal.FindCategory(Sample1, -1, DistanceFunction);
        }

        [TestMethod]
        public void TestQueryFromZeroCategoryAndNegtiveK()
        {
            try
            {
                KnnKernal.FindCategory(Sample1, -1, DistanceFunction);
                Assert.Fail("Should Have Some Exception");
            }
            catch (ArgumentException)
            {
            }
            catch (InvalidOperationException)
            {
            }
        }

    //[TestClass]
    public class KNNTestBase
    {
        protected Func<List<double>, List<double>, double> distanceFunction = DistanceFunction.EuclideanDistanceSquare;
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

        private KNN<int, List<double>> knn;

        [TestInitialize]
        public void Initialize()
        {
            knn = new KNN<int, List<double>>();
        }

        [TestMethod]
        public void TestSameQueryAndSample()
        {
            knn.AddTrainingData(SampleList1, 1);
            knn.AddTrainingData(SampleList2, 2);
            Assert.AreEqual(1, knn.FindCategory(SampleList1, 1, distanceFunction));
            Assert.AreEqual(2, knn.FindCategory(SampleList2, 1, distanceFunction));
        }

        [TestMethod]
        public void TestDifferentQueryAndSample()
        {
            knn.AddTrainingData(SampleList1, 1);
            knn.AddTrainingData(SampleList2, 2);
            Assert.AreEqual(1, knn.FindCategory(SampleListCloseToList1MoreThan2, 1, distanceFunction));
        }

        [TestMethod]
        public void TestQueryKMoreThanSample()
        {
            knn.AddTrainingData(SampleList1, 1);
            knn.AddTrainingData(SampleList2, 2);
            Assert.AreEqual(1, knn.FindCategory(SampleList1, 10, distanceFunction));
            Assert.AreEqual(2, knn.FindCategory(SampleList2, 10, distanceFunction));
        }

        [TestMethod]
        public void TestAddToSameClass()
        {
            knn.AddTrainingData(SampleList1, 1);
            knn.AddTrainingData(SampleList2, 1);
            knn.AddTrainingData(SampleList2, 2);
            Assert.AreEqual(1, knn.FindCategory(SampleListEquallyCloseToList1AndList2, 2, distanceFunction));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestQueryFromZeroCategory()
        {
            knn.FindCategory(SampleList1, 1, distanceFunction);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNegtiveK()
        {
            knn.AddTrainingData(SampleList1, 1);
            knn.FindCategory(SampleList1, -1, distanceFunction);
        }

        [TestMethod]
        public void TestQueryFromZeroCategoryAndNegtiveK()
        {
            try
            {
                knn.FindCategory(SampleList1, -1, distanceFunction);
                Assert.Fail("Should Have Some Exception");
            }
            catch (ArgumentException)
            {
            }
            catch (InvalidOperationException)
            {
            }
        }

        [TestClass]
        public class Testtttt : KNNTestBase
        {
        }
    }
}
