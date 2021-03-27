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

namespace EmployeeList
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GenerateEmployee generate = new GenerateEmployee();

        public ObservableCollection<Employee> employees { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            employees = generate.Employee;
            this.DataContext = this;
         
        }

        public Employee SelectedContact { get; set; }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            if (ListEmployee.SelectedItems.Count < 1) return;
            //ListEmployee(ListEmployee.IndexOf(SelectedContact));


        }
       
        private void BtDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ListEmployee.SelectedItems.Count < 1) return;


            if (MessageBox.Show("Удалить контакт?","Удаление контакта", MessageBoxButton.YesNo,
                MessageBoxImage.Question)== MessageBoxResult.Yes)
            {
                generate.Employee.Remove((Employee)ListEmployee.SelectedItems[0]);
        
            }

        }

        private void BtAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count !=0)
            {
                EmployeeControl.Employee = (Employee)SelectedContact.Clone();
            }
        }
    }
}
