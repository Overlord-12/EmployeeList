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


        public const string ConnectionString = "Data Source = localhost; Initial " +
        "Catalog = EmployeeBase; User ID = EmployeeManager;Password = 123";
        public ObservableCollection<Employee> Employee { get; set; }
        private static string[] PhonePrefics = { "906", "905", "495" };
        private static int CHAR_LOW = 65;
        private static int CHAR_MAX = 90;
        private Random rand = new Random();
        Department department { get; set; }

        public GenerateEmployee()
        {
            Employee = new ObservableCollection<Employee>();
            LoadFromDataBase();


        }


        private string GenerateSymbols(int amount)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < amount; i++)
            {
                stringBuilder.Append((char)(CHAR_LOW + rand.Next(CHAR_MAX - CHAR_LOW)));
            }
            return stringBuilder.ToString();
        }
        //public void  SyncToDataBase()
        //{
        //    foreach (var employee in Employee)
        //        Add(employee);
        //}
        public int Add(Employee employee)
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = $@"INSERT INTO EmployeeList (Phone,LastName,FirstName,SecondName,Departament) 
                VALUES('{employee.Phone}','{employee.SurName}','{employee.FirstName}', '{employee.SecondName}', 
                {(int)employee.Department})";

               var command = new SqlCommand(sql, connection);
                var res = command.ExecuteNonQuery();
                if (res > 0)
                {
                    Employee.Add(employee);
                }
                return res;
            }
        }

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

        public void LoadFromDataBase()
        {
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
                            Employee.Add(employee);
                        }
                       
                    }   
                }
                   
            }
        }
        public int  Remove(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
               
                string sql = $@"DELETE FROM EMployeeList WHERE Phone = {employee.Phone}";
                var command = new SqlCommand(sql, connection);
                var res = command.ExecuteNonQuery();
                if (res > 0)
                {
                    Employee.Remove(employee);
                }
                return res;
            }
        }

        private string GenerateNumber()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("+7").Append(PhonePrefics[rand.Next(3)]);
            for (int i = 0; i < 6; i++)
            {
                stringBuilder.Append(rand.Next(10));
            }
            return stringBuilder.ToString();
        }

        private void GenerateWorker(int count)
        {
            Employee.Clear();
            string firstname = GenerateSymbols(rand.Next(5) + 4);
            string secondname = GenerateSymbols(rand.Next(5) + 4);
            string surname = GenerateSymbols(rand.Next(5) + 4);




            for (int i = 0; i < count; i++)
            {
                if (rand.Next(2) == 0)
                {
                    firstname = GenerateSymbols(rand.Next(5) + 4);
                    secondname = GenerateSymbols(rand.Next(5) + 4);
                    surname = GenerateSymbols(rand.Next(5) + 4);
                    department = (Department)rand.Next(0, 3);
                }

                string phone = GenerateNumber();
                Employee.Add(new Employee(firstname, secondname, surname, phone, department));
            }
        }
    }


}

