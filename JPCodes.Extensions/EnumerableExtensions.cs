using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JPCodes.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Determine if a set contains a value.
        /// </summary>
        /// <typeparam name="T">Object to search for</typeparam>
        /// <param name="item">Item to search for in Set</param>
        /// <param name="args">Set to search for Item</param>
        /// <returns></returns>
        public static bool In<T>(this T item, params T[] args)
        {
            return args.Contains(item);
        }

        /// <summary>
        /// Return items as part of an IEnumerable.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<T> Union<T>(this IEnumerable<T> items, params T[] args)
        {
            foreach (T arg in items.Union((IEnumerable<T>)args))
            {
                yield return arg;
            }
        }

        /// <summary>
        /// Return all instances of T, recursing through nested IEnumerables.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static IEnumerable<T> Summon<T>(this IEnumerable items)
        {
            foreach (object item in items)
            {
                //Item is type specified, return it
                if (item is T casted)
                {
                    yield return casted;
                }
                //Otherwise item may be an enumerable of T, so recurse
                else if (item is IEnumerable recurse)
                {
                    foreach (T summoned in recurse.Summon<T>())
                    {
                        yield return summoned;
                    }
                }
            }
        }

        /// <summary>
        /// Determines if an IEnumerable starts with the same members as another IEnumerable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public static bool StartsWith<T>(this IEnumerable<T> source, IEnumerable<T> items)
        {
            IEnumerator<T> srcE = source.GetEnumerator();
            IEnumerator<T> tstE = items.GetEnumerator();

            while (tstE.MoveNext())
            {
                if (!(srcE.MoveNext() && srcE.Current.Equals(tstE.Current)))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Mathematical X choose Y.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="set"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static IEnumerable<T[]> Choose<T>(this IEnumerable<T> set, int number)
        {
            T[] pinnedSet = set.ToArray();
            if (number > 1 && number < pinnedSet.Length)
            {
                T[] indicies = new T[number];
                for (int i = 0; i < pinnedSet.Length - (number - 1); i++)
                {
                    indicies[0] = pinnedSet[i];
                    foreach (T[] items in ChooseRecurse(pinnedSet, indicies, 1, i + 1, number))
                    {
                        yield return items;
                    }
                }
            }
        }

        private static IEnumerable<T[]> ChooseRecurse<T>(T[] set, T[] indicies, int index, int rollingIndex, int number)
        {
            if (index == number)
            {
                yield return indicies.ToArray();
            }
            else
            {
                for (int i = rollingIndex; i < set.Length; i++)
                {
                    indicies[index] = set[i];
                    foreach (T[] item in ChooseRecurse(set, indicies, index + 1, i + 1, number))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
