using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using Lab2Assignment_WPF.Classes;
/// <summary>
/// ** Student Name     : Harbin Ramo
/// ** Student Number   : 301046044
/// ** Lab Assignment   : #2 - WPF
/// ** Date (MM/dd/yyy) : 01/24/2020
/// </summary>
namespace Lab2Assignment_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // ** Declare variable(s)
        private ObservableCollection<FoodMenu> _foodMenuList;
        private ObservableCollection<FoodMenu> _foodOrderList;
        private const double HST_TAX = 0.13;
        private string _orderSubTotal = "$0.00";
        private const string COLLEGE_URL = "https://www.centennialcollege.ca/";

        // ** Declare enum for Food Types
        enum FoodTypes
        {
            Appetizer,
            MainCourse,
            Beverage,
            Dessert
        }

        public MainWindow()
        {
            InitializeComponent();

            // ** Prepare initial data for the ObservableCollection(s)
            this.PrepareData();
        }

        // ** Prepare initial data for the ObservableCollection(s)
        public void PrepareData()
        {
            // ** Load menu list to ObservableCollection
            this._foodMenuList = new ObservableCollection<FoodMenu>()
            {
                new FoodMenu() { Name = "Buffalo Wings", Price = 5.95, FoodType = "Appetizer" },
                new FoodMenu() { Name = "Buffalo Fingers", Price = 6.95, FoodType = "Appetizer" },
                new FoodMenu() { Name = "Potato Skins", Price = 8.95, FoodType = "Appetizer" },
                new FoodMenu() { Name = "Nachos", Price = 8.95, FoodType = "Appetizer" },
                new FoodMenu() { Name = "Mushroom Caps", Price = 10.95, FoodType = "Appetizer" },
                new FoodMenu() { Name = "Shrimp Cocktail", Price = 12.95, FoodType = "Appetizer" },
                new FoodMenu() { Name = "Chips and Salsa", Price = 6.95, FoodType = "Appetizer" },

                new FoodMenu() { Name = "Seafood Alfredo", Price = 15.95, FoodType = "MainCourse" },
                new FoodMenu() { Name = "Chicken Alfredo", Price = 13.95, FoodType = "MainCourse" },
                new FoodMenu() { Name = "Chicken Picatta", Price = 13.95, FoodType = "MainCourse" },
                new FoodMenu() { Name = "Turkey Club", Price = 11.95, FoodType = "MainCourse" },
                new FoodMenu() { Name = "Lobster Pie", Price = 19.95, FoodType = "MainCourse" },
                new FoodMenu() { Name = "Prime Rib", Price = 20.95, FoodType = "MainCourse" },
                new FoodMenu() { Name = "Shrimp Scampi", Price = 18.95, FoodType = "MainCourse" },
                new FoodMenu() { Name = "Turkey Dinner", Price = 13.95, FoodType = "MainCourse" },
                new FoodMenu() { Name = "Stuffed Chicken", Price = 14.95, FoodType = "MainCourse" },

                new FoodMenu() { Name = "Soda", Price = 1.95, FoodType = "Beverage" },
                new FoodMenu() { Name = "Tea", Price = 1.50, FoodType = "Beverage" },
                new FoodMenu() { Name = "Coffee", Price = 1.25, FoodType = "Beverage" },
                new FoodMenu() { Name = "Mineral Water", Price = 2.95, FoodType = "Beverage" },
                new FoodMenu() { Name = "Juice", Price = 2.50, FoodType = "Beverage" },
                new FoodMenu() { Name = "Milk", Price = 1.50, FoodType = "Beverage" },

                new FoodMenu() { Name = "Apple Pie", Price = 5.95, FoodType = "Dessert" },
                new FoodMenu() { Name = "Sundae", Price = 3.95, FoodType = "Dessert" },
                new FoodMenu() { Name = "Carrot Cake", Price = 5.95, FoodType = "Dessert" },
                new FoodMenu() { Name = "Mud Pie", Price = 4.95, FoodType = "Dessert" },
                new FoodMenu() { Name = "Apple Crisp", Price = 5.95, FoodType = "Dessert" }
            };

            // ** Load Appetizer list
            this.LoadAppetizers(this._foodMenuList, Enum.GetName(typeof(FoodTypes), 0));

            // ** Load Main Course list
            this.LoadMainCourses(this._foodMenuList, Enum.GetName(typeof(FoodTypes), 1));

            // ** Load Beverage list
            this.LoadBeverages(this._foodMenuList, Enum.GetName(typeof(FoodTypes), 2));

            // ** Load Dessert list
            this.LoadDesserts(this._foodMenuList, Enum.GetName(typeof(FoodTypes), 3));

            // ** Instantiate ObservableCollection for Food Orders
            this._foodOrderList = new ObservableCollection<FoodMenu>();
            this.OrderListDataGrid.ItemsSource = this._foodOrderList;
        }

        // ** Load food items to each combo box
        private void LoadAppetizers(ObservableCollection<FoodMenu> _foodMenu, string _foodType)
        {
            this.AppetizerComboBox.Items.Add("-----");
            this.AppetizerComboBox.SelectedIndex = 0;

            foreach (FoodMenu f in _foodMenu.Where(fm => fm.FoodType == _foodType))
            {
                this.AppetizerComboBox.Items.Add(f.Name);
            }
        }
        private void LoadMainCourses(ObservableCollection<FoodMenu> _foodMenu, string _foodType)
        {
            this.MainCourseComboBox.Items.Add("-----");
            this.MainCourseComboBox.SelectedIndex = 0;

            foreach (FoodMenu f in _foodMenu.Where(fm => fm.FoodType == _foodType))
            {
                this.MainCourseComboBox.Items.Add(f.Name);
            }
        }
        private void LoadBeverages(ObservableCollection<FoodMenu> _foodMenu, string _foodType)
        {
            this.BeverageComboBox.Items.Add("-----");
            this.BeverageComboBox.SelectedIndex = 0;

            foreach (FoodMenu f in _foodMenu.Where(fm => fm.FoodType == _foodType))
            {
                this.BeverageComboBox.Items.Add(f.Name);
            }
        }
        private void LoadDesserts(ObservableCollection<FoodMenu> _foodMenu, string _foodType)
        {
            this.DessertComboBox.Items.Add("-----");
            this.DessertComboBox.SelectedIndex = 0;

            foreach (FoodMenu f in _foodMenu.Where(fm => fm.FoodType == _foodType))
            {
                this.DessertComboBox.Items.Add(f.Name);
            }
        }

        // ** Populate food items to data grid using combobox's selection change event
        private void AppetizerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.AppetizerComboBox.SelectedIndex > 0)
            {
                string _name = this.AppetizerComboBox.SelectedValue.ToString();
                this.PopulateDataGrid(_name);
            }
        }
        private void MainCourseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.MainCourseComboBox.SelectedIndex > 0)
            {
                string _name = this.MainCourseComboBox.SelectedValue.ToString();
                this.PopulateDataGrid(_name);
            }
        }
        private void BeverageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.BeverageComboBox.SelectedIndex > 0)
            {
                string _name = this.BeverageComboBox.SelectedValue.ToString();
                this.PopulateDataGrid(_name);
            }
        }
        private void DessertComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.DessertComboBox.SelectedIndex > 0)
            {
                string _name = this.DessertComboBox.SelectedValue.ToString();
                this.PopulateDataGrid(_name);
            }
        }

        // ** Populate food items to data grid
        private void PopulateDataGrid(string _name)
        {
            double _price = 0.00;
            foreach (FoodMenu fm in this._foodMenuList.Where(p => p.Name == _name))
            {
                // ** Check if food exists from the order list
                if (this._foodOrderList.Where(p => p.Name == _name).ToArray().Length == 1)
                {
                    MessageBox.Show($"{_name} already exist from the Order List.");
                    return;
                }
                else
                {
                    _price = fm.Price;
                    this._foodOrderList.Add(
                        new FoodMenu() { Name = _name, Price = _price }
                    );
                }
            }
        }

        // ** Remove a selected item from the data grid
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.OrderListDataGrid.Items.Count > 0)
            {
                MessageBoxResult _messageBoxResult = 
                    MessageBox.Show("Are you sure to remove this item?", "Remove entry", 
                    MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (_messageBoxResult == MessageBoxResult.Yes)
                {
                    int _currentRow = this.OrderListDataGrid.Items.IndexOf(this.OrderListDataGrid.CurrentItem);
                    this._foodOrderList.RemoveAt(_currentRow);
                    this.CalculateButton_Click(sender, e);
                }
            }
        }

        // ** Add a quantity of an ordered food
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            DataGridRow _dataGridRow = (DataGridRow)this.OrderListDataGrid.ItemContainerGenerator
                .ContainerFromIndex(this.OrderListDataGrid.Items.IndexOf(this.OrderListDataGrid.CurrentItem));

            FrameworkElement _frameworkElement0 = this.OrderListDataGrid.Columns[1].GetCellContent(_dataGridRow);
            FrameworkElement _frameworkElement1 = this.OrderListDataGrid.Columns[2].GetCellContent(_dataGridRow);
            FrameworkElement _frameworkElement2 = this.OrderListDataGrid.Columns[3].GetCellContent(_dataGridRow);

            TextBox _textBox0 = ((DataGridTemplateColumn)this.OrderListDataGrid.Columns[1]).CellTemplate
                .FindName("PriceTextBox", _frameworkElement0) as TextBox;
            TextBox _textBox1 = ((DataGridTemplateColumn)this.OrderListDataGrid.Columns[2]).CellTemplate
                .FindName("QuantityTextBox", _frameworkElement1) as TextBox;
            TextBox _textBox2 = ((DataGridTemplateColumn)this.OrderListDataGrid.Columns[3]).CellTemplate
                .FindName("SubTotalTextBox", _frameworkElement2) as TextBox;

            Button _button = ((DataGridTemplateColumn)this.OrderListDataGrid.Columns[2]).CellTemplate
                .FindName("DeductButton", _frameworkElement1) as Button;

            double _unitPrice = double.Parse(_textBox0.Text.Remove(0,1));
            int _increment = int.Parse(_textBox1.Text);
            double _subTotal = 0.0;

            _increment += 1;
            _textBox1.Clear();
            _textBox1.Text = _increment.ToString();
            _textBox2.Clear();

            _subTotal = _increment * _unitPrice;
            _textBox2.Clear();
            _textBox2.Text = _subTotal.ToString("C");

            _button.IsEnabled = true;

            //this.CalculateButton_Click(sender, e);
        }

        // ** Deduct a quantity of an ordered food
        private void DeductButton_Click(object sender, RoutedEventArgs e)
        {
            DataGridRow _dataGridRow = (DataGridRow)this.OrderListDataGrid.ItemContainerGenerator
                .ContainerFromIndex(this.OrderListDataGrid.Items.IndexOf(this.OrderListDataGrid.CurrentItem));

            FrameworkElement _frameworkElement0 = this.OrderListDataGrid.Columns[1].GetCellContent(_dataGridRow);
            FrameworkElement _frameworkElement1 = this.OrderListDataGrid.Columns[2].GetCellContent(_dataGridRow);
            FrameworkElement _frameworkElement2 = this.OrderListDataGrid.Columns[3].GetCellContent(_dataGridRow);

            TextBox _textBox0 = ((DataGridTemplateColumn)this.OrderListDataGrid.Columns[1]).CellTemplate
                .FindName("PriceTextBox", _frameworkElement0) as TextBox;
            TextBox _textBox1 = ((DataGridTemplateColumn)this.OrderListDataGrid.Columns[2]).CellTemplate
                .FindName("QuantityTextBox", _frameworkElement1) as TextBox;
            TextBox _textBox2 = ((DataGridTemplateColumn)this.OrderListDataGrid.Columns[3]).CellTemplate
                .FindName("SubTotalTextBox", _frameworkElement2) as TextBox;

            Button _button = ((DataGridTemplateColumn)this.OrderListDataGrid.Columns[2]).CellTemplate
                .FindName("DeductButton", _frameworkElement1) as Button;

            double _unitPrice = double.Parse(_textBox0.Text.Remove(0, 1));
            int _increment = int.Parse(_textBox1.Text);
            double _subTotal = double.Parse(_textBox2.Text.Remove(0, 1));

            _increment -= 1;
            if (_increment == 0)
            {
                _textBox1.Clear();
                _textBox1.Text = "0";
                _textBox2.Clear();
                _textBox2.Text = "$0.00";

                _button.IsEnabled = false;

                //this.CalculateButton_Click(sender, e);
            }
            else
            {
                _textBox1.Clear();
                _textBox1.Text = _increment.ToString();
                _textBox2.Clear();

                _subTotal = _subTotal - _unitPrice;
                _textBox2.Clear();
                _textBox2.Text = _subTotal.ToString("C");

                //this.CalculateButton_Click(sender, e);
            }
        }

        // ** Calculate for the Subtotal + Tax and Overall total ordered
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.OrderListDataGrid.Items.Count > 0)
            {
                int _totalFoodOrders = this.OrderListDataGrid.Items.Count;
                double _total = 0.0;

                for (int i = 0; i < _totalFoodOrders; i++)
                {
                    DataGridRow _dataGridRow = (DataGridRow)this.OrderListDataGrid.ItemContainerGenerator
                        .ContainerFromIndex(i);

                    FrameworkElement _frameworkElement2 = this.OrderListDataGrid.Columns[3].GetCellContent(_dataGridRow);
                    TextBox _textBox2 = ((DataGridTemplateColumn)this.OrderListDataGrid.Columns[3]).CellTemplate
                        .FindName("SubTotalTextBox", _frameworkElement2) as TextBox;

                    double _subTotal = double.Parse(_textBox2.Text.Remove(0, 1));
                    _total += _subTotal;
                }

                _orderSubTotal = _total.ToString("C");

                double _totalAfterTax = _total * HST_TAX;
                this.TaxTextBox.Text = _totalAfterTax.ToString("C");

                _total = _total + _totalAfterTax;
                this.TotalBillTextBox.Text = _total.ToString("C");
            }
            else
            {
                this.ClearOrderList();
            }
        }

        // ** Clear order list
        private void ClearOrderList()
        {
            this.AppetizerComboBox.SelectedIndex = 0;
            this.MainCourseComboBox.SelectedIndex = 0;
            this.BeverageComboBox.SelectedIndex = 0;
            this.DessertComboBox.SelectedIndex = 0;
            this.TotalBillTextBox.Text = "$0.00";
            this.TaxTextBox.Text = "$0.00";
            this._foodOrderList.Clear();
            MessageBox.Show("No order(s) on the list.");
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult _messageBoxResult =
                MessageBox.Show("Are you sure to clear the food order list?", "Remove entry(ies)",
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (_messageBoxResult == MessageBoxResult.Yes)
            {
                this.ClearOrderList();
            }
        }

        // ** Print food order/invoice
        private void PrintButton(object sender, RoutedEventArgs e)
        {
            if (this.OrderListDataGrid.Items.Count > 0)
            {
                MessageBox.Show("Successfully printed food order list.", "Print", 
                    MessageBoxButton.OK, MessageBoxImage.Information);

                string _foodList;

                _foodList = "********** Centennial Food Corner 101 **********" + Environment.NewLine;
                _foodList += ">>" + Environment.NewLine;
                _foodList += $"Date Printed: {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}" 
                    + Environment.NewLine
                    + Environment.NewLine;
                _foodList += $"{"QTY".PadRight(5, ' ')}" +
                    $"{"ITEM(S)".PadRight(30, ' ')}" +
                    $"{"PRICE".PadRight(10, ' ')}" +
                    $"{"SUBTOTAL".PadRight(10, ' ')}" + Environment.NewLine;

                int _totalOrders = this.OrderListDataGrid.Items.Count;
                for (int _i = 0; _i < _totalOrders; _i++)
                {
                    DataGridRow _dataGridRow = (DataGridRow)this.OrderListDataGrid.ItemContainerGenerator
                        .ContainerFromIndex(_i);

                    FrameworkElement _frameworkElement0 = this.OrderListDataGrid.Columns[0].GetCellContent(_dataGridRow);
                    FrameworkElement _frameworkElement1 = this.OrderListDataGrid.Columns[1].GetCellContent(_dataGridRow);
                    FrameworkElement _frameworkElement2 = this.OrderListDataGrid.Columns[2].GetCellContent(_dataGridRow);
                    FrameworkElement _frameworkElement3 = this.OrderListDataGrid.Columns[3].GetCellContent(_dataGridRow);

                    TextBox _textBox0 = ((DataGridTemplateColumn)this.OrderListDataGrid.Columns[0]).CellTemplate
                        .FindName("NameTextBox", _frameworkElement0) as TextBox;
                    TextBox _textBox1 = ((DataGridTemplateColumn)this.OrderListDataGrid.Columns[1]).CellTemplate
                        .FindName("PriceTextBox", _frameworkElement1) as TextBox;
                    TextBox _textBox2 = ((DataGridTemplateColumn)this.OrderListDataGrid.Columns[2]).CellTemplate
                        .FindName("QuantityTextBox", _frameworkElement2) as TextBox;
                    TextBox _textBox3 = ((DataGridTemplateColumn)this.OrderListDataGrid.Columns[3]).CellTemplate
                        .FindName("SubTotalTextBox", _frameworkElement3) as TextBox;

                    _foodList += 
                        $"{_textBox2.Text.PadRight(5, ' ')} " +
                        $"{_textBox0.Text.PadRight(30, ' ')} " +
                        $"{_textBox1.Text.PadRight(10,' ')}" +
                        $"{_textBox3.Text.PadRight(10, ' ')}" + Environment.NewLine;
                }

                _foodList += Environment.NewLine + Environment.NewLine;
                _foodList += $"HST 13% - {this.TaxTextBox.Text}" + Environment.NewLine;
                _foodList += $"Subtotal - {this._orderSubTotal}" + Environment.NewLine;
                _foodList += $"Total Bill - {this.TotalBillTextBox.Text}" + Environment.NewLine;
                _foodList += ">>" + Environment.NewLine;
                _foodList += "********** End of receipt **********";

                MessageBox.Show(_foodList);
            }
        }

        // ** Open College URL
        private void LinkButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(COLLEGE_URL);
        }
    }

}
