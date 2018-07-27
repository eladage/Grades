using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {

            //SpeechSynthesizer synth = new SpeechSynthesizer();
            //synth.Speak("Hello this is my program, is this shit working?");

            GradeBook book = new GradeBook();
            book.Name = "Eric's Grade Book";
            book.Name = null;

            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine(book.Name);
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", (int)stats.HighestGrade);
            WriteResult("Lowest ", stats.LowestGrade);

        }

        static void WriteResult(string description, int result)
        {
            Console.WriteLine(description + ":\t" + result);
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{description}:\t{result:F2}");
        }
    }

}
