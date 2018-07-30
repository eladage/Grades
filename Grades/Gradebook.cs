using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook
    {
        public GradeBook()
        {
            grades = new List<float>();
            _name = "empty";
        }

        public GradeStatistics ComputeStatistics()
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

                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / grades.Count;

            return stats;
        }

        public void WriteGrades(TextWriter destination)
        {
            //for (int i = 0; i < grades.Count; i++)
            //{
            //    destination.WriteLine(grades[i]);
            //}

            foreach (float grade in grades)
            {
                destination.WriteLine(grade);
            }
        }

        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        //property - used to set value to Name and to allow Program.cs to get value
        public string Name
        {
            get { return _name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }
                if (_name != value && NameChanged != null)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExistingName = _name;
                    args.NewName = value;

                    NameChanged(this, args);
                }
                _name = value;

            }
        }

        //delegate is a variable that points to a method - changing to event below
        //public NameChangedDelegate NameChanged;

        public event NameChangedDelegate NameChanged;


        //backing field for above property
        private string _name;

        //auto-implemented property
        public string AutoProperty { get; set; }

        //List doesn't have a fixed size like an array. 
        private List<float> grades;

    }
}
