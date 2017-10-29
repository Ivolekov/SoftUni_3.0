using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoShare.Client.Core;
using PhotoShare.Data.Interfaces;
using PhotoShare.Data.Mocks;
using PhotoShare.Client.Interfaces;
using System.Linq;

namespace PhotoShare.Test
{
    [TestClass]
    public class AddTagTest
    {
        private CommandDispatcher dispacher;
        private IUnitOfWork unit;

        [TestInitialize]
        public void initialize()
        {
            this.unit = new UOWMock();
            this.dispacher = new CommandDispatcher(unit);
        }

        [TestMethod]
        public void TestCountChanges()
        {
            IExecutable exe = this.dispacher.DispatchCommand("AddTag", new string[] { "AddTag", "tagzzz" });
            exe.Execute();
            int count = this.unit.Tags.GetAll().ToList().Count;
            Assert.AreNotSame(0, count);
        }
    }
}
