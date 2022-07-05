using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ModalApp.Command
{
    public class generalCommand : ICommand
    {
        private Action<object> _action;
        private Func<object, bool> _canExecute;
        public generalCommand(Action<object> action, Func<object, bool> canExecute)
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
