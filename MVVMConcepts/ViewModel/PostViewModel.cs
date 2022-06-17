using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MVVMConcepts.ViewModel
{
    public class PostViewModel : SelectViewModel
    {
        public PostViewModel()
        {
            //RunCount = 0;
            //ListCount = 50;
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerAsync();
            void worker_DoWork(object sender, DoWorkEventArgs e)
            {
                while (RunCount < ListCount)
                {
                    RunCount++;
                    Thread.Sleep(100);
                }
            }
        }
    }
}
