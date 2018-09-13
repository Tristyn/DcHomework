using System;
using System.Collections.Generic;

namespace DhHomework
{
    public static class ArraySort
    {
        /// <summary>
        /// Moves all items less than the threshold to the start of the array. Otherwise does not change the order
        /// </summary>
        /// <param name="items"></param>
        /// <param name="threshold"></param>
        /// <returns>Returns the count of items less than the threshold</returns>
        public static int MoveItemsLessThanThresholdToStart(int[] items, int threshold)
        {
            // I'll be allocating two temp buffers to do the sort.
            // Though this can be done with no allocations by:
            // 1) Iterating each item
            // 2) Where the item is less than the threshold, take a copy of the item
            // 3) Shift each item before it to the right, starting after the previously moved items less than the threshold, and stopping at the current iteration index
            // 4) Setting the first item that was shifted to the copy of the item at the iteration index.
            // The above algorithm is very expensive unless very few items get moved, or the array is small. Though it has less memory pressure

            // Because we don't know beforehand how many items are going to be moved, we'll use a list over an array
            // The algorithm could be modified to use arrays from System.Buffers.ArrayPool<int>.Shared.Rent(len) and do partial sorts when it's capacity is reached. That or a linked list of arrays

            // There might be a way to do this cheaply without using temp buffers, I didn't think about the problem too hard

            var itemValuesLessThanThreshold = new List<int>();
            var itemIndexesLessThanThreshold = new List<int>();

            // Iterate the items and record all indexes that are less than the threshold
            for (var i = 0; i < items.Length; i++)
            {
                var item = items[i];

                if (item >= threshold)
                    continue;

                itemIndexesLessThanThreshold.Add(i);
                itemValuesLessThanThreshold.Add(item);
            }

            if (itemIndexesLessThanThreshold.Count == 0)
                return itemIndexesLessThanThreshold.Count;

            // In one batch, sort the array by shifting elements. Loop backwards
            // We can skip over items at the end up until the last item thats less than the threshold
            
            var lastItemIndexLessThanThreshold = itemIndexesLessThanThreshold[itemIndexesLessThanThreshold.Count - 1];
            int shiftSize = 0;
            // Number of positions to move each item, it increments each time we encounter an item less than the threshold
            for (var i = lastItemIndexLessThanThreshold; i > 0; i--)
            {
                if(items[i] < threshold)
                {
                    shiftSize++;
                }

                items[i] = items[i - shiftSize];
            }
        }
    }
}
