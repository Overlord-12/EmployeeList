
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using EmployeeBase;

namespace WebService
{
    /// <summary>
    /// Сводное описание для Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {
        

        
        public ObservableCollection<Employee> Employee { get; set; }
        string ConnectionString = 
            System.Configuration.ConfigurationManager.
            ConnectionStrings["EmployeeConectionStings"].ConnectionString;


        [WebMethod]
        public List<Employee> Load()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = $@"SELECT * FROM EMployeeList";


                var command = new SqlCommand(sql, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var employee = new Employee()
                            {
                                Phone = (string)reader.GetValue(4),
                                SurName = (string)reader.GetValue(2),
                                FirstName = (string)reader.GetValue(0),
                                SecondName = (string)reader.GetValue(1),
                                Department = (Department)reader.GetInt32(3),
                            };
                            employees.Add(employee);
                           
                        }

                    }
                    return employees;
                }

            }
        }
        [WebMethod]
        public int Remove(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = $@"DELETE FROM EMployeeList WHERE Phone = {employee.Phone}";
                var command = new SqlCommand(sql, connection);
                return command.ExecuteNonQuery();
                
            }
        }
        [WebMethod]
        public int Udate(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = $@"UPDATE EmployeeList SET 
                LastName = '{employee.SurName}',FirstName ='{employee.FirstName}' ,SecondName = '{employee.SecondName}'
                ,Departament ={(int)employee.Department} 
                 WHERE Phone  = '{employee.Phone}'
                ) 
                VALUES('{employee.Phone}','{employee.SurName}','{employee.FirstName}', '{employee.SecondName}', 
                {(int)employee.Department})";

                var command = new SqlCommand(sql, connection);
                return command.ExecuteNonQuery();

            }
        }
        [WebMethod]
        public int Add(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = $@"INSERT INTO EmployeeList (Phone,LastName,FirstName,SecondName,Departament) 
                VALUES('{employee.Phone}','{employee.SurName}','{employee.FirstName}', '{employee.SecondName}', 
                {(int)employee.Department})";

                var command = new SqlCommand(sql, connection);
                return command.ExecuteNonQuery();
              
            }
        }
    }
}
