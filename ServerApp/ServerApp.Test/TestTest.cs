using System;
using NUnit.Framework;

namespace ServerApp.Test
{   
    [TestFixture]
    public class SomethingTest
    {
        [SetUp]
        public void Setup()
        {
            
        }
        [Test]
        public void ThisIsTestTest()
        {
            Assert.AreEqual(1, 1);
        }

    }
}
