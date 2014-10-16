using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Grades10 {
    class Program {
        static void Main() {
            IEnumerable<string> cities = new[] { "Ghent", "London", "Las Vegas", "Hyderbad" };

            // More flexible, as have a Filter method that can take delegates
            // that point to other things
            //IEnumerable<string> query = cities.Filter(StringTheStartWithL);

            // Delegate that takes an integer as a parameter, and returns a bool
            //Func<int, bool>

            Func<int, int> square = x => x * x;
            // Parameters requied for 0 or 2+ parameters
            Func<int, int, int> add = (x, y) => x + y;
            Console.WriteLine(square(3));
            Console.WriteLine(add(3, 4));

            // Action is just like Func with no return value
            Action<int> write = x => Console.WriteLine(x);
            write(16);

            //IEnumerable<string> queryOld =
            //    cities.Filter(delegate(string item) {
            //                        return item.StartsWith("L");
            //                    });

            // Lambda expression.. LHS is signature of the method (takes a string - type inference)
            // Body returns a bool of item.StartsWith("L")
            //IEnumerable<string> query =
            //    cities.Filter(item => item.StartsWith("L"));

            IEnumerable<string> query =
                cities.Where(city => city.StartsWith("L"))
                      .OrderByDescending(city => city.Length);

            foreach (var city in query) {
                Console.WriteLine(city);
            }
        }

        static bool StringTheStartWithL(string s) {
            return s.StartsWith("L");
        }
    }

    public static class FilterExtensions {
        // By using Func<T,bool> we don't need to define a delegate
        public static IEnumerable<T> Filter<T>
                (this IEnumerable<T> input, Func<T, bool> predicate) {
            // foreach item in the input, invoke the predicate (method)
            // if predicate returns true, add to IEnumerable returning
            foreach (var item in input) {
                if (predicate(item)) {
                    // builds an IEnumerable
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> Filterx<T>
                (this IEnumerable<T> input, FilterDelegate<T> predicate) {
            // foreach item in the input, invoke the predicate (method)
            // if predicate returns true, add to IEnumerable returning
            foreach (var item in input) {
                if (predicate(item)) {
                    // builds an IEnumerable
                    yield return item;
                }
            }
        }
    }
    public delegate bool FilterDelegate<T>(T item);
}

