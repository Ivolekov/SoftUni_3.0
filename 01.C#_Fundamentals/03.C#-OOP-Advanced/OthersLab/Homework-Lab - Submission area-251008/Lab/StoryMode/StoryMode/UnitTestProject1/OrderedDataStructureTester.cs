using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Executor.Contracts;
using Executor.DataStructures;
using System.Collections.Generic;

namespace BashSoftTesting
{
    [TestClass]
    public class OrderedDataStructureTester
    {
        private ISimpleOrderedBag<string> names;
        [TestInitialize]
        public void SetUp()
        {
            this.names = new SimpleSortedList<string>();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TEstAddNullThrowsException()
        {
            this.names.Add(null);
        }
        [TestMethod]
        public void TestAddIncreaseSize()
        {
            this.names.Add("Nasko");
            Assert.AreEqual(1, this.names.Size);
        }
        [TestMethod]
        public void TestEmptyCtor()
        {
            this.names = new SimpleSortedList<string>();
            Assert.AreEqual(this.names.Capacity, 16);
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
        public void TestCtorWithInitialCapacity()
        {
            this.names = new SimpleSortedList<string>(20);
            Assert.AreEqual(this.names.Capacity, 20);
            Assert.AreEqual(this.names.Size, 0);
        }
        [TestMethod]
        public void TestCtorWithInitialComparer()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
        }
        [TestMethod]
        public void TestAddUnsortedDataIsHeldSorted()
        {
            this.names.Add("Rosen");
            this.names.Add("Georgi");
            this.names.Add("Balkan");
            int count = 0;
            foreach (var name in this.names)
            {
                if (count == 0)
                    Assert.AreEqual("Balkan", name);
                else if (count == 1)
                    Assert.AreEqual("Georgi", name);
                else
                    Assert.AreEqual("Rosen", name);
                count++;
            }
        }
        [TestMethod]
        public void TestAddingMoreThanInitialCapacity()
        {
            for (int i = 0; i < 17; i++)
            {
                this.names.Add("test");
            }
            Assert.AreNotEqual(this.names.Size, 16);
        }
        [TestMethod]
        public void TestAddingAllFromCollectionIncreaseSize()
        {
            var list = new List<string> { "test1", "test2" };
            this.names.AddAll(list);
            Assert.AreEqual(this.names.Size, list.Count);
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
            var list = new List<string> { "test2", "test1", "test0" };
            this.names.AddAll(list);
            int count = 0;
            foreach (var name in this.names)
            {
                if (count == 0)
                    Assert.AreEqual("test0", name);
                else if (count == 1)
                    Assert.AreEqual("test1", name);
                else
                    Assert.AreEqual("test2", name);
                count++;
            }
        }
        [TestMethod]
        public void TestRemoveValidElementDecreasesSize()
        {
            this.names.Add("test");
            this.names.Add("test1");
            this.names.Remove("test");
            Assert.AreEqual(this.names.Size, 1);
        }
        [TestMethod]
        public void TestRemoveValidElementRemovesSelectedOne()
        {
            this.names.Add("ivan");
            this.names.Add("nasko");
            this.names.Remove("ivan");
            foreach (var name in names)
            {
                Assert.AreNotEqual(name, "ivan");
            }
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
            this.names.JointWith(null);
        }
        [TestMethod]
        public void TestJoinWorksFine()
        {
            this.names.Add("pesho");
            this.names.Add("ivan");
            this.names.Add("spas");
            Assert.AreEqual(this.names.JointWith(","),"ivan,pesho,spas");
        }
    }
}
