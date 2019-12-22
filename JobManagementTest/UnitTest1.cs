using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JobManagementTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_TEST()
        {
            int x = 2;
            Assert.IsFalse(x == 1);
        }
    }
}
