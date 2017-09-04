using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UdpLibrary;

namespace UnitTestProject
{
    [TestClass]
    public class StatisticUnitTest
    {
        [TestMethod]
        public void TestD()
        {
            Dictionary<int, long> _numDictionary = new Dictionary<int, long> { { 1, 2 }, { 2, 1 }, { 3, 2 } };
            var array = _numDictionary.ToArray();
            var stat = new Statistic(array);
            double d = stat.D();
            Assert.AreEqual(0, d);
        }

        [TestMethod]
        public void TestSD()
        {
            Dictionary<int, long> _numDictionary = new Dictionary<int, long> { { 1, 2 }, { 2, 1 }, { 3, 2 } };
            var array = _numDictionary.ToArray();
            var stat = new Statistic(array);
            double sd = stat.SD();
            Assert.AreEqual(1, sd);
        }
        [TestMethod]
        public void TestMedian()
        {
            Dictionary<int, long> _numDictionary = new Dictionary<int, long> {{1, 2}, {2, 1}, {3, 2}};
            var array = _numDictionary.ToArray();
            var stat = new Statistic(array);
            double median = stat.Median();
            Assert.AreEqual(2, median);
        }

        [TestMethod]
        public void TestMode()
        {
            Dictionary<int, long> _numDictionary = new Dictionary<int, long> { { 1, 2 }, { 2, 1 }, { 3, 2 }, {4, 6}, {5, 1} };
            var array = _numDictionary.ToArray();
            var stat = new Statistic(array);
            double mode = stat.Mode();
            Assert.AreEqual(4, mode);
        }
    }
}
