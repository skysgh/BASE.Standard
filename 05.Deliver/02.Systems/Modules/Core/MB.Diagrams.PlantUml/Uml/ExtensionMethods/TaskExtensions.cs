using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Diagrams.PlantUml.Uml
{

        using System.Threading.Tasks;

        public static class TaskExtensions
        {
            public static TResult WaitAndGetResult<TResult>(this Task<TResult> task, int timeOutMilliseconds = 2000)
            {
                task.Wait(timeOutMilliseconds);

                return task.Result;
            }
        }
}
