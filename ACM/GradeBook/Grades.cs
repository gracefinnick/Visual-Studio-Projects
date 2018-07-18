using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{

    public class Grades : GradeTracker
    {
        //List because dynamic size
        //protected allows access to this class and derived classes
        protected List<float> grades;

        public Grades()
        {
            _name = "Empty";
            grades = new List<float>();
        }

        public override void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public override GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();
            float sum = 0;
            //Iterates through each item in the list exactly once
            foreach (float grade in grades)
            {
                //compare each item with the current high
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                //compare each item with the current low
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }
            stats.AverageGrade = sum / grades.Count;
            return stats;
        }
        
        public override void WriteGrades(TextWriter destination)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine(grades[i]);
            }
        }
        //implementation from gradetracker class
        public override IEnumerator GetEnumerator()
        {
            return grades.GetEnumerator();
        }
    }
}
