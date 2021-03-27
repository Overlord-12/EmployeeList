using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public class Employee
    {
		public string FirstName { get; set; }
		public string SecondName { get; set; }
		public string SurName { get; set; }
		public string Phone { get; set; }
		public Department Department { get; set; } = Department.Departamen1;


		public Employee() { }
		public Employee(string firstname, string secondname, string surname, string phone, Department department)
		{
			FirstName = firstname;
			SecondName = secondname;
			SurName = surname;
			Phone = phone;
		}
		public string FIO
		{
			get { return $"{FirstName} {SecondName} {SurName}"; }
		}
	}
}
