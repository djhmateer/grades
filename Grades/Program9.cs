using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Grades10 {
    class Program {
        static void Main() {
            IEnumerable<string> cities = new[] { "Ghent", "London", "Las Vegas", "Hyderbad" };

            // More flexible, as have a Filter method that can take delegates
            // that point to other things
            //IEnumerable<string> query = cities.Filter(StringTheStartWithL);

            IEnumerable<string> queryOld =
                cities.Filter(delegate(string item)
                                {
                                    return item.StartsWith("L");
                                });

            // Lambda expression.. LHS is signature of the method (takes a string - type inference)
            // Body returns a bool of item.StartsWith("L")
            IEnumerable<string> query =
                cities.Filter(item => item.StartsWith("L"));

            foreach (var city in query) {
                Console.WriteLine(city);
            }
        }

        static bool StringTheStartWithL(string s) {
            return s.StartsWith("L");
        }
    }

    public static class FilterExtensions {
        public static IEnumerable<T> Filter<T>
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

