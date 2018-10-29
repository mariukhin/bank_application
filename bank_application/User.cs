using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_application
{
	public class User
	{
		public string Firstname { get; set; }
		public string Surname { get; set; }
		public string DateOfBirth { get; set; }
		public string Email { get; set; }
		public string Phonenumber { get; set; }
		public string Adress { get; set; }
		public string PassportSeries { get; set; }
		public int PassportNum { get; set; }
		public string Password { get; set; }

		public User(string Firstname, string Surname, string DateOfBirth, string PassportSeries, int PassportNum,
			string Adress, string Email, string Phonenumber, string Password)
		{
			this.Firstname = Firstname;
			this.Surname = Surname;
			this.DateOfBirth = DateOfBirth;
			this.PassportSeries = PassportSeries;
			this.PassportNum = PassportNum;
			this.Adress = Adress;
			this.Email = Email;
			this.Phonenumber = Phonenumber;
			this.Password = Password;
		}
	}
}
