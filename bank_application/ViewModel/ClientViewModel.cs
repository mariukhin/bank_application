using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using bank_application.Command;

namespace bank_application.ViewModel
{
	public class ClientViewModel : INotifyPropertyChanged
	{

		/// <summary>
		///  Client 
		/// </summary>
		private Client client;
		private Request request;
		private string password;
		private string login;
		private bool regchecked;
		private string firstname;
		private string surname;
		private string dateofbirth;
		private string email;
		private string phonenumber;
		private string paspseries;
		private string paspnum;
		private string adress;
		private string clientname;
		private ObservableCollection<Credit> credits;
		private ObservableCollection<Deposit> deposits;
		private ObservableCollection<Card> cards;


		/// <summary>
		/// Credit
		/// </summary>
		private Credit credit;
		private string durationCr;
		private string numberCr;
		private Card cardnumbercr;
		private bool isconfirmcr;


		/// <summary>
		/// Deposit
		/// </summary>
		private Deposit deposit;
		private string durationDep;
		private string numberDep;
		private Card cardnumberdep;
		private string typeDep;
		private bool isconfirmdep;
		private bool checkedftype;
		private bool checkedstype;


		/// <summary>
		/// Card
		/// </summary>
		private Card card;
		private string cardnumber;
		private string cardname;
		private string pin;
		private int cvcode;
		private string term;
		private int money;
		private bool isconfirmcard;

		/// <summary>
		/// Transaction
		/// </summary>
		private Transaction transaction;
		private string transfercardgive;
		private Card transfercardsend;
		private string transfermoney;


		public ClientViewModel() { }

		public ClientViewModel(string Login, string Password)
		{
			this.Login = Login;
			this.Password = Password;
		}

		private RelayCommand transferMoneyCommand;
		public RelayCommand TransferMoneyCommand
		{
			get
			{
				return transferMoneyCommand ??
					(transferMoneyCommand = new RelayCommand(obj =>
					{
						if (Checked == true)
						{
							if (TransferCardGive != null && TransferCardSend != null && TransferMoney != null)
							{
								int trmoney = Convert.ToInt32(TransferMoney);
								Transaction = new Transaction(1 ,TransferCardSend.CardNumber, TransferCardGive, trmoney);
								if (Transaction.CheckPayingCapacity(trmoney, TransferCardSend.Money))
								{
									if (Transaction.CheckGiveCard(TransferCardGive) != null)
									{
										Transaction.CheckTransaction(TransferCardSend, TransferCardGive, trmoney);
										Cards.Clear();
										Cards = Client.CreateCards(Client.Id);
										Application.Current.Windows[2].Close();
									}
									else
									{
										MessageBox.Show("Give card isn't real!Check and try again");
									}
								}
								else
								{
									MessageBox.Show("You don't have enough money for this operation!");
								}
							}
							else
							{
								MessageBox.Show("Full all fields!");
							}
						}
						else
						{
							MessageBox.Show("You have to agree with all agreenments");
						}
					}));
			}
		}

		private RelayCommand addCardCommand;
		public RelayCommand AddCardCommand
		{
			get
			{
				return addCardCommand ??
					(addCardCommand = new RelayCommand(obj =>
					{
						if (Checked == true)
						{
							if (CardName != null && PIN != null)
							{
								int pin = Convert.ToInt32(PIN);
								Card = new Card(1, "3433243432325444", CardName, pin, 544, "03.11.2023",0, Client.Id, IsConfirmCard);
								if (Card.GetCurrentCard(Card) == null)
								{
									Card.AddNewCard(Card);
									Card = Card.GetCurrentCard(Card);
									Request = new Request(1, Client.Id, 2, Card.Id, DateTime.Now, "Add new card");
									Request.AddNewRequest(Request);
									Application.Current.Windows[2].Close();
								}
								else
								{
									MessageBox.Show("This card is already exists!");
								}
							}
							else
							{
								MessageBox.Show("Full all fields!");
							}
						}
						else
						{
							MessageBox.Show("You have to agree with all agreenments");
						}
					}));
			}
		}

		private RelayCommand addDepositCommand;
		public RelayCommand AddDepositCommand
		{
			get
			{
				return addDepositCommand ??
					(addDepositCommand = new RelayCommand(obj =>
					{
						if (Checked == true)
						{
							if (CheckedFType)
							{
								TypeDep = "With early termination";
							}
							else
							{
								TypeDep = "Without early interruption";
							}
							if (NumberDep != null && DurationDep != null && TypeDep != null)
							{
								int number = Convert.ToInt32(NumberDep);
								int dur = Convert.ToInt32(DurationDep);
								Deposit = new Deposit(1, dur, number,CardNumberDep.CardNumber,TypeDep, Client.Id, IsConfirmDep);
								if (Deposit.GetCurrentDeposit(Deposit) == null)
								{
									if (Deposit.AddNewDeposit(Deposit, CardNumberDep))
									{
										Deposit = Deposit.GetCurrentDeposit(Deposit);
										Request = new Request(1, Client.Id, 2, Deposit.Id, DateTime.Now, "Add new deposit");
										Request.AddNewRequest(Request);
										Application.Current.Windows[2].Close();
									}
									else
									{
										MessageBox.Show("You don't have enough money for this operation");
									}
								}
								else
								{
									MessageBox.Show("This deposit is already exists!");
								}
							}
							else
							{
								MessageBox.Show("Full all fields!");
							}
						}
						else
						{
							MessageBox.Show("You have to agree with all agreenments");
						}
					}));
			}
		}



