using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MVVMConcepts.Command
{
    public class GeneralCommand : ICommand
    {
        private Action<object> _action;
        private Func<object, bool> _canExecute;
        public GeneralCommand(Action<object> action, Func<object, bool> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }
        public void Execute(object parameter)
        {
            _action(parameter);
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
