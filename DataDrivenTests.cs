using NUnit.Framework;

namespace WebAutomationFramework
{
    public class DataDrivenTests
    {
        [TestFixture(typeof(int))]
        [TestFixture(typeof(string))]
        public class GenericTestFixture<T>
        {
            [Test]
            public void TestType()
            {
                Assert.Pass($"The generic test type is {typeof(T)}");
            }
        }
    }
}