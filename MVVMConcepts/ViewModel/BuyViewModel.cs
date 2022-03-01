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
            ItemList.Add(new Items() { Item_No = "A1", Item_Name = "Apple", Item_Cost = 0.35M, Item_Price = 0.5M });
            ItemList.Add(new Items() { Item_No = "B1", Item_Name = "Banana", Item_Cost = 0.15M, Item_Price = 0.3M });
            ItemList.Add(new Items() { Item_No = "D1", Item_Name = "Durian", Item_Cost = 2.1M, Item_Price = 2.7M });
            ItemList.Add(new Items() { Item_No = "G1", Item_Name = "Guava", Item_Cost = 0.25M, Item_Price = 0.4M });
            ItemList.Add(new Items() { Item_No = "P1", Item_Name = "Pear", Item_Cost = 0.45M, Item_Price = 0.6M });
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
