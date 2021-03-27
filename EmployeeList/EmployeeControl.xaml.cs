﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для EmployeeControl.xaml
    /// </summary>
    public partial class EmployeeControl : UserControl, INotifyPropertyChanged
    {
        ObservableCollection<Department> Departments = new ObservableCollection<Department>();

        private Employee _employee;

        public Employee Employee
        {
            get { return _employee; }
            set {
                _employee = value;
                NotifyPropertyChanged();
                }
        }
    

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public EmployeeControl()
        {
            InitializeComponent();
            this.DataContext = this;
            Departments.Add(Department.Departamen1);
            Departments.Add(Department.Departament2);
            Departments.Add(Department.Departament3);
          
        }


       

        //public void Get(Employee employee)
        //{
        //    this.employee = employee;
        //    TbPhone.Text = employee.Phone;
        //    TbFirstName.Text = employee.FirstName;
        //    TbSurName.Text = employee.SurName;
        //    TbSecondName.Text = employee.SecondName;
        //    CbDepartament.SelectedItem = employee.Department;
        //}

        //public Employee Set()
        //{

        //    employee.Phone = TbPhone.Text;
        //    employee.FirstName = TbFirstName.Text;
        //    employee.SurName = TbSurName.Text;
        //    employee.SecondName = TbSecondName.Text;
        //    employee.Department = (Department)CbDepartament.SelectedItem;
        //    return employee;
        //}

        public void Add()
        {
            string phone = TbPhone.Text;
            string firstname = TbFirstName.Text;
            string secondname = TbSecondName.Text;
            string surname = TbSecondName.Text;

            //generate.Employee.Add(new Employee(firstname, secondname, surname, phone, ));
        }
    }
}
