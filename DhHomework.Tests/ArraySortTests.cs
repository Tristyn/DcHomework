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

            IsArrayContentEqual(items, new[] { 3, 2, 3, 6, 4, 5, 8 });
            Assert.AreEqual(count, 3);
        }

        [TestMethod]
        public void CanSortWithAdjacentItemsLessThanThreshold()
        {
            var items = new[] { 3, 6, 4, 2, 5, 3, 3, 1, 2, 3, 8 };
            var threshold = 4;

            var count = ArraySort.MoveItemsLessThanThresholdToStart(items, threshold);

            IsArrayContentEqual(items, new[] { 3, 2, 3, 3, 1, 2, 3, 6, 4, 5, 8 });
            Assert.AreEqual(count, 7);
        }

        [TestMethod]
        public void CanSortEmpty()
        {
            var items = new int[] { };
            var threshold = 4;

            var count = ArraySort.MoveItemsLessThanThresholdToStart(items, threshold);

            IsArrayContentEqual(items, new int[] { });
            Assert.AreEqual(count, 0);
        }

        [TestMethod]
        public void CanSortNoItemsLessThanThreshold()
        {
            var items = new[] { 6, 4, 5, 8 };
            var threshold = 4;

            var count = ArraySort.MoveItemsLessThanThresholdToStart(items, threshold);

            IsArrayContentEqual(items, new[] { 6, 4, 5, 8 });
            Assert.AreEqual(count, 0);
        }

        [TestMethod]
        public void CanSortAllItemsLessThanThreshold()
        {
            var items = new[] { 3, 1, 2, 3 };
            var threshold = 4;

            var count = ArraySort.MoveItemsLessThanThresholdToStart(items, threshold);

            IsArrayContentEqual(items, new[] { 3, 1, 2, 3 });
            Assert.AreEqual(count, 4);
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
