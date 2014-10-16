//using System;
//using System.IO;

//namespace Grades {
//    public abstract class GradeTracker{
//        public abstract void AddGrade(float grade);
//        public abstract GradeStatistics ComputeStatistics();
//        public abstract void WriteGrades(TextWriter textWriter);

//        // Good feeling that Name and NameChanged will not change
      
//        public string Name {
//            get {
//                return _name;
//            }
//            set {
//                if (String.IsNullOrEmpty(value)) {
//                    throw new ArgumentException("Name cannot be null or empty");
//                }

//                if (_name != value) {
//                    var oldValue = _name;
//                    _name = value;
//                    // Announce to world that something has changed
//                    if (NameChanged != null) {
//                        var args = new NameChangedEventArgs {
//                            OldValue = oldValue,
//                            NewValue = value
//                        };
//                        // Invoke the delegate
//                        NameChanged(this, args);
//                    }
//                }
//            }
//        }

//        // Field of type NameChangedDelegate
//        public event NameChangedDelegate NameChanged;
//        private string _name;
//    }
//}
