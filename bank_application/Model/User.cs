using bank_application.Command;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace bank_application
{
	public class User: DBhelperClass, INotifyPropertyChanged
	{
		public int Id { get; set; }
		private string firstname;
		private string surname;
		private string dateofbirth;
		private string email;
		private string phonenumber;
		private string adress;
		private string passportseries;
		private int passportnum;
		private string password;

		public User(int Id, string Firstname, string Surname, string DateOfBirth, string PassportSeries, int PassportNum,
			string Adress, string Email, string Phonenumber, string Password)
		{
			this.Id = Id;
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
		public string Firstname
		{
			get { return firstname; }
			set
			{
				firstname = value;
				OnPropertyChanged("Firstname");
			}
		}
		public string Surname
		{
			get { return surname; }
			set
			{
				surname = value;
				OnPropertyChanged("Surname");
			}
		}
		public string DateOfBirth
		{
			get { return dateofbirth; }
			set
			{
				dateofbirth = value;
				OnPropertyChanged("DateOfBirth");
			}
		}
		public string Email
		{
			get { return email; }
			set
			{
				email = value;
				OnPropertyChanged("Email");
			}
		}
		public string Phonenumber
		{
			get { return phonenumber; }
			set
			{
				phonenumber = value;
				OnPropertyChanged("Phonenumber");
			}
		}
		public string Adress
		{
			get { return adress; }
			set
			{
				adress = value;
				OnPropertyChanged("Adress");
			}
		}
		public string PassportSeries
		{
			get { return passportseries; }
			set
			{
				passportseries = value;
				OnPropertyChanged("PassportSeries");
			}
		}
		public int PassportNum
		{
			get { return passportnum; }
			set
			{
				passportnum = value;
				OnPropertyChanged("PassportNum");
			}
		}
		public string Password
		{
			get { return password; }
			set
			{
				password = value;
				OnPropertyChanged("Password");
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
	}
}