		private RelayCommand addCreditCommand;
		public RelayCommand AddCreditCommand
		{
			get
			{
				return addCreditCommand ??
					(addCreditCommand = new RelayCommand(obj =>
					{
						if (Checked == true)
						{
							if (NumberCr != null && DurationCr != null)
							{
								int number = Convert.ToInt32(NumberCr);
								int dur = Convert.ToInt32(DurationCr);
								Credit = new Credit(1, dur, number, CardNumberCr.CardNumber , Client.Id, IsConfirmCr);
								if (Credit.GetCurrentCredit(Credit) == null)
								{
									Credit.AddNewCredit(Credit, CardNumberCr);
									Credit = Credit.GetCurrentCredit(Credit);
									Request = new Request(1, Client.Id, 2, Credit.Id, DateTime.Now, "Add new credit");
									Request.AddNewRequest(Request);
									Application.Current.Windows[2].Close();
								}
								else
								{
									MessageBox.Show("This credit is already exists!");
								}
							}
							else
							{
								MessageBox.Show("Full all fields!");
							}
						}
						else
						{
							MessageBox.Show("You have to agree with all agreenments");
						}
					}));
			}
		}

		private RelayCommand addCommand;
		public RelayCommand AddCommand
		{
			get
			{
				return addCommand ??
					(addCommand = new RelayCommand(obj =>
					{
						if (Checked == true)
						{
							Login = Email;
						}
						else
						{
							Login = Phonenumber;
						}
						if (FirstName != null && SurName != null && DateOfBirth != null && Email != null && Login != null && Password != null &&
						Adress != null && PaspSeries != null && PaspNum != null)
						{
							int paspNum = Convert.ToInt32(PaspNum);
							Client = new Client(1, FirstName, SurName, DateOfBirth, PaspSeries, paspNum ,Adress, Email, Phonenumber, Login, Password, 0, 0);
							if (Client.AuthClient(Client) == null)
							{
								Client.AddNewClient(Client);
								Client = Client.AuthClient(Client);
								Application.Current.Windows[2].Close();
							}
							else
							{
								MessageBox.Show("This user is already exists!");
							}
						}
						else
						{
							MessageBox.Show("Full all fields!");
						}
					}));
			}
		}

		private RelayCommand loginCommand;
		public RelayCommand LoginCommand
		{
			get
			{
				return loginCommand ??
					(loginCommand = new RelayCommand(obj =>
					{
						if (Login != null && Password != null)
						{
								client = new Client(0, "user", "user", "23.02.1003", "VV", 2349959, "dfddd", "dd@kkd.xc", "243320030", Login, Password, 0.0, 0);
								if (Client.AuthClient(Client) != null)
								{
									Client = Client.AuthClient(Client);
									Credits = Client.CreateCredits(Client.Id);
									Cards = Client.CreateCards(Client.Id);
									Deposits = Client.CreateDeposits(Client.Id);
									ClientName = "Client: " + Client.Firstname + ' ' + Client.Surname;
									MainWindow mainWindow = new MainWindow(this);
									mainWindow.Show();
									Application.Current.Windows[0].Close();
								}
								else
								{
									MessageBox.Show("Your login or password is invalid! Please try again");
								}
						}
						else
						{
							MessageBox.Show("Put your data!");
						}
					}));
			}
		}

		public string TransferMoney
		{
			get { return transfermoney; }
			set
			{
				transfermoney = value;
				OnPropertyChanged("TransferMoney");
			}
		}
		public string TransferCardGive
		{
			get { return transfercardgive; }
			set
			{
				transfercardgive = value;
				OnPropertyChanged("TransferCardGive");
			}
		}
		public Card TransferCardSend
		{
			get { return transfercardsend; }
			set
			{
				transfercardsend = value;
				OnPropertyChanged("TransferCardSend");
			}
		}
		public Transaction Transaction
		{
			get { return transaction; }
			set
			{
				transaction = value;
				OnPropertyChanged("Transaction");
			}
		}


