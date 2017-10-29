namespace BashsoftTesting
{
    using System;
    using Lab.AdvancedCSharp.Bashsoft.Contracts;
    using Lab.AdvancedCSharp.Bashsoft.DataStructures;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void TestEmptyConstructor()
        {
            this.names = new SimpleSortedList<string>();
            Assert.AreEqual(16, this.names.Capacity);
            Assert.AreEqual(0, this.names.Size);
        }

        [TestMethod]
        public void TestConstructorWithInitialCapacity()
        {
            this.names = new SimpleSortedList<string>(50);
            Assert.AreEqual(50, this.names.Capacity);
            Assert.AreEqual(0, this.names.Size);
        }

        [TestMethod]
        public void TestConstructorWithInitialComparer()
        {
            this.names = new SimpleSortedList<string>(StringComparer.Ordinal);
            Assert.AreEqual(16, this.names.Capacity);
            Assert.AreEqual(0, this.names.Size);
        }

        [TestMethod]
        public void TestConstructorWithAllParameters()
        {
            this.names = new SimpleSortedList<string>(StringComparer.Ordinal, 32);
            Assert.AreEqual(32, this.names.Capacity);
            Assert.AreEqual(0, this.names.Size);
        }

        [TestMethod]
        public void TestAddIncreasesSize()
        {
            this.names.Add("Armen");
            Assert.AreEqual(1, this.names.Size);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddNullThrowsException()
        {
            this.names.Add(null);
        }

        [TestMethod]
        public void TestAddUnsortedDatalsHeldSorted()
        {
            this.names.Add("Rosen");
            this.names.Add("Georgi");
            this.names.Add("Balkan");
            
            Assert.AreEqual("Balkan,Georgi,Rosen", this.names.JoinWith(","));
        }

        [TestMethod]
        public void TestAddingMoreThanInitialCapacity()
        {
            for (int index = 0; index < 17; index++)
            {
                this.names.Add("Armen");
            }

            Assert.AreEqual(17, this.names.Size);
            Assert.AreNotEqual(16, this.names.Capacity);
        }

        [TestMethod]
        public void TestAddingAllFromCollectionIncreasesSize()
        {
            this.names.AddAll(new[] { "Armen", "Tosho" });
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
            this.names.AddAll(new[] { "Rosen", "Georgi", "Balkan" });
            Assert.AreEqual("Balkan,Georgi,Rosen", this.names.JoinWith(","));
        }

        [TestMethod]
        public void TestRemoveValidElementDecreasesSize()
        {
            this.names.Add("Armen");
            this.names.Add("Armen");
            this.names.Remove("Armen");
            Assert.AreEqual(1, this.names.Size);
        }

        [TestMethod]
        public void TestRemoveValidElementRemovesSelectedOne()
        {
            this.names.Add("jicata");
            this.names.Add("bojo");
            this.names.Remove("bojo");

            foreach (var name in this.names)
            {
                Assert.AreNotEqual("bojo", name);
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
            this.names.JoinWith(null);
        }

        [TestMethod]
        public void TestJoinWorksFine()
        {
            this.names.Add("Armen");
            this.names.Add("Armen");
            
            Assert.AreEqual("Armen-=-Armen", this.names.JoinWith("-=-"));
            Assert.AreEqual("ArmenArmen", this.names.JoinWith(""));
            Assert.AreEqual("Armen:Armen", this.names.JoinWith(":"));
        }
    }
}
