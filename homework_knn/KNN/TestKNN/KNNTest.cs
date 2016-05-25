using Classifiers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestKNN
{
    public abstract class KNNTestBase<CType, DType, DDType>
    {
        protected abstract Func<DType, DType, DDType> DistanceCalculateFunction
        {
            get;
        }
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

        protected abstract KNN<CType, DType> KnnKernal
        {
            get;
        }

        [TestMethod]
        public void TestSameQueryAndSample()
        {
            KnnKernal.AddTrainingData(Sample1, Class1);
            KnnKernal.AddTrainingData(Sample2, Class2);
            Assert.AreEqual(Class1, KnnKernal.FindCategory(Sample1, 1, DistanceCalculateFunction));
            Assert.AreEqual(Class2, KnnKernal.FindCategory(Sample2, 1, DistanceCalculateFunction));
        }

        [TestMethod]
        public void TestDifferentQueryAndSample()
        {
            KnnKernal.AddTrainingData(Sample1, Class1);
            KnnKernal.AddTrainingData(Sample2, Class2);
            Assert.AreEqual(Class1, KnnKernal.FindCategory(SampleCloseTo1, 1, DistanceCalculateFunction));
        }

        [TestMethod]
        public void TestQueryKMoreThanSample()
        {
            KnnKernal.AddTrainingData(Sample1, Class1);
            KnnKernal.AddTrainingData(Sample2, Class2);
            Assert.AreEqual(Class1, KnnKernal.FindCategory(Sample1, 10, DistanceCalculateFunction));
            Assert.AreEqual(Class2, KnnKernal.FindCategory(Sample2, 10, DistanceCalculateFunction));
        }

        [TestMethod]
        public void TestAddToSameClass()
        {
            KnnKernal.AddTrainingData(Sample1, Class1);
            KnnKernal.AddTrainingData(Sample2, Class1);
            KnnKernal.AddTrainingData(Sample2, Class2);
            Assert.AreEqual(Class1, KnnKernal.FindCategory(SampleEquallyCloseTo1And2, 3, DistanceCalculateFunction));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestQueryFromZeroCategory()
        {
            KnnKernal.FindCategory(Sample1, 1, DistanceCalculateFunction);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNegtiveK()
        {
            KnnKernal.AddTrainingData(Sample1, Class1);
            KnnKernal.FindCategory(Sample1, -1, DistanceCalculateFunction);
        }

        [TestMethod]
        public void TestQueryFromZeroCategoryAndNegtiveK()
        {
            try
            {
                KnnKernal.FindCategory(Sample1, -1, DistanceCalculateFunction);
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

    [TestClass]
    public class KNNTestReferenceTypeData : KNNTestBase<int, List<double>, double>
    {
        protected override Func<List<double>, List<double>, double> DistanceCalculateFunction
        {
            get
            {
                return DistanceFunction.EuclideanDistanceSquare;
            }
        }

        protected override int Class1
        {
            get
            {
                return 1;
            }
        }

        protected override int Class2
        {
            get
            {
                return 2;
            }
        }

        protected override List<double> Sample1
        {
            get
            {
                return new List<double>() { 1, 2, 3 };
            }
        }

        protected override List<double> Sample2
        {
            get
            {
                return new List<double>() { 5, 6, 7 };
            }
        }

        protected override List<double> SampleCloseTo1
        {
            get
            {
                return new List<double>() { 0, 1, 2 };
            }
        }

        protected override List<double> SampleEquallyCloseTo1And2
        {
            get
            {
                return new List<double>() { 3, 4, 5 };
            }
        }

        private KNN<int, List<double>> _KnnKernal;

        protected override KNN<int, List<double>> KnnKernal
        {
            get
            {
                return _KnnKernal;
            }
        }

        [TestInitialize]
        public void Initialize()
        {
            this._KnnKernal = new KNN<int, List<double>>();
        }
    }


    [TestClass]
    public class KNNTestValueTypeData : KNNTestBase<int, int, int>
    {
        protected override Func<int, int, int> DistanceCalculateFunction
        {
            get
            {
                return (x, y) => Math.Abs(x - y);
            }
        }

        protected override int Class1
        {
            get
            {
                return 1;
            }
        }

        protected override int Class2
        {
            get
            {
                return 2;
            }
        }

        protected override int Sample1
        {
            get
            {
                return 1;
            }
        }

        protected override int Sample2
        {
            get
            {
                return 5;
            }
        }

        protected override int SampleCloseTo1
        {
            get
            {
                return 0;
            }
        }

        protected override int SampleEquallyCloseTo1And2
        {
            get
            {
                return 3;
            }
        }

        private KNN<int, int> _KnnKernal;

        protected override KNN<int, int> KnnKernal
        {
            get
            {
                return _KnnKernal;
            }
        }

        [TestInitialize]
        public void Initialize()
        {
            this._KnnKernal = new KNN<int, int>();
        }
    }

    public class ReferenceCategoryType : IEquatable<ReferenceCategoryType>
    {
        public ReferenceCategoryType(int value)
        {
            this.Value = value;
        }

        public int Value
        {
            get;
            private set;
        }

        public override bool Equals(Object obj)
        {
            if (obj is ReferenceCategoryType)
            {
                return Value == (obj as ReferenceCategoryType).Value;
            }

            return false;
        }

        bool IEquatable<ReferenceCategoryType>.Equals(ReferenceCategoryType other)
        {
            return Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }

    public class ReferenceCategoryTypeComaparer : IEqualityComparer<ReferenceCategoryType>
    {
        bool IEqualityComparer<ReferenceCategoryType>.Equals(ReferenceCategoryType x, ReferenceCategoryType y)
        {
            return x.Value == y.Value;
        }

        int IEqualityComparer<ReferenceCategoryType>.GetHashCode(ReferenceCategoryType obj)
        {
            return obj.Value.GetHashCode();
        }
    }


    public class KNNTestReferenceTypeCategoryBase : KNNTestBase<ReferenceCategoryType, int, int>
    {
        protected override Func<int, int, int> DistanceCalculateFunction
        {
            get
            {
                return (x, y) => Math.Abs(x - y);
            }
        }

        protected override ReferenceCategoryType Class1
        {
            get
            {
                return new ReferenceCategoryType(1);
            }
        }

        protected override ReferenceCategoryType Class2
        {
            get
            {
                return new ReferenceCategoryType(2);
            }
        }

        protected override int Sample1
        {
            get
            {
                return 1;
            }
        }

        protected override int Sample2
        {
            get
            {
                return 5;
            }
        }

        protected override int SampleCloseTo1
        {
            get
            {
                return 0;
            }
        }

        protected override int SampleEquallyCloseTo1And2
        {
            get
            {
                return 3;
            }
        }

        protected KNN<ReferenceCategoryType, int> _KnnKernal;

        protected override KNN<ReferenceCategoryType, int> KnnKernal
        {
            get
            {
                return _KnnKernal;
            }

        }
    }

    [TestClass]
    public class KNNTestReferenceTypeCategoryWithIEquable : KNNTestReferenceTypeCategoryBase
    {
        [TestInitialize]
        public void Initialize()
        {
            this._KnnKernal = new KNN<ReferenceCategoryType, int>();
        }
    }

    [TestClass]
    public class KNNTestReferenceTypeCategoryWithIEquallyComparer : KNNTestReferenceTypeCategoryBase
    {
        [TestInitialize]
        public void Initialize()
        {
            this._KnnKernal = new KNN<ReferenceCategoryType, int>(new ReferenceCategoryTypeComaparer());
        }
    }
}
