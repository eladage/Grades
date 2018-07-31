using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class ThrowAwayGradeBook : GradeBook
    {
        public override GradeStatistics ComputeStatistics()
        {

            Console.WriteLine($"\nThrowing away lowest grade in {this.Name}");
        
            float lowest = float.MaxValue;

            if (grades.Count > 1)
            {
                foreach (float grade in grades)
                {
                    lowest = Math.Min(grade, lowest);
                }
                grades.Remove(lowest);
            }

            return base.ComputeStatistics();
        }
    }
}
