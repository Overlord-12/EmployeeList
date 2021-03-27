using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EmployeeList
{
    class GenerateEmployee
    {
        public ObservableCollection<Employee> Employee { get; set; }
        private static string[] PhonePrefics = { "906", "905", "495" };
        private static int CHAR_LOW = 65;
        private static int CHAR_MAX = 90;
        private Random rand = new Random();
        Department department { get; set; }

        public GenerateEmployee()
        {
            Employee = new ObservableCollection<Employee>();
            GenerateWorker(30);
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

