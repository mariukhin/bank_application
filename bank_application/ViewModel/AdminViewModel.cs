﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows;
using bank_application.Command;
using bank_application.Command.VisitorPattern;

namespace bank_application.ViewModel
{
	public class AdminViewModel : INotifyPropertyChanged
	{
		private Admin admin;
		private Request request;
		private Request selectedRequest;
		private string password;
		private string login;
		private string adminname;
		private ObservableCollection<Request> requests;


		public AdminViewModel(string Login,string Password)
		{
			this.Login = Login;
			this.Password = Password;
		}
		private RelayCommand showInfoCommand;
		public RelayCommand ShowInfoCommand
		{
			get
			{
				return showInfoCommand ??
					(showInfoCommand = new RelayCommand(obj =>
					{
						var structure = new BankStructure();
						structure.Add(Admin);
						structure.Accept(new InfoVisitor());
					}));
			}
		}
		private RelayCommand rejectrequestCommand;
		public RelayCommand RejectRequestCommand
		{
			get
			{
				return rejectrequestCommand ??
					(rejectrequestCommand = new RelayCommand(obj =>
					{
						Admin.DeleteSelectedItem(SelectedRequest.Description, SelectedRequest.SmthId, SelectedRequest.Id);
						Requests.Remove(SelectedRequest);
					}));
			}
		}
		private RelayCommand confirmrequestCommand;
		public RelayCommand ConfirmRequestCommand
		{
			get
			{
				return confirmrequestCommand ??
					(confirmrequestCommand = new RelayCommand(obj =>
					{
						Admin.ParseDescription(SelectedRequest.Description, SelectedRequest.SmthId, SelectedRequest.Id);
						Requests.Remove(SelectedRequest);
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
							Admin = new Admin(0, "user", "user", "23.02.1003", "VV", 2349959, "dfddd", "dd@kkd.xc", "243320030", Password);
							if (Admin.Authentificate(Admin) != null)
							{
								Admin = Admin.Authentificate(Admin);
								SetRequests(Admin.CreateRequests(Admin.Id));
								AdminName = "Admin: "+ Admin.Firstname + ' ' + Admin.Surname;
								AdminWindow adminWindow = new AdminWindow(this);
								adminWindow.Show();
								Application.Current.Windows[0].Close();
							}
							else
							{
								MessageBox.Show("Your password is invalid! Please try again");
							}
						}
						else
						{
							MessageBox.Show("Put your data!");
						}
					}));
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
		public string AdminName
		{
			get { return adminname; }
			set
			{
				adminname = value;
				OnPropertyChanged("AdminName");
			}
		}
		Admin Admin
		{
			get { return admin; }
			set
			{
				admin = value;
				OnPropertyChanged("Admin");
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
		public Request SelectedRequest
		{
			get { return selectedRequest; }
			set
			{
				selectedRequest = value;
				OnPropertyChanged("SelectedRequest");
			}
		}

		public ObservableCollection<Request> Requests => requests;
		public void SetRequests(ObservableCollection<Request> value)
		{
			requests = value;
			OnPropertyChanged("Requests");
		}
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
	}
}
