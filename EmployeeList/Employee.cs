using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeList
{
    public class Employee: INotifyPropertyChanged, ICloneable
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private string _firstname;
		private string _phone;
		private string _secondname;
		private string _surname;
		private Department _departament = Department.Departamen1;



			public string FirstName {
            get { return _firstname; }
            set
            {
				_firstname = value;
				NotifyPropertyChanged();

			}
			}

			public string SecondName { 
				get { return _secondname; }
				set
				{
					_secondname = value;
					NotifyPropertyChanged();
				}
		
			}

			public string SurName
			 {
				get { return _surname; }
				set { 
					_surname = value;
					NotifyPropertyChanged();
				}
			}
			public string Phone {
            get { return _phone; }
			set {
					_phone = value;
					NotifyPropertyChanged();
				}
			}
			public Department Department
			{
            get { return _departament; }
			set
				{
					_departament = value;
					NotifyPropertyChanged();

				}
			}


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



		private void NotifyPropertyChanged([CallerMemberName]string propertyName = "")
        {
			if (PropertyChanged != null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public object Clone()
        {
			return MemberwiseClone();
        }
    }
	
}
