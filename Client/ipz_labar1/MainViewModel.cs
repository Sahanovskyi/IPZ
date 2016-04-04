using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;


namespace ipz_labar1
{
    public class MainViewModel : ViewModelBase
    {
        private ICollectionView _items;
        public static string warehouseName { get; set; }

        public string title = "Goods Accounting: " + warehouseName;

        public string edit_add_title { get; set; }
        public string Title
        {
            get { return title; }
        }

        public MainViewModel()
        {
            _items = CollectionViewSource.GetDefaultView(GetItems);
            if (!initialize)
            {
                ParseData();
                initialize = true;
            }
            MyItem.Counter = 0;
            selected = -1;
            edit_add_title = "Goods Accounting: ";
        }

        public List<MyItem> GetItems
        {
            get { return MyItem.Items; }
        }

        private static bool initialize;

        private string[] _editStrings = new string[5];

        public string[] EditStrings
        {
            get { return _editStrings; }
            set { _editStrings = value; }
        }

        public static MyItem item;

        public static string data;

        public MyItem Item
        {
            get { return item; }
            set { item = value; }
        }

        public int selected { get; set; }

        #region Event
        private ICommand _logOut;
        public ICommand LogOut
        {
            get
            {
                return _logOut ?? (_logOut = new RelayCommand(() =>
                {
                    GetItems.Clear();
                    initialize = false;
                    Settings1.Default.Remember = false;
                    Settings1.Default.IsLogin = false;
                    Settings1.Default.username = "";
                    Settings1.Default.password = 0;
                    Settings1.Default.Save();
                    LoginView lv = new LoginView();
                    lv.Show();
                    CloseAction();
                }));
            }
        }

        private ICommand _add;
        private static bool _isAdd;
        public ICommand Add
        {
            get
            {
                return _add ?? (_add = new RelayCommand(() =>
                {
                    _isAdd = true;
                    edit_add_title = "Goods Accounting: Add";
                    for (int i = 0; i < EditStrings.Length; i++)
                    {
                        EditStrings[i] = "";
                    }
                    EditItemView ev = new EditItemView(this);
                    ev.ShowDialog();
                }));
            }
        }

        private ICommand _edit;
        public ICommand Edit
        {
            get
            {
                return _edit ?? (_edit = new RelayCommand(() =>
                {
                    _isAdd = false;
                    if (selected != -1)
                    {
                        edit_add_title = "Goods Accounting: Edit";
                        NumberFormatInfo format = new NumberFormatInfo();
                        format.NumberGroupSeparator = ",";
                        format.NumberDecimalSeparator = "."; 
                        Item = GetItems[selected];
                        EditStrings[0] = Item.name;
                        EditStrings[1] = Item.price.ToString(format);
                        EditStrings[2] = Item.type;
                        EditStrings[3] = Item.count.ToString();
                        EditStrings[4] = String.Format("{0:000000}",Item.id);
                        EditItemView lv = new EditItemView(this);
                        lv.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Please, select item to edit");
                    }
                }));
            }
        }
        private ICommand _clickToItem;
        public ICommand ClickToItem
        {
            get
            {
                return _clickToItem ?? (_clickToItem = new RelayCommand(() =>
                {
                    _isAdd = false;
                    if (selected != -1)
                    {
                        edit_add_title = "Goods Accounting: Edit";
                        NumberFormatInfo format = new NumberFormatInfo();
                        format.NumberGroupSeparator = ",";
                        format.NumberDecimalSeparator = "."; 
                        Item = GetItems[selected];
                        EditStrings[0] = Item.name;
                        EditStrings[1] = Item.price.ToString(format);
                        EditStrings[2] = Item.type;
                        EditStrings[3] = Item.count.ToString();
                        EditStrings[4] = String.Format("{0:000000}",Item.id);
                        EditItemView lv = new EditItemView(this);
                        lv.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Please, select item to edit");
                    }
                }));
            }
        }

