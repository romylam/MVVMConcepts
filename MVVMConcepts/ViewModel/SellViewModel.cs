using MVVMConcepts.Command;
using MVVMConcepts.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace MVVMConcepts.ViewModel
{
    public class SellViewModel : BaseViewModel
    {
        private bool _Selling;
        private bool _Buying;
        private string _ItemNumber;
        private string _ItemDescription;
        private decimal _ItemUnitPrice;
        private string _SellOrder;
        private int _SellQuantity;
        private Items _ItemSelected;
        private ObservableCollection<Items> _ItemList;
        public SellViewModel()
        {
            ItemList = new ObservableCollection<Items>();
            ItemList.Add(new Items() { Item_No = "A1", Item_Name = "Apple", Item_Cost = 0.35M, Item_Price = 0.5M });
            ItemList.Add(new Items() { Item_No = "B1", Item_Name = "Banana", Item_Cost = 0.15M, Item_Price = 0.3M });
            ItemList.Add(new Items() { Item_No = "D1", Item_Name = "Durian", Item_Cost = 2.1M, Item_Price = 2.7M });
            ItemList.Add(new Items() { Item_No = "G1", Item_Name = "Guava", Item_Cost = 0.25M, Item_Price = 0.4M });
            ItemList.Add(new Items() { Item_No = "P1", Item_Name = "Pear", Item_Cost = 0.45M, Item_Price = 0.6M });
            Selling = true;
            Buying = false;
        }
        public bool Selling
        {
            get { return _Selling; }
            set { _Selling = value; onPropertyChanged(nameof(Selling)); }
        }
        public bool Buying
        {
            get { return _Buying; }
            set { _Buying = value; onPropertyChanged(nameof(Buying)); }
        }
        public string ItemNumber
        {
            get { return _ItemNumber; }
            set { _ItemNumber = value; onPropertyChanged(nameof(ItemNumber)); }
        }
        public string ItemDescription
        {
            get { return _ItemDescription; }
            set { _ItemDescription = value; onPropertyChanged(nameof(ItemDescription)); }
        }
        public decimal ItemUnitPrice
        {
            get { return _ItemUnitPrice; }
            set { _ItemUnitPrice = value; onPropertyChanged(nameof(ItemUnitPrice)); onPropertyChanged(nameof(SellAmount)); }
        }
        public string SellOrder
        {
            get { return _SellOrder; }
            set { _SellOrder = value; onPropertyChanged(nameof(SellOrder)); }
        }
        public int SellQuantity
        {
            get { return _SellQuantity; }
            set { _SellQuantity = value; onPropertyChanged(nameof(SellQuantity)); onPropertyChanged(nameof(SellAmount)); }
        }
        public decimal SellAmount
        {
            get { return ItemUnitPrice * SellQuantity ; }
        }
        public ObservableCollection<Items> ItemList
        {
            get { return _ItemList; }
            set { _ItemList = value; onPropertyChanged(nameof(ItemList)); }
        }
        public Items ItemSelected
        {
            get { return _ItemSelected; }
            set { _ItemSelected = value; onPropertyChanged(nameof(ItemSelected)); }
        }
        public ICommand RetrieveItemCommand
        {
            get { return new GeneralCommand(executeRetrieveItem, canExecuteAlways); }
        }
        private void executeRetrieveItem(object parameter)
        {
            Items Item = parameter as Items;
            ItemDescription = Item.Item_Name;
            ItemUnitPrice = Item.Item_Price;
        }
        private bool canExecuteAlways(object parameter)
        {
            return true;
        }
    }
}
