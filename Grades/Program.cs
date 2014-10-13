using System;

namespace Grades {
    class Program {
        static void Main(string[] args) {
            GradeBook book = new GradeBook("Scott's Book");
            book.AddGrade(91f);
            book.AddGrade(89.1f);
            book.AddGrade(75f);

            GradeStatistics stats = book.ComputeStatistics();

            // Hooking up the delegate to point to another method
            // Setting the public Field (of type NameChangedDelegate) to a new delegate and passing the method
            // however anyone else can overwrite this
            //book.NameChanged = new NameChangedDelegate(OnNameChanged);

            // multicast delegate
            book.NameChanged += OnNameChanged;
            book.NameChanged += OnNameChanged;
            book.NameChanged += OnNameChanged2;
            // ahh would wipe out the previous ones
            book.NameChanged = new NameChangedDelegate(OnNameChanged2);

            book.Name = "Allen's Book";
            WriteNames(book.Name);

            Console.WriteLine(stats.AverageGrade);
            Console.WriteLine(stats.LowestGrade);
            Console.WriteLine(stats.HighestGrade);
        }

        private static void OnNameChanged2(string oldvalue, string newvalue) {
            Console.WriteLine("***");
        }

        // This method will execute when a 
        private static void OnNameChanged(string oldvalue, string newvalue) {
            Console.WriteLine("Name changed from {0} to {1}", oldvalue, newvalue);
        }

        private static void WriteBytes(int value) {
            byte[] bytes = BitConverter.GetBytes(value);
            WriteByteArray(bytes);
        }


        private static void WriteBytes(float value) {
            byte[] bytes = BitConverter.GetBytes(value);
            WriteByteArray(bytes);
        }

        private static void WriteByteArray(byte[] bytes) {
            foreach (byte b in bytes) {
                Console.Write("0x{0:X} ", b);
            }
            Console.WriteLine();
        }

        private static void WriteNames(params string[] names) {
            foreach (string name in names) {
                Console.WriteLine(name);
            }
        }
    }
}
