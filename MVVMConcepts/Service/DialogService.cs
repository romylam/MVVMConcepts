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
        public void ShowDialog<TView>(string Title, string Parameter = null)
        {
            var dialog = new DialogWindow();
            var type = typeof(TView);
            Debug.WriteLine($"View Parameter is {Parameter}");
            dialog.Content = Parameter == null ? Activator.CreateInstance(type) : Activator.CreateInstance(type, Parameter);
            dialog.Title = Title;
            dialog.ShowDialog();
        }
        public void CloseDialog(DialogWindow dialog)
        {
            dialog.Close();
        }
    }
}
