using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public delegate int BizRulesDelegate(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            var custs = new List<Customer>
            {
                new Customer { City = "Phoenix", FirstName = "John", LastName = "Doe", ID = 1},
                new Customer { City = "Phoenix", FirstName = "Jane", LastName = "Doe", ID = 500},
                new Customer { City = "Seattle", FirstName = "Suki", LastName = "Pizzoro", ID = 3},
                new Customer { City = "New York City", FirstName = "Michelle", LastName = "Smith", ID = 4}
            };
            // Wrap down statements to increase readability
            var phxCusts = custs
                .Where(c => c.City == "Phoenix" && c.ID < 500)
                .OrderBy(c => c.FirstName);
            foreach ( var cust in phxCusts)
            {
                Console.WriteLine(cust.FirstName);
            }

            var data = new ProcessData();
            // Create delegates that define the action we want to be taken
            BizRulesDelegate addDel = (x, y) => x + y;
            BizRulesDelegate multiplyDel = (x, y) => x * y;
            data.Process(2, 3, addDel);

            // Using Func, no defining the delegate
            Func<int, int, int> funcAddDel = (x, y) => x + y;
            Func<int, int, int> funcMultiplyDel = (x, y) => x * y;
            data.ProcessFunc(3, 2, funcAddDel);

            var worker = new Worker();
            // Using lambda expressions
            //Using brackets allows for multiple lines of code
            worker.WorkPerformed += (s, e) =>
            {
                Console.WriteLine("Worked: " + e.Hours + " hour(s) doing: " + e.WorkType);
                Console.WriteLine("Other value here");
            };
            worker.WorkCompleted += (s, e) => Console.WriteLine("Worker is done");
            worker.DoWork(8, WorkType.GenerateReports);

            // Keeps the window open
            Console.Read();
        }
        
    }

    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }
}


