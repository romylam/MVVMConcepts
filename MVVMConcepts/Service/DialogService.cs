using MVVMConcepts.Dialog;
using MVVMConcepts.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMConcepts.Service
{
    public class DialogService : IDialogService
    {
        public void ShowDialog<TView>(string Title)
        {
            var dialog = new DialogWindow();
            var type = typeof(TView);
            dialog.Content = Activator.CreateInstance(type);
            dialog.Title = Title;
            dialog.DataContext = 
            dialog.ShowDialog();
        }
    }
}
