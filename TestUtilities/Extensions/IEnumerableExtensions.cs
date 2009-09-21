using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestUtilities.Extensions
{
    public static class IEnumerableExtensions
    {
        public static void ShouldBeEmpty<T>(this IEnumerable<T> list)
        {
            foreach (var item in list)
            {
                Assert.Fail("This list should be empty");
            }
        }

        public static void ShouldContain<T>(this IEnumerable<T> list, T expectedItem)
        {
            foreach (var item in list)
                if (item.Equals(expectedItem)) return;
            Assert.Fail("Item could not be found");
        }

        public static void ShouldContain<T>(this IEnumerable<T> list, Predicate<T> predicate)
        {
            foreach (var item in list)
                if (predicate(item)) return;
            Assert.Fail("Item could not be found");
        }
    }
}