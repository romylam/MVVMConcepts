using MVVMConcepts.Command;
using MVVMConcepts.Interface;
using MVVMConcepts.Service;
using MVVMConcepts.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMConcepts.ViewModel
{
    public class SelectViewModel : BaseViewModel
    {
        private string _UserName;
        IDialogService _dialogService = new DialogService();
        public SelectViewModel()
        {
            UserName = "John";
        }
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; onPropertyChanged(nameof(UserName)); onPropertyChanged(nameof(SelectLabel)); }
        }
        public string SelectLabel
        {
            get { return string.IsNullOrEmpty(UserName) ? "Select Action" : $"Select Action, {UserName}"; }
        }
        public ICommand BuyItemCommand
        {
            get { return new GeneralCommand(executeBuyItem, canExecuteAlways); }
        }
        private void executeBuyItem(object parameter)
        {
            _dialogService.ShowDialog<BuyView>("Buy");
        }
        public ICommand SellItemCommand
        {
            get { return new GeneralCommand(executeSellItem, canExecuteAlways); }
        }
        private void executeSellItem(object parameter)
        {
            _dialogService.ShowDialog<SellView>("Sell");
        }
        public ICommand RegisterCommand
        {
            get { return new GeneralCommand(executeRegister, canExecuteAlways); }
        }
        private void executeRegister(object parameter)
        {

            Shared.Instance.DialogParameter.Clear();
            Shared.Instance.DialogParameter.Add("UserName", UserName);
            _dialogService.ShowDialog<RegisterView>("Register");
            UserName = Shared.Instance.DialogParameter["UserName"].ToString();
        }
        private bool canExecuteAlways(object parameter)
        {
            return true;
        }
    }
}