		public Card Card
		{
			get { return card; }
			set
			{
				card = value;
				OnPropertyChanged("Card");
			}
		}
		public ObservableCollection<Card> Cards
		{
			get { return cards; }
			set
			{
				cards = value;
				OnPropertyChanged("Cards");
			}
		}
		public string CardName
		{
			get { return cardname; }
			set
			{
				cardname = value;
				OnPropertyChanged("CardName");
			}
		}
		public string CardNumber
		{
			get { return cardnumber; }
			set
			{
				cardnumber = value;
				OnPropertyChanged("CardNumber");
			}
		}
		public string PIN
		{
			get { return pin; }
			set
			{
				pin = value;
				OnPropertyChanged("PIN");
			}
		}
		public int CVcode
		{
			get { return cvcode; }
			set
			{
				cvcode = value;
				OnPropertyChanged("CVcode");
			}
		}
		public string Term
		{
			get { return term; }
			set
			{
				term = value;
				OnPropertyChanged("Term");
			}
		}
		public int Money
		{
			get { return money; }
			set
			{
				money = value;
				OnPropertyChanged("Money");
			}
		}
		public bool IsConfirmCard
		{
			get { return isconfirmcard; }
			set
			{
				isconfirmcard = value;
				OnPropertyChanged("IsConfirmCard");
			}
		}




		public Deposit Deposit
		{
			get { return deposit; }
			set
			{
				deposit = value;
				OnPropertyChanged("Deposit");
			}
		}
		public ObservableCollection<Deposit> Deposits
		{
			get { return deposits; }
			set
			{
				deposits = value;
				OnPropertyChanged("Deposits");
			}
		}
		public string DurationDep
		{
			get { return durationDep; }
			set
			{
				durationDep = value;
				OnPropertyChanged("DurationDep");
			}
		}
		public string NumberDep
		{
			get { return numberDep; }
			set
			{
				numberDep = value;
				OnPropertyChanged("NumberDep");
			}
		}
		public string TypeDep
		{
			get { return typeDep; }
			set
			{
				typeDep = value;
				OnPropertyChanged("TypeDep");
			}
		}
		public Card CardNumberDep
		{
			get { return cardnumberdep; }
			set
			{
				cardnumberdep = value;
				OnPropertyChanged("CardNumberDep");
			}
		}
		public bool IsConfirmDep
		{
			get { return isconfirmdep; }
			set
			{
				isconfirmdep = value;
				OnPropertyChanged("IsConfirmDep");
			}
		}
		public bool CheckedFType
		{
			get { return checkedftype; }
			set
			{
				checkedftype = value;
				OnPropertyChanged("CheckedFType");
			}
		}
		public bool CheckedSType
		{
			get { return checkedstype; }
			set
			{
				checkedstype = value;
				OnPropertyChanged("CheckedSType");
			}
		}


		public Credit Credit
		{
			get { return credit; }
			set
			{
				credit = value;
				OnPropertyChanged("Credit");
			}
		}
		public Request Request
		{
			get { return request; }
			set
			{
				request = value;
				OnPropertyChanged("Request");
			}
		}
		public string DurationCr
		{
			get { return durationCr; }
			set
			{
				durationCr = value;
				OnPropertyChanged("DurationCr");
			}
		}
		public string NumberCr
		{
			get { return numberCr; }
			set
			{
				numberCr = value;
				OnPropertyChanged("NumberCr");
			}
		}
		public Card CardNumberCr
		{
			get { return cardnumbercr; }
			set
			{
				cardnumbercr = value;
				OnPropertyChanged("CardNumberCr");
			}
		}
		public bool IsConfirmCr
		{
			get { return isconfirmcr; }
			set
			{
				isconfirmcr = value;
				OnPropertyChanged("IsConfirmCr");
			}
		}
		public ObservableCollection<Credit> Credits
		{
			get { return credits; }
			set
			{
				credits = value;
				OnPropertyChanged("Credits");
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

		public string Login
		{
			get { return login; }
			set
			{
				login = value;
				OnPropertyChanged("Login");
			}
		}
		public Client Client
		{
			get { return client; }
			set
			{
				client = value;
				OnPropertyChanged("Client");
			}
		}
		public bool Checked
		{
			get { return regchecked; }
			set
			{
				regchecked = value;
				OnPropertyChanged("Checked");
			}
		}
		public string FirstName
		{
			get { return firstname; }
			set
			{
				firstname = value;
				OnPropertyChanged("FirstName");
			}
		}
		public string SurName
		{
			get { return surname; }
			set
			{
				surname = value;
				OnPropertyChanged("SurName");
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
		public string ClientName
		{
			get { return clientname; }
			set
			{
				clientname = value;
				OnPropertyChanged("ClientName");
			}
		}
		public string PaspSeries
		{
			get { return paspseries; }
			set
			{
				paspseries = value;
				OnPropertyChanged("PaspSeries");
			}
		}
		public string PaspNum
		{
			get { return paspnum; }
			set
			{
				paspnum = value;
				OnPropertyChanged("PaspNum");
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
