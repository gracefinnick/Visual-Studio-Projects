using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    public abstract class GradeTracker : IGradeTracker
    {
        //event
        public event NameChangedDelegate NameChanged;
        //To name the list
        protected string _name;
        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter destination);
        //required due to inheriting enumerator in igradetracker
        public abstract IEnumerator GetEnumerator();
        //allows access to the private _name field
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }

                if (_name != value)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExistingName = _name;
                    args.NewName = value;
                    //this refers to the grades object that we're currently operating on
                    //NameChanged(this, args);
                }
                _name = value;

            }
        }
    }
}
