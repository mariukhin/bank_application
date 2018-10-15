using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_application
{
    public class Client
    {
		private List<Credit> creditsList = new List<Credit>();
		private List<Deposit> depositsList = new List<Deposit>();
		private List<Card> cardsList = new List<Card>();

		public string Firstname { get; set; }
		public string Surname { get; set; }
		public int Age { get; set; }
		public string Email { get; set; }
		public string Phonenumber { get; set; }
		public string Adress { get; set; }
		public string PassportNum { get; set; }
		private string Login;
		private int Cashback;
		private int Moneybox;
		private string Password { get; set; }

		public Client(string Firstname, string Surname, int Age, string PassportNum, 
			string Adress,string Login, string Email, string Phonenumber, string Password)
		{
			this.Firstname = Firstname;
			this.Surname = Surname;
			this.Age = Age;
			this.PassportNum = PassportNum;
			this.Adress = Adress;
			this.Login = Login;
			this.Email = Email;
			this.Phonenumber = Phonenumber;
			this.Password = Password;
		}
		private void SetLogin(bool isLogin)
		{
			if (isLogin)
			{
				Login = Email;
			}
			else
			{
				Login = Phonenumber;
			}
		}
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
			return Login;
		}
	}
}
