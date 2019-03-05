using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using bank_application.UI;
using System.Windows;
using bank_application.Command;
using System.Globalization;

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
		private DateTime datecredit;

		/// <summary>
		/// Deposit
		/// </summary>
		private Deposit deposit;
		private Deposit selDeposit;
		private string durationDep;
		private string numberDep;
		private Card cardnumberdep;
		private string typeDep;
		private bool isconfirmdep;
		private bool checkedftype;
		private bool checkedstype;
		private DateTime datedeposit;

		/// <summary>
		/// Card
		/// </summary>
		private Card card;
		private Card selCard;
		private Card topupmobilecard;
		private string cardnumber;
		private string cardname;
		private string pin;
		private int cvcode;
		private string term;
		private int money;
		private bool isconfirmcard;
		private bool firstalg;
		private bool secondalg;

		/// <summary>
		/// Transaction
		/// </summary>
		private Transaction transaction;
		private string transfercardgive;
		private Card transfercardsend;
		private string transfermoney;


		/// <summary>
		/// Cashback
		/// </summary>
		private Card transfercashbackcard;

		/// <summary>
		/// MoneyBox
		/// </summary>
		private Card transfermoneyboxcard;

		/// <summary>
		/// PersonalData
		/// </summary>
		private string ChangeDataType;
		private string changedata;

		public ClientViewModel() { }
		public ClientViewModel(string Login, string Password)
		{
			this.Login = Login;
			this.Password = Password;
		}

		private RelayCommand transferMoneyBoxCommand;
		public RelayCommand TransferMoneyBoxCommand
		{
			get
			{
				return transferMoneyBoxCommand ??
					(transferMoneyBoxCommand = new RelayCommand(obj =>
					{
						if (Checked == true)
						{
							if (TransferMoneyBoxCard != null)
							{
								int newMoney = TransferMoneyBoxCard.Money + (int)Client.Moneybox;
								TransferMoneyBoxCard.UpdateCardMoney(TransferMoneyBoxCard, newMoney);
								Client.UpdateMoneyBox(Client, 0.0);
								Cards.Clear();
								MoneyBox = 0;
								SetCards(Client.CreateCards(Client.Id));
								Application.Current.Windows[2].Close();
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
		private RelayCommand openTransferMoneyBoxCommand;
		public RelayCommand OpenTransferMoneyBoxCommand
		{
			get
			{
				return openTransferMoneyBoxCommand ??
					(openTransferMoneyBoxCommand = new RelayCommand(obj =>
					{
						TransferMoneyBox transferMoneyBox = new TransferMoneyBox(this);
						transferMoneyBox.Show();
					}));
			}
		}


		private RelayCommand changeDataCommand;
		public RelayCommand ChangeDataCommand
		{
			get
			{
				return changeDataCommand ??
					(changeDataCommand = new RelayCommand(obj =>
					{
						if (ChangeData != null)
						{
							Client.UpdateInfo(ChangeDataType, ChangeData, Client);
							if (ChangeDataType.Equals("e-mail", StringComparison.Ordinal) || ChangeDataType.Equals("phone", StringComparison.Ordinal))
							{
								Client.UpdateLogin(ChangeData, Client);
							}
							Application.Current.Windows[2].Close();
						}
						else
						{
							MessageBox.Show("Full all fields!");
						}
					}));
			}
		}

		private RelayCommand openChangeDataCommand;
		public RelayCommand OpenChangeDataCommand
		{
			get
			{
				return openChangeDataCommand ??
					(openChangeDataCommand = new RelayCommand(obj =>
					{
						ChangeData changeData = new ChangeData(this);
						changeData.Show();
						ChangeDataType = obj.ToString();
					}));
			}
		}
		private RelayCommand removeCardCommand;
		public RelayCommand RemoveCardCommand
		{
			get
			{
				return removeCardCommand ??
					(removeCardCommand = new RelayCommand(obj =>
					{
						if (SelectedCard.Money == 0)
						{
							Client.DeleteSelectedItem(SelectedCard.Id, "card");
							Cards.Remove(SelectedCard);
						}
						else
						{
							MessageBox.Show("You have money on this card!");
						}
					}));
			}
		}
		private RelayCommand cancelDepositCommand;
		public RelayCommand CancelDepositCommand
		{
			get
			{
				return cancelDepositCommand ??
					(cancelDepositCommand = new RelayCommand(obj =>
					{
						
						if (SelectedDeposit.Type.Equals("Without early interruption", StringComparison.Ordinal))
						{
							Client.DeleteSelectedItem(SelectedDeposit.Id, "deposit");
							Deposits.Remove(SelectedDeposit);
						}
						else
						{
							MessageBox.Show("Your deposit type isn't good");
						}
					}));
			}
		}

		private RelayCommand transferCashbackCommand;
		public RelayCommand TransferCashbackCommand
		{
			get
			{
				return transferCashbackCommand ??
					(transferCashbackCommand = new RelayCommand(obj =>
					{
						if (Checked == true)
						{
							if (TransferCashbackCard != null)
							{
								int newMoney = TransferCashbackCard.Money + (int)Client.Cashback;
								TransferCashbackCard.UpdateCardMoney(TransferCashbackCard, newMoney);
								Client.UpdateCashback(Client, 0.0);
								Cards.Clear();
								Cashback = 0;
								SetCards(Client.CreateCards(Client.Id));
								Application.Current.Windows[2].Close();		
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
		private RelayCommand openTransferCashCommand;
		public RelayCommand OpenTransferCashCommand
		{
			get
			{
				return openTransferCashCommand ??
					(openTransferCashCommand = new RelayCommand(obj =>
					{
						TransferCashback transferCash = new TransferCashback(this);
						transferCash.Show();
					}));
			}
		}
		private RelayCommand topUpMobileCommand;
		public RelayCommand TopUpMobileCommand
		{
			get
			{
				return topUpMobileCommand ??
					(topUpMobileCommand = new RelayCommand(obj =>
					{
						if (Checked == true)
						{
							if (TopUpMobileCard != null && TransferMoney != null)
							{
								int trmoney = Convert.ToInt32(TransferMoney, CultureInfo.InvariantCulture);
								Transaction Transaction = new Transaction(1, TransferCardSend.CardNumber, null, trmoney);
								if (Transaction.CheckPayingCapacity(trmoney, TransferCardSend.Money))
								{
									Transaction.TopUpMobile(TransferCardSend, trmoney);
									Cards.Clear();
									SetCards(Client.CreateCards(Client.Id));
									Application.Current.Windows[2].Close();
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
		private RelayCommand openTopUpMobileCommand;
		public RelayCommand OpenTopUpMobileCommand
		{
			get
			{
				return openTopUpMobileCommand ??
					(openTopUpMobileCommand = new RelayCommand(obj =>
					{
						TopUpMobile transferMoney = new TopUpMobile(this);
						transferMoney.Show();
					}));
			}
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
								int trmoney = Convert.ToInt32(TransferMoney, CultureInfo.InvariantCulture);
								Transaction = new Transaction(1, TransferCardSend.CardNumber, TransferCardGive, trmoney);
								if (Transaction.CheckPayingCapacity(trmoney, TransferCardSend.Money))
								{
									if (Transaction.CheckGiveCard(TransferCardGive) != null)
									{
										Transaction.CheckTransaction(TransferCardSend, TransferCardGive, trmoney);
										Cards.Clear();
										SetCards(Client.CreateCards(Client.Id));
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
		private RelayCommand openTransferCommand;
		public RelayCommand OpenTransferCommand
		{
			get
			{
				return openTransferCommand ??
					(openTransferCommand = new RelayCommand(obj =>
					{
						TransferMoney  transferMoney = new TransferMoney(this);
						transferMoney.Show();
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
								int pin = Convert.ToInt32(PIN,CultureInfo.InvariantCulture);
								int numberOfAlgorythm;
								if (FirstAlg)
								{
									numberOfAlgorythm = 1;
								}
								else
								{
									numberOfAlgorythm = 2;
								}

								Card = new Card(1, "3433243432325444", CardName, pin, 544, "03.11.2023",0, Client.Id, IsConfirmCard);
								if (Card.GetCurrentCard(Card) == null)
								{
									Card.AddNewCard(Card, numberOfAlgorythm);
									Card = Card.GetCurrentCard(Card);
									Random rand = new Random();
									Request = new Request(1, Client.Id, rand.Next(1, 5), Card.Id, DateTime.Now, "Add new card");
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
		private RelayCommand openAddCardCommand;
		public RelayCommand OpenAddCardCommand
		{
			get
			{
				return openAddCardCommand ??
					(openAddCardCommand = new RelayCommand(obj =>
					{
						AddCard addCard = new AddCard(this);
						addCard.Show();
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
								int number = Convert.ToInt32(NumberDep, CultureInfo.InvariantCulture);
								int dur = Convert.ToInt32(DurationDep, CultureInfo.InvariantCulture);
								Deposit = new Deposit(1, dur, number,CardNumberDep.CardNumber,TypeDep, Client.Id, IsConfirmDep, DateTime.Today);
								if (Deposit.GetCurrentDeposit(Deposit) == null)
								{
									if (Deposit.AddNewDeposit(Deposit, CardNumberDep))
									{
										Deposit = Deposit.GetCurrentDeposit(Deposit);
										Random rand = new Random();
										Request = new Request(1, Client.Id, rand.Next(1,5), Deposit.Id, DateTime.Now, "Add new deposit");
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

		private RelayCommand openAddDepositCommand;
		public RelayCommand OpenAddDepositCommand
		{
			get
			{
				return openAddDepositCommand ??
					(openAddDepositCommand = new RelayCommand(obj =>
					{
						AddDeposit addDeposit = new AddDeposit(this);
						addDeposit.Show();
					}));
			}
		}

		private RelayCommand openPayDebtCommand;
		public RelayCommand OpenPayDebtCommand
		{
			get
			{
				return openPayDebtCommand ??
					(openPayDebtCommand = new RelayCommand(obj =>
					{
						//--------------
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
								int number = Convert.ToInt32(NumberCr, CultureInfo.InvariantCulture);
								int dur = Convert.ToInt32(DurationCr, CultureInfo.InvariantCulture);
								Credit = new Credit(1, dur, number, CardNumberCr.CardNumber , Client.Id, IsConfirmCr, DateTime.Today);
								if (Credit.GetCurrentCredit(Credit) == null)
								{
									Credit.AddNewCredit(Credit, CardNumberCr);
									Credit = Credit.GetCurrentCredit(Credit);
									Random rand = new Random();
									Request = new Request(1, Client.Id, rand.Next(1, 5), Credit.Id, DateTime.Now, "Add new credit");
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
		private RelayCommand openAddCreditCommand;
		public RelayCommand OpenAddCreditCommand
		{
			get
			{
				return openAddCreditCommand ??
					(openAddCreditCommand = new RelayCommand(obj =>
					{
						AddCredit addCredit = new AddCredit(this);
						addCredit.Show();
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
							int paspNum = Convert.ToInt32(PaspNum, CultureInfo.InvariantCulture);
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
								SetCredits(Client.CreateCredits(Client.Id));
								SetDeposits(Client.CreateDeposits(Client.Id));
								SetCards(Client.CreateCards(Client.Id));
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
		public string ChangeData
		{
			get { return changedata; }
			set
			{
				changedata = value;
				OnPropertyChanged("ChangeData");
			}
		}

		public Card SelectedCard
		{
			get { return selCard; }
			set
			{
				selCard = value;
				OnPropertyChanged("SelectedCard");
			}
		}
		public Card TransferCashbackCard
		{
			get { return transfercashbackcard; }
			set
			{
				transfercashbackcard = value;
				OnPropertyChanged("TransferCashbackCard");
			}
		}
		public Card TransferMoneyBoxCard
		{
			get { return transfermoneyboxcard; }
			set
			{
				transfermoneyboxcard = value;
				OnPropertyChanged("TransferMoneyBoxCard");
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

		public ObservableCollection<Card> Cards => cards;
		public void SetCards(ObservableCollection<Card> value)
		{
			cards = value;
			OnPropertyChanged("Cards");
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
		public Card TopUpMobileCard
		{
			get { return topupmobilecard; }
			set
			{
				topupmobilecard = value;
				OnPropertyChanged("TopUpMobileCard");
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
		public bool FirstAlg
		{
			get { return firstalg; }
			set
			{
				firstalg = value;
				OnPropertyChanged("FirstAlg");
			}
		}
		public bool SecondAlg
		{
			get { return secondalg; }
			set
			{
				secondalg = value;
				OnPropertyChanged("SecondAlg");
			}
		}


		public Deposit SelectedDeposit
		{
			get { return selDeposit; }
			set
			{
				selDeposit = value;
				OnPropertyChanged("SelectedDeposit");
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

		public ObservableCollection<Deposit> Deposits => deposits;
		public void SetDeposits(ObservableCollection<Deposit> value)
		{
			deposits = value;
			OnPropertyChanged("Deposits");
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
		public DateTime DateDeposit
		{
			get { return datedeposit; }
			set
			{
				datedeposit = value;
				OnPropertyChanged("DateDeposit");
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
		public DateTime DateCredit
		{
			get { return datecredit; }
			set
			{
				datecredit = value;
				OnPropertyChanged("DateCredit");
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

		public ObservableCollection<Credit> Credits => credits;
		public void SetCredits(ObservableCollection<Credit> value)
		{
			credits = value;
			OnPropertyChanged("Credits");
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
			get
			{
				if (client != null)
				{
					return client.Firstname;
				}
				return firstname;
			}
			set
			{
				firstname = value;
				OnPropertyChanged("FirstName");
			}
		}
		public string SurName
		{
			get
			{
				if (client != null)
				{
					return client.Surname;
				}
				return surname;
			}
			set
			{
				surname = value;
				OnPropertyChanged("SurName");
			}
		}
		public string DateOfBirth
		{
			get
			{
				if (client != null)
				{
					return client.DateOfBirth;
				}
				return dateofbirth;
			}
			set
			{
				dateofbirth = value;
				OnPropertyChanged("DateOfBirth");
			}
		}
		public string Email
		{
			get
			{
				if (client != null)
				{
					return client.Email;
				}
				return email;
			}
			set
			{
				email = value;
				OnPropertyChanged("Email");
			}
		}
		public string Phonenumber
		{
			get
			{
				if (client != null)
				{
					return client.Phonenumber;
				}
				return phonenumber;
			}
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
			get
			{
				if (client != null)
				{
					return client.PassportSeries;
				}
				return paspseries;
			}
			set
			{
				paspseries = value;
				OnPropertyChanged("PaspSeries");
			}
		}
		public string PaspNum
		{
			get
			{
				if (client != null)
				{
					return client.PassportNum.ToString(CultureInfo.InvariantCulture);
				}
				return paspnum;
			}
			set
			{
				paspnum = value;
				OnPropertyChanged("PaspNum");
			}
		}
		public double Cashback
		{
			get { return Client.Cashback; }
			set
			{
				Client.Cashback = value;
				OnPropertyChanged("Cashback");
			}
		}
		public double MoneyBox
		{
			get { return Client.Moneybox; }
			set
			{
				Client.Moneybox = value;
				OnPropertyChanged("MoneyBox");
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
	}
}
