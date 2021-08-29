using Microsoft.VisualStudio.TestTools.UnitTesting;
using RunningMeanValue;

namespace TestMeanValue
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Testn1lM1nV3()
        {
            MeanValue inst = new MeanValue();
            double returnedValue;
            double expectedResult = 2.0;
            returnedValue = inst.RunMean(1, 1.0, 3.0);
            Assert.AreEqual(expectedResult, returnedValue);
        }
        [TestMethod]
        public void Testn2lM2nV5()
        {
            MeanValue inst = new MeanValue();
            double returnedValue;
            double expectedResult = 3.0;
            returnedValue = inst.RunMean(2, 2.0, 5.0);
            Assert.AreEqual(expectedResult, returnedValue);
        }
    }
}
