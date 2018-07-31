using System;
using System.Collections.Generic;
using System.IO;
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
            IGradeTracker book = CreateGradeBook();

            GetBookName(book);
            AddGrades(book);
            SaveGrades(book);
            WriteResults(book);

            Console.WriteLine("...Press Enter to end program.");
            Console.ReadLine();

        }

        private static IGradeTracker CreateGradeBook()
        {
            return new ThrowAwayGradeBook();
        }

        private static void WriteResults(IGradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();

            foreach (float grade in book)
            {
                Console.WriteLine(grade);
            }

            Console.WriteLine($"GradeBook:\t{book.Name}");
            WriteResult("Average\t", stats.AverageGrade);
            WriteResult("Highest\t", stats.HighestGrade);
            WriteResult("Lowest\t", stats.LowestGrade);
            WriteResult("Grade\t", stats.LetterGrade, stats.Description);
        }

        private static void SaveGrades(IGradeTracker book)
        {
            using (StreamWriter outputFIle = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFIle);
            }
            book.WriteGrades(Console.Out);
        }

        private static void AddGrades(IGradeTracker book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        private static void GetBookName(IGradeTracker book)
        {
            try
            {
                Console.WriteLine("Enter a name");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something is screwed");
            }
        }

        static void WriteResult(string description, float result)
        {
            //fancy string variable implementation. 
            //$ before string tells compiler that it's special
            //allows variables to be wrapped in {}
            Console.WriteLine($"{description}:\t{result:F2}");
        }

        static void WriteResult(string description, string letterGrade)
        {
            Console.WriteLine($"{description}:\t{letterGrade}");
        }

        static void WriteResult(string description, string letterGrade, string gradeComment)
        {
            Console.WriteLine($"{description}:\t{letterGrade}, {gradeComment}");
        }

    }

}