        private ICommand _delete;
        public ICommand Delete
        {
            get
            {
                return _delete ?? (_delete = new RelayCommand(() =>
                {
                    if (selected != -1)
                    {
                        Item = GetItems[selected];
                        string data =
                            Helper.Client.Connect(String.Format("delete::{0}::{1}", warehouseName, Item.id));
                        if (data.StartsWith("0\n"))
                        {
                            MessageBox.Show("Product with id = " + Item.id + " has deleted");
                            string tmp =
                                Helper.Client.Connect(String.Format("show::{0}", warehouseName));
                            MainViewModel.data = tmp;
                            ParseData();
                            _items.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("Delete error " + data);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please, select item to delete");
                    }
                }));
            }
        }

        private ICommand _referesh;
        public ICommand Referesh
        {
            get
            {
                return _referesh ?? (_referesh = new RelayCommand(() =>
                {
                    string showTable = Helper.Client.Connect(String.Format("show::{0}", warehouseName));

                    if (showTable.StartsWith("-10\n"))
                    {
                        MessageBox.Show("Werhouse show error");
                    }
                    else if (showTable.StartsWith("0\n"))
                    {
                        MainViewModel.data = showTable;
                        ParseData();
                        _items.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Server error");
                    }
                }));
            }
        }

        private ICommand _addEd;
        public ICommand AddEd
        {
            get
            {
                return _addEd ?? (_addEd = new RelayCommand(() =>
                {
                    Item = new MyItem();
                    try
                    {
                        foreach (string s in EditStrings)
                        {
                            if (s.Contains(":"))
                            throw new Exception();
                        }

                        NumberFormatInfo format = new NumberFormatInfo();
                        format.NumberGroupSeparator = ",";
                        format.NumberDecimalSeparator = ".";           
                        Item.name = EditStrings[0];
                        Item.price = Double.Parse(EditStrings[1], format);
                        Item.type = EditStrings[2];
                        Item.count = Int32.Parse(EditStrings[3]);
                        Item.id = Int32.Parse(EditStrings[4]);
                        string insert_exit = "";
                        if (_isAdd)
                        {
                            insert_exit =
                                Helper.Client.Connect(String.Format("insert::{0}::{1}::{2}::{3}::{4}::{5}",
                                    warehouseName, Item.name, Item.price.ToString(format), Item.type, Item.count, Item.id));
                        }
                        else
                        {
                            insert_exit =
                                Helper.Client.Connect(String.Format("update::{0}::{1}::{2}::{3}::{4}::{5}",
                                    warehouseName, Item.name, Item.price.ToString(format), Item.type, Item.count, Item.id));
                        }

                        if (insert_exit.StartsWith("0\n"))
                        {
                            string tmp =
                                Helper.Client.Connect(String.Format("show::{0}", warehouseName));
                            MainViewModel.data = tmp;
                            ParseData();
                            _items.Refresh();
                            CloseActionEdit();
                        }
                        else if (insert_exit.StartsWith("2627\n"))
                        {
                            MessageBox.Show("Item with this ID already exist");
                        }
                        else
                            MessageBox.Show("Update error " + insert_exit);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Incorrect input data");
                    }
                }));
            }
        }

        private ICommand _cancel;
        public ICommand Cancel
        {
            get { return _cancel ?? (_cancel = new RelayCommand(() => { CloseActionEdit(); })); }
        }

        private ICommand _sortName;
        public ICommand SortName
        {
            get { return _sortName ?? (_sortName = new RelayCommand(() =>
            {
                GetItems.Sort(MyItem.CompareName);
                _items.Refresh();
                
            })); }
        }
        
        private ICommand _sortNumber;
        public ICommand SortNumber
        {
            get { return _sortNumber ?? (_sortNumber = new RelayCommand(() =>
            {
                GetItems.Sort(MyItem.CompareNumber);
                _items.Refresh();
                
            })); }
        }

        private ICommand _sortPrice;
        public ICommand SortPrice
        {
            get { return _sortPrice?? (_sortPrice = new RelayCommand(() =>
            {
                GetItems.Sort(MyItem.ComparePrice);
                _items.Refresh();
                
            })); }
        }

        private ICommand _sortCount;
        public ICommand SortCount
        {
            get { return _sortCount?? (_sortCount = new RelayCommand(() =>
            {
                GetItems.Sort(MyItem.CompareCount);
                _items.Refresh();
                
            })); }
        }

        private ICommand _sortType;
        public ICommand SortType
        {
            get { return _sortType?? (_sortType = new RelayCommand(() =>
            {
                GetItems.Sort(MyItem.CompareType);
                _items.Refresh();
                
            })); }
        }

        private ICommand _sortID;
        public ICommand SortID
        {
            get { return _sortID ?? (_sortID = new RelayCommand(() =>
            {
                GetItems.Sort(MyItem.CompareID);
                _items.Refresh();
                
            })); }
        }
#endregion
        
        public void ParseData()
        {
            MyItem.Items.Clear();
            MyItem.Counter = 0;
            data = data.Substring(2);
            string[] line = data.Split('\n');
            warehouseName = line[0];
            for (int i = 1; i < line.Length - 1; i++)
            {
                NumberFormatInfo format = new NumberFormatInfo();
                format.NumberGroupSeparator = ".";
                format.NumberDecimalSeparator = ",";       
                string[] itemStrings = line[i].Split('\t');
                MyItem.Items.Add(new MyItem()
                {
                    id = Int32.Parse(itemStrings[0]),
                    name = itemStrings[1],
                    price = Double.Parse(itemStrings[2], format),
                    type = itemStrings[3],
                    count = Int32.Parse(itemStrings[4])
                });
            }
        }

        public Action CloseActionEdit { get; set; }
        public Action CloseAction { get; set; }
    }
}
