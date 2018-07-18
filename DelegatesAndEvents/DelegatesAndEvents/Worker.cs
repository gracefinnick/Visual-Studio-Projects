using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    // Removed because working with directly in event WorkPerformed
    // public delegate void WorkPerformedHandler(object sender, WorkPerformedEventArgs e);
    public class Worker
    {
        // Directly working with event, avoid using delegate
        // Good practice when delegate is not needed on its own somewhere
        // Allows for delegate inference in Program class
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public event EventHandler WorkCompleted;
        public void DoWork(int hours, WorkType workType)
        {
            // Loop through and rais an event every hour
            for (int i = 0; i < hours; i++)
            {
                // Makes system wait one second between each iteration
                System.Threading.Thread.Sleep(1000);
                OnWorkPerformed(i + 1, workType);
            }
            // Raise final completed event
            OnWorkCompleted();
        }
        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            //Option 1: directly on the event
            //if(WorkPerformed != null)
            //{
            //    WorkPerformed(hours, workType);
            //}

            //Option 2: cast as delegate
            var del = WorkPerformed as EventHandler<WorkPerformedEventArgs>;
            if (del != null)
            {
                del(this, new WorkPerformedEventArgs(hours, workType));
            }
        }
        protected virtual void OnWorkCompleted()
        {
            var del = WorkCompleted as EventHandler;
            if (del != null)
            {
                del(this, EventArgs.Empty);
            }
        }
    }
}
