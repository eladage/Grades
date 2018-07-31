using Grades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Tests
{
    [TestClass]
    public class GradeBookTests
    {
        [TestMethod]
        public void ComputesHighestGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(10);
            book.AddGrade(90);

            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(90, result.HighestGrade);
        }

        [TestMethod]
        public void ComputesLowestGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(10);
            book.AddGrade(90);

            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(10, result.LowestGrade);
        }

        [TestMethod]
        public void ComputesAverageGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(85.16, result.AverageGrade, 0.01);
        }

        [TestMethod]
        public void LetterGradeAccuracy()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(100);

            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(result.LetterGrade, "A");
            
            book.AddGrade(75);
            result = book.ComputeStatistics();
            Assert.AreEqual(result.LetterGrade, "B");

            book.AddGrade(50);
            result = book.ComputeStatistics();
            Assert.AreEqual(result.LetterGrade, "C");

            book.AddGrade(50);
            result = book.ComputeStatistics();
            Assert.AreEqual(result.LetterGrade, "D");

            book.AddGrade(0);
            result = book.ComputeStatistics();
            Assert.AreEqual(result.LetterGrade, "F");

        }
    }
}
