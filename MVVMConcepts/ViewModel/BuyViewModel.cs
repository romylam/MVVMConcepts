using MVVMConcepts.Command;
using MVVMConcepts.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace MVVMConcepts.ViewModel
{
    public class BuyViewModel : BaseViewModel
    {
        private bool _Selling;
        private bool _Buying;
        private string _ItemNumber;
        private string _ItemDescription;
        private decimal _ItemUnitCost;
        private string _BuyOrder;
        private int _BuyQuantity;
        private Items _ItemSelected;
        private ObservableCollection<Items> _ItemList;
        public BuyViewModel()
        {
            ItemList = new ObservableCollection<Items>();
            ItemList.Add(new Items() { Item_No = "A12", Item_Name = "iPhone 12", Item_Cost = 500M, Item_Price = 1200M });
            ItemList.Add(new Items() { Item_No = "A13", Item_Name = "iPhone 13", Item_Cost = 600M, Item_Price = 1300M });
            ItemList.Add(new Items() { Item_No = "S21", Item_Name = "Galaxy S21", Item_Cost = 400M, Item_Price = 1000M });
            ItemList.Add(new Items() { Item_No = "S22", Item_Name = "Galaxy S22", Item_Cost = 450M, Item_Price = 1100M });
            ItemList.Add(new Items() { Item_No = "GF3", Item_Name = "Fold 3", Item_Cost = 950M, Item_Price = 1700M });
            Buying = true;
            Selling = false;
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
        public decimal ItemUnitCost
        {
            get { return _ItemUnitCost; }
            set { _ItemUnitCost = value; onPropertyChanged(nameof(ItemUnitCost)); onPropertyChanged(nameof(BuyAmount)); }
        }
        public string BuyOrder
        {
            get { return _BuyOrder; }
            set { _BuyOrder = value; onPropertyChanged(nameof(BuyOrder)); }
        }
        public int BuyQuantity
        {
            get { return _BuyQuantity; }
            set { _BuyQuantity = value; onPropertyChanged(nameof(BuyQuantity)); onPropertyChanged(nameof(BuyAmount)); }
        }
        public decimal BuyAmount
        {
            get { return ItemUnitCost * BuyQuantity; }
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
            ItemUnitCost = Item.Item_Cost;
        }
        private bool canExecuteAlways(object parameter)
        {
            return true;
        }
    }
}
