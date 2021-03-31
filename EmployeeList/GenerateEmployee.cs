using Configuration.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EmployeeList
{
    class GenerateEmployee
    {

        private ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
        public ObservableCollection<Employee> Employee { get; set; }
        public GenerateEmployee()
        {
            Employee = new ObservableCollection<Employee>();
            LoadFromDataBase();


        }

        public int Add(Employee employee)
        {
            var res = serviceSoapClient.Add(employee);
            if (res > 0)
            {
                Employee.Add(employee);
            }
            return res;
        }

        public int Udate(Employee employee)
        {
            return serviceSoapClient.Udate(employee);
        }

        public void LoadFromDataBase()
        {
            foreach (var employee in serviceSoapClient.Load())
                Employee.Add(employee);
        }
        public int  Remove(Employee employee)
        {
            var res =  serviceSoapClient.Remove(employee);
            if (res > 0)
            {
                Employee.Remove(employee);
            }
            return res;
        }

        

    }


}

