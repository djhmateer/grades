//using System;

//namespace Grades {
//    class ThrowAwayGradeBook : GradeBook {
//        public ThrowAwayGradeBook(string name)
//            : base(name) {
//            Console.WriteLine("throwaway ctor");
//        }

//        public override GradeStatistics ComputeStatistics(){
//            Console.WriteLine("Throwaway compute");
//            float lowest = float.MaxValue;
//            foreach (var grade in grades){
//                lowest = Math.Min(lowest, grade);
//            }
//            grades.Remove(lowest);
//            return base.ComputeStatistics();
//        }
//    }
//}
