using MVVMConcepts.Command;
using MVVMConcepts.Dialog;
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
        private int _RunCount;
        private int _ListCount;
        private string _UserName;
        DialogControl dialogControl = new DialogControl();
        public SelectViewModel()
        {
            UserName = "";
        }
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; onPropertyChanged(nameof(UserName)); onPropertyChanged(nameof(SelectLabel)); onPropertyChanged(nameof(AllowTrade)); }
        }
        public bool AllowTrade
        {
            get { return string.IsNullOrEmpty(UserName) ? false : true; }
        }
        public string SelectLabel
        {
            get { return string.IsNullOrEmpty(UserName) ? "Register First" : $"Select Action, {UserName}"; }
        }
        public int RunCount
        {
            get { return _RunCount; }
            set { _RunCount = value; onPropertyChanged(nameof(RunCount)); onPropertyChanged(nameof(RunPercent)); onPropertyChanged(nameof(RunStatus)); onPropertyChanged(nameof(RunComplete)); }
        }
        public int ListCount
        {
            get { return _ListCount; }
            set { _ListCount = value; onPropertyChanged(nameof(ListCount)); }
        }
        public int RunPercent
        {
            get { return RunCount == ListCount ? ListCount : RunCount % ListCount; }
        }
        public string RunStatus
        {
            get { return $"Processing {RunCount} of {ListCount} item(s)"; }
        }
        public bool RunComplete
        {
            get { return RunCount == ListCount; }
        }
        public ICommand BuyItemCommand
        {
            get { return new GeneralCommand(executeBuyItem, canTrade); }
        }
        private void executeBuyItem(object parameter)
        {
            dialogControl.OpenDialog("Buy");
        }
        public ICommand SellItemCommand
        {
            get { return new GeneralCommand(executeSellItem, canTrade); }
        }
        private void executeSellItem(object parameter)
        {
            dialogControl.OpenDialog("Sell");
        }
        public ICommand PostItemCommand
        {
            get { return new GeneralCommand(executePostItem, canTrade); }
        }
        private void executePostItem(object parameter)
        {
            dialogControl.OpenDialog("Post");
        }
        private bool canTrade(object parameter)
        {
            return AllowTrade;
        }
        public ICommand RegisterCommand
        {
            get { return new GeneralCommand(executeRegister, canExecuteAlways); }
        }
        private void executeRegister(object parameter)
        {
            Shared.Instance.DialogParameter.Clear();
            Shared.Instance.DialogParameter.Add("UserName", UserName);
            dialogControl.OpenDialog("Register");
            UserName = Shared.Instance.DialogParameter["UserName"].ToString();
        }
        private bool canExecuteAlways(object parameter)
        {
            return true;
        }
    }
}
