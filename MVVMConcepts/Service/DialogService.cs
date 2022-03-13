using MVVMConcepts.Dialog;
using MVVMConcepts.Interface;
using MVVMConcepts.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMConcepts.Service
{
    public class DialogService : IDialogService
    {
        public void OpenDialog<TView>(string Title)
        {
            DialogWindow dialog = new DialogWindow();
            Type type = typeof(TView);
            dialog.Content = Activator.CreateInstance(type);
            dialog.Title = Title;
            dialog.ShowDialog();
        }
    }
}
