using System;
using System.Collections.Generic;

namespace Grades {
    public delegate void NameChangedDelegate(string oldValue, string newValue);
    public class GradeBook {
        public GradeBook(string name = "There is no name") {
            Name = name;
            grades = new List<float>();
        }

        public void AddGrade(float grade) {
            if (grade >= 0 && grade < 100) {
                grades.Add(grade);
            }
        }

        public GradeStatistics ComputeStatistics() {
            GradeStatistics stats = new GradeStatistics();

            float sum = 0f;
            foreach (float grade in grades) {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / grades.Count;
            return stats;
        }

       // Backing field (private)
        private string _name;

        public string Name {
            get {
                return _name;
            }
            set {
                if (_name != value) {
                    var oldValue = _name;
                    _name = value;
                    // Announce to world that something has changed
                    if (NameChanged != null) {
                        // It has no idea what will be called, only that the signature will be string oldValue, string newValue
                        NameChanged(oldValue, value);
                    }
                }
            }
        }

        // Field of type NameChangedDelegate
        public NameChangedDelegate NameChanged;

        //if (_name != value) {
        //    var oldValue = _name;
        //    _name = value;
        //    if (NameChanged != null) {
        //        NameChangedEventArgs args = new NameChangedEventArgs();
        //        args.OldValue = oldValue;
        //        args.NewValue = value;
        //        NameChanged(this, args);
        //    }
        //}


        //public event NamedChangedDelegate NameChanged;

        private List<float> grades;
    }
}
