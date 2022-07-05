using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ModalApp.ViewModel
{
    public class baseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void onPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
