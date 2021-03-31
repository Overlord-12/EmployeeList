using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.ServiceReference1
{
    public partial class Employee : ICloneable
    {
        public object Clone()
        {
            return MemberwiseClone();
        }
        public Employee(string firstname, string secondname, string surname, string phone, Department department)
        {
            FirstName = firstname;
            SecondName = secondname;
            SurName = surname;
            Phone = phone;
        }
        public Employee() { }

        public string FIO
        {
            get { return $"{FirstName} {SecondName} {SurName}"; }
        }



        
        }
    }
}
