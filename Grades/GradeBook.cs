//using System;
//using System.Collections.Generic;

//namespace Grades {
//    public delegate void NameChangedDelegate(object sender, NameChangedEventArgs args);
//    public class GradeBook {
//        public GradeBook(string name = "There is no name") {
//            Name = name;
//            grades = new List<float>();
//            Console.WriteLine("gradebook ctor");
//        }

//        public void AddGrade(float grade) {
//            if (grade >= 0 && grade < 100) {
//                grades.Add(grade);
//            }
//        }

//        public virtual GradeStatistics ComputeStatistics() {
//            Console.WriteLine("Gradebook compute");
//            GradeStatistics stats = new GradeStatistics();

//            float sum = 0f;
//            foreach (float grade in grades) {
//                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
//                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
//                sum += grade;
//            }

//            stats.AverageGrade = sum / grades.Count;
//            return stats;
//        }

//        // Backing field (private)
        
//        protected List<float> grades;
//    }
//}
