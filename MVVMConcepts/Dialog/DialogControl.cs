using MVVMConcepts.Interface;
using MVVMConcepts.Service;
using MVVMConcepts.View;
using MVVMConcepts.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMConcepts.Dialog
{
    public class DialogControl
    {
        IDialogService dialogService = new DialogService();
        public void OpenDialog(string ViewTitle)
        {
            switch (ViewTitle)
            {
                case "Buy":
                    dialogService.OpenDialog<BuyView>(ViewTitle);
                    break;
                case "Sell":
                    dialogService.OpenDialog<SellView>(ViewTitle);
                    break;
                case "Post":
                    dialogService.OpenDialog<PostView>(ViewTitle);
                    break;
                case "Register":
                    dialogService.OpenDialog<RegisterView>(ViewTitle);
                    break;
            }
        }
    }
}
