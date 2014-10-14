using System;
using System.IO;

namespace Grades {
    class Program {
        static void Main(string[] args) {
            //GradeBook book = new GradeBook("Scott's Book");
            GradeBook book = new GradeBook();

            string[] lines = File.ReadAllLines("grades.txt");
            foreach (string line in lines)
            {
                float grade = float.Parse(line);
                book.AddGrade(grade);
            }

            book.AddGrade(91f);
            book.AddGrade(89.1f);
            book.AddGrade(75f);
           
            GradeStatistics stats = book.ComputeStatistics();
           
            Console.WriteLine(stats.AverageGrade);
            Console.WriteLine(stats.LowestGrade);
            Console.WriteLine(stats.HighestGrade);
        }
    }
}
