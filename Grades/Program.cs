using System;
using System.IO;

namespace Grades {
    class Program {
        static void Main(string[] args) {
            // Don't know what type will be returned..a base class or derived type
            // could be looking at a config file 
            // maybe a GradeBook or a ThrowAwayGradeBook
            GradeBook book = CreateGradeBook();
            try {
                // Using will call Dispose method
                // compiler will tell you if doesn't implement IDispose
                using (FileStream stream = File.Open("grades.txt", FileMode.Open))
                using (StreamReader reader = new StreamReader(stream)){
                    string line = reader.ReadLine();

                    while (line != null){
                        float grade = float.Parse(line);
                        book.AddGrade(grade);
                        line = reader.ReadLine();
                    }
                }
            }
            catch (FileNotFoundException ex) {
                Console.WriteLine("Could not locate the file grades.txt");
                return;
            }
            catch (UnauthorizedAccessException ex) {
                Console.WriteLine("No access");
                return;
            }

            book.AddGrade(91f);
            book.AddGrade(89.1f);
            book.AddGrade(75f);

            GradeStatistics stats = book.ComputeStatistics();

            Console.WriteLine(stats.AverageGrade);
            Console.WriteLine(stats.LowestGrade);
            Console.WriteLine(stats.HighestGrade);
        }

        private static ThrowAwayGradeBook CreateGradeBook(){
            return new ThrowAwayGradeBook("Scott's book");
        }
    }
}
