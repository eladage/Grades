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

            Console.WriteLine("\nPress Enter to end program...");
            Console.ReadLine();

        }

        private static IGradeTracker CreateGradeBook()
        {
            return new ThrowAwayGradeBook();
        }

        private static void WriteResults(IGradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();

            //foreach (float grade in book)
            //{
            //    Console.WriteLine(grade);
            //}

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
            Console.WriteLine("\nHow many grades do you want to add?:");
            string input = Console.ReadLine();
            if (Int32.TryParse(input, out int num))
            {
                /* Yes input could be parsed and we can now use number in this code block 
                   scope */
                for (int i = 0; i < Convert.ToInt32(input); i++)
                {
                    Add:
                    Console.Write("Enter grade " + (i+1) + ": ");
                    string gradeInput = Console.ReadLine();
                    
                    if (float.TryParse(gradeInput, out float gradeAddition))
                    {
                        book.AddGrade(gradeAddition);
                    }
                    else
                    {
                        Console.WriteLine("Not a valid number, please try again.");
                        goto Add;
                    }
                }
            }
            else
            {
                /* No, input could not be parsed to an integer */
                AddGrades(book);
            }
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
                Console.WriteLine("Something is screwed - " + ex.Message);
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
