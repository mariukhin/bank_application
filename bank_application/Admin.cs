using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_application
{
	public class Admin : User
	{
		private List<Request> requestsList = new List<Request>();

		public Admin(string Firstname, string Surname, string DateOfBirth, string PassportSeries, int PassportNum,
			string Adress, string Email, string Phonenumber, string Password) : base(Firstname, Surname, DateOfBirth, PassportSeries, PassportNum, Adress, Email, Phonenumber, Password)
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
