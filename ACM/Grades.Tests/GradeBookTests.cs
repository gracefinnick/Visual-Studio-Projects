using GradeBook;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.Tests
{
    [TestClass]
    public class GradeBookTests
    {
        [TestMethod] // Tests that highest grade is correctly computed
        public void ComputesHighestGrade()
        {
            Grades book = new Grades();
            book.AddGrade(10);
            book.AddGrade(90);

            GradeStatistics result = book.ComputeStatistics();
            //If equal, passes
            Assert.AreEqual(90, result.HighestGrade);
        }
        [TestMethod] //Tests that lowest grade is correctly computed
        public void ComputesLowestGrade()
        {
            Grades book = new Grades();
            book.AddGrade(10);
            book.AddGrade(90);

            GradeStatistics result = book.ComputeStatistics();
            //If equal, passes
            Assert.AreEqual(10, result.LowestGrade);
        }
        [TestMethod] //Tests that average is correctly computed
        public void ComputesAverageGrade()
        {
            Grades book = new Grades();
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics result = book.ComputeStatistics();
            //If equal, passes
            Assert.AreEqual(85.16, result.AverageGrade, 0.01);
        }
  
    }
}
