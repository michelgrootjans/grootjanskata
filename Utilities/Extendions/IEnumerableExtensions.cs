using System;
using System.Collections.Generic;

namespace Utilities.Extendions
{
    public static class IEnumerableExtensions
    {
        public static T Find<T>(this IEnumerable<T> list, Predicate<T> predicate)
        {
            foreach (var item in list)
            {
                if (predicate(item))
                    return item;
            }
            return default(T);
        }

    

    public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
    {
        foreach (var item in list)
        {
            action(item);
        }
    }
}}