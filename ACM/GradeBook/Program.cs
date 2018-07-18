using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            IGradeTracker book = CreateGradeBook();

            //moves try-catch into separate method to refactor code
            GetBookName(book);
            AddGrades(book);
            SaveGrades(book);
            WriteResults(book);

        }

        private static IGradeTracker CreateGradeBook()
        {
            return new ThrowAwayGradeBook();
        }

        private static void WriteResults(IGradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine(book.Name);
            //allowed by inheriting enumerable in igradetracker
            foreach(float grade in book)
            {
                Console.WriteLine(grade);
            }
            WriteResult("Average Grade", stats.AverageGrade);
            WriteResult("Highest Grade", stats.HighestGrade);
            WriteResult("Lowest Grade", stats.LowestGrade);
            WriteResult(stats.Description, stats.LetterGrade);
        }

        private static void SaveGrades(IGradeTracker book)
        {
            //Using statement triggers compiler to set up try-catch-finally block for us
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
                //do not need to explicity close because the using statement handles that automatically
                // outputFile.Close();
            }
        }

        private static void AddGrades(IGradeTracker book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        //Handles an exception in case that user does not enter valid name
        //Continues to prompt user and does not loop
        private static void GetBookName(IGradeTracker book)
        {
            try
            {
                Console.WriteLine("Enter a name: ");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Method to format output
        static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{description}: {result:F2}");
        }
        static void WriteResult(string description, string result)
        {
            Console.WriteLine($"{description}: {result}");
        }
        
    }
}
