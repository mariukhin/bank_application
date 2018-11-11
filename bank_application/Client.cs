using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_application
{
    public class Client : User
    {
		private List<Credit> creditsList = new List<Credit>();
		private List<Deposit> depositsList = new List<Deposit>();
		private List<Card> cardsList = new List<Card>();

		public string Login { get; set; }
		public int Cashback { get; set; }
		public int Moneybox { get; set; }

		public Client(string Firstname, string Surname, string DateOfBirth, string PassportSeries, int PassportNum,
			string Adress, string Email, string Phonenumber, string Password, string Login, int Cashback, int Moneybox) : base(Firstname, Surname, DateOfBirth, PassportSeries, PassportNum, Adress, Email, Phonenumber, Password)
		{
			this.Firstname = Firstname;
			this.Surname = Surname;
			this.DateOfBirth = DateOfBirth;
			this.PassportSeries = PassportSeries;
			this.PassportNum = PassportNum;
			this.Adress = Adress;
			this.Email = Email;
			this.Phonenumber = Phonenumber;
			this.Login = Login;
			this.Password = Password;
			this.Cashback = Cashback;
			this.Moneybox = Moneybox;
		}
		//private void SetLogin(bool isLogin)
		//{
		//	if (isLogin)
		//	{
		//		Login = Email;
		//	}
		//	else
		//	{
		//		Login = Phonenumber;
		//	}
		//}
		//private void SetCashback() { }
		//public Credit Credit
		//{
		//	get
		//	{
		//		if (ID == null)
		//			return null;
		//		try
		//		{
		//			return Credit.data[ID];
		//		}
		//		catch (Exception) { }
		//		return null;

		//	}
		//	set { ID = value.ID; }
		//}
		//public Deposit Deposit
		//{
		//	get
		//	{
		//		if (ID == null)
		//			return null;
		//		try
		//		{
		//			return Deposit.data[ID];
		//		}
		//		catch (Exception) { }
		//		return null;

		//	}
		//	set { ID = value.ID; }
		//}
		//public Card Card
		//{
		//	get
		//	{
		//		if (ID == null)
		//			return null;
		//		try
		//		{
		//			return Card.data[ID];
		//		}
		//		catch (Exception) { }
		//		return null;

		//	}
		//	set { ID = value.ID; }
		//}



		//public static void getPersonalData()
		//{
		//	return
		//}


		//public Client getCashback()
		//{
		//	//произвести расчет кешбека и вернуть его
		//	return Cashback;
		//}

		//private void AddToDB(Client client) { }

		//private void CheckValid(Client client) { return true/false }


		//функция проверки логина на актуальность

		public List<Credit> getCreditsList()
		{
			return creditsList;
		}
		public override string ToString()
		{
			return Login + '|'+ Surname+ '|'+ PassportNum+ '|'+ Firstname;
		}
	}
}
