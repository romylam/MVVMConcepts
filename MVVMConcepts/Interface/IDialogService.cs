using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMConcepts.Interface
{
    public interface IDialogService
    {
        void ShowDialog<TView>(string Title);
    }
}
