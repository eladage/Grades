using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook : GradeTracker
    {
        public GradeBook()
        {
            _name = "empty";
            grades = new List<float>();
        }

        public override GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();

            float sum = 0;
            foreach (float grade in grades)
            {
                //Instead of doing the following, we can use the Math Reference.
                //if(grade > stats.HighestGrade)
                //{
                //    stats.HighestGrade = grade;
                //}
                Console.WriteLine(grade);
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / grades.Count;

            return stats;
        }

        public override void WriteGrades(TextWriter destination)
        {
            //for (int i = 0; i < grades.Count; i++)
            //{
            //    destination.WriteLine(grades[i]);
            //}
            destination.WriteLine($"\n{Name}'s grades:");
            foreach (float grade in grades)
            {
                destination.WriteLine(grade);
            }
        }

        public override void AddGrade(float grade)
        {
            grades.Add(grade);
        }


        //auto-implemented property
        public string AutoProperty { get; set; }
        public override IEnumerator GetEnumerator()
        {
            return grades.GetEnumerator();
        }
        //List doesn't have a fixed size like an array. 
        //protected member allows inherited classes to access (ThrowAwayGradeBook.cs)
        protected List<float> grades;

    }
}
