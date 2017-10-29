namespace BashSoftTesting
{
    using System;
    using System.Collections.Generic;
    using Executor.Contracts.DataStructures;
    using Executor.DataStructures;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class OrderedDataStructureTester
    {
        private ISimpleOrderedBag<string> names;

        [TestMethod]
        public void TestEmptyCtor()
        {
            this.names = new SimpleSortedList<string>();
            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
        }

        [TestMethod]
        public void TestCtorWithInitialapacity()
        {
            this.names = new SimpleSortedList<string>(20);
            Assert.AreEqual(this.names.Capacity, 20);
            Assert.AreEqual(this.names.Size, 0);
        }

        [TestMethod]
        public void TestCtorWithAllParams()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase, 30);
            Assert.AreEqual(this.names.Capacity, 30);
            Assert.AreEqual(this.names.Size, 0);
        }

        [TestMethod]
        public void TestCtorWithInitialComparer()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
        }

        [TestInitialize]
        public void SetUp()
        {
            this.names = new SimpleSortedList<string>();
        }

        [TestMethod]
        public void TestAddIncreasesSize()
        {
            this.names.Add("Nasko");
            Assert.AreEqual(1, this.names.Size);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddNullThrowExeption()
        {
            this.names.Add(null);
        }

        [TestMethod]
        public void TestAddUnsortedDataIsHeldSorted()
        {
            this.names.Add("Rosen");
            this.names.Add("Georgi");
            this.names.Add("Balkan");

            string result = string.Empty;

            foreach (var name in this.names)
            {
                result += name;
            }

            Assert.AreEqual(result, "BalkanGeorgiRosen");
        }

        [TestMethod]
        public void TestAddingMoreThanInitialCapacity()
        {
            for (int i = 0; i < 17; i++)
            {
                this.names.Add("!");
            }

            Assert.AreEqual(17, this.names.Size);
            Assert.AreNotEqual(16, this.names.Capacity);
        }

        [TestMethod]
        public void TestAddingAllFromCollectionIncreasesSize()
        {
            List<string> list = new List<string>();
            list.Add("1");
            list.Add("2");

            this.names.AddAll(list);

            Assert.AreEqual(2, this.names.Size);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddingAllFromNullThrowsException()
        {
            this.names.AddAll(null);
        }

        [TestMethod]
        public void TestAddAllKeepsSorted()
        {
            List<string> list = new List<string>();
            list.Add("c");
            list.Add("b");
            list.Add("a");
            list.Add("d");
            list.Add("e");
            this.names.AddAll(list);
            string result = string.Empty;
            foreach (var name in this.names)
            {
                result += name;
            }

            Assert.AreEqual(result, "abcde");
        }

        [TestMethod]
        public void TestRemoveValidElementDecreasesSize()
        {
            this.names.Add("1");
            this.names.Remove("1");

            Assert.AreEqual(0, this.names.Size);
        }

        [TestMethod]
        public void TestRemoveValidElementRemovesSelectedOne()
        {
            this.names.Add("ivan");
            this.names.Add("nasko");
            this.names.Remove("ivan");
            string result = string.Empty;
            foreach (var name in this.names)
            {
                result += name;
            }
            Assert.AreNotEqual(result, "ivan");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRemovingNullThrowsException()
        {
            this.names.Remove(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestJoinWithNull()
        {
            this.names.Add("1");
            this.names.Add("2");
            this.names.Add("3");
            this.names.JoinWith(null);
        }

        [TestMethod]
        public void TestJoinWorksFine()
        {
            this.names.Add("1");
            this.names.Add("2");
            this.names.Add("3");
            string result = this.names.JoinWith(", ");
            Assert.AreEqual(result, "1, 2, 3");
        }
    }
}