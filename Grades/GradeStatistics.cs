using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeStatistics
    {
        public GradeStatistics()
        {
            HighestGrade = float.MinValue;
            LowestGrade = float.MaxValue;
        }

        public string LetterGrade
        {
            get
            {
                string result;

                if (Math.Round(AverageGrade) >= 90)
                    result = "A";
                else if (Math.Round(AverageGrade) >= 80)
                    result = "B";
                else if (Math.Round(AverageGrade) >= 70)
                    result = "C";
                else if (Math.Round(AverageGrade) >= 60)
                    result = "D";
                else
                    result = "F";

                return result;
            }
        }

        public string Description
        {
            get
            {
                string result;

                switch(LetterGrade)
                {
                    case "A":
                        result = "nerd.";
                        break;
                    case "B":
                        result = "y u no get A?";
                        break;
                    case "C":
                        result = "president material.";
                        break;
                    case "D":
                        result = "dumb half of society.";
                        break;
                    default:
                        result = "you have failed your ancestors.";
                        break;
                }
                return result;
            }
        }

        public float AverageGrade;
        public float HighestGrade;
        public float LowestGrade;
    }
}
