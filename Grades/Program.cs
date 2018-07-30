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

            //using += to add multiple methods to single delegate
            book.NameChanged += new NameChangedDelegate(OnNameChanged);
            
            //can also be expressed in a less verbose way
            book.NameChanged += OnNameChanged2;


            //after setting NameChangedDelegate to event the following doesnt work
            //can only be set on either side of +=/-=
            //book.NameChanged = null;

            book.Name = "Eric's Grade Book";
            book.Name = "Eric's Grade Book 2: Electric Boogaloo";

            //calling name changed directly
            //book.NameChanged("1","2");

            book.AutoProperty = "this is an example of setting an auto property";
            Console.WriteLine(book.AutoProperty);

            //Because of the set; in Name property this following line is ignored.
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
        
        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}");
        }

        static void OnNameChanged2(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("--------------------");
        }

        static void WriteResult(string description, int result)
        {
            Console.WriteLine(description + ":\t" + result);
        }

        static void WriteResult(string description, float result)
        {
            //fancy string variable implementation. 
            //$ before string tells compiler that it's special
            //allows variables to be wrapped in {}
            Console.WriteLine($"{description}:\t{result:F2}");
        }

        
    }

}
