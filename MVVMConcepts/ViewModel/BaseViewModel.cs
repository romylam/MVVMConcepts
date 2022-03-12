using MVVMConcepts.Command;
using MVVMConcepts.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace MVVMConcepts.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void onPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }
    }
    public sealed class Shared
    {
        private Shared()
        {
        }
        private static Shared instance = null;
        public static Shared Instance
        {
            get
            {
                if (instance == null)
                    instance = new Shared();
                return instance;
            }
        }
        public Dictionary<string, object> DialogParameter = new Dictionary<string, object>();
    }
}
