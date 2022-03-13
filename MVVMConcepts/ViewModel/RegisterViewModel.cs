using MVVMConcepts.Command;
using MVVMConcepts.Dialog;
using MVVMConcepts.Interface;
using MVVMConcepts.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVMConcepts.ViewModel
{
    public class RegisterViewModel : BaseViewModel
    {
        private string _UserName;
        public RegisterViewModel()
        {
            UserName = Shared.Instance.DialogParameter["UserName"].ToString();
        }
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; onPropertyChanged(nameof(UserName)); }
        }
        public ICommand RegisterNameCommand
        {
            get { return new GeneralCommand(executeRegisterName, canExecuteAlways); }
        }
        private void executeRegisterName(object parameter)
        {
            Shared.Instance.DialogParameter["UserName"] = UserName;
        }
        private bool canExecuteAlways(object parameter)
        {
            return true;
        }
    }
}
