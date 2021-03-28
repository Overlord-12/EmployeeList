using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace EmployeeList
{
    /// <summary>
    /// Логика взаимодействия для EditEmployee.xaml
    /// </summary>
    public partial class EditEmployee : Window
    {
        private EditorType editorType;
        public EditEmployee()
        {
            InitializeComponent();
            editorType = EditorType.Add;
        
            PrepareUI();
        }
        public EditEmployee(EditorType editorType)
        {
            InitializeComponent();

            this.editorType = editorType;
            PrepareUI();
        }

        private void PrepareUI()
        {

            switch (editorType)
            {
                case EditorType.Add:
                    this.Title = $"{this.Title} [Добавление]";
                    break;
                case EditorType.Edit:
                    this.Title = $"{this.Title} [Правка]";
                    break;
            }
            employeeControl.PrepareUI(editorType);
        }

        public Employee Contact { get; set; } = new Employee();

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {

            //contactControl.UpdateContact();
            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
