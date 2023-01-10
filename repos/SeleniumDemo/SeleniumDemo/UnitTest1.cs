using NUnit.Framework;

namespace SeleniumDemo
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            TestContext.Progress.WriteLine("Setup");
        }

        [Test]
        public void Test1()
        {
            TestContext.WriteLine("test case 1");
        }
        [TearDown]
        public void close()
        {
            TestContext.WriteLine("Close Test Case");
        }
    }
}