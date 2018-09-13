using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DhHomework.Tests
{
    [TestClass]
    public class ArraySortTests
    {
        [TestMethod]
        public void CanSortWithNoAdjacentItemsLessThanThreshold()
        {
            var items = new[] { 3, 6, 4, 2, 5, 3, 8 };
            var threshold = 4;

            var count = ArraySort.MoveItemsLessThanThresholdToStart(items, threshold);

            IsArrayContentEqual(new[] { 3, 2, 3, 6, 4, 5, 8 }, items);
            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void CanSortWithAdjacentItemsLessThanThreshold()
        {
            var items = new[] { 3, 6, 4, 2, 5, 3, 3, 1, 2, 3, 8 };
            var threshold = 4;

            var count = ArraySort.MoveItemsLessThanThresholdToStart(items, threshold);

            IsArrayContentEqual(new[] { 3, 2, 3, 3, 1, 2, 3, 6, 4, 5, 8 }, items);
            Assert.AreEqual(7, count);
        }

        [TestMethod]
        public void CanSortEmpty()
        {
            var items = new int[] { };
            var threshold = 4;

            var count = ArraySort.MoveItemsLessThanThresholdToStart(items, threshold);

            IsArrayContentEqual(new int[] { }, items);
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void CanSortNoItemsLessThanThreshold()
        {
            var items = new[] { 6, 4, 5, 8 };
            var threshold = 4;

            var count = ArraySort.MoveItemsLessThanThresholdToStart(items, threshold);

            IsArrayContentEqual(new[] { 6, 4, 5, 8 },items);
            Assert.AreEqual(0,count);
        }

        [TestMethod]
        public void CanSortAllItemsLessThanThreshold()
        {
            var items = new[] { 3, 1, 2, 3 };
            var threshold = 4;

            var count = ArraySort.MoveItemsLessThanThresholdToStart(items, threshold);

            IsArrayContentEqual(new[] { 3, 1, 2, 3 },items);
            Assert.AreEqual(4,count);
        }

        private static void IsArrayContentEqual(int[] a, int[] b)
        {
            if (a.Length != b.Length)
                throw new AssertFailedException("Lengths not equal");
            for (var i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                    throw new AssertFailedException($"Values at {i} not equal.");
            }
        }
    }
}
