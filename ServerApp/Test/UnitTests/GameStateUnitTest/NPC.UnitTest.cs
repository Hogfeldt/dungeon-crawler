using System;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class Class1
    {
        [SetUp]
        public void setup()
        { }

        [Test]
        public void TestTest()
        {
            Assert.AreEqual(1, 1);
        }
    }
}
