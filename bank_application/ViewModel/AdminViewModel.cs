using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using bank_application.Command;

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
		private RelayCommand rejectrequestCommand;
		public RelayCommand RejectRequestCommand
		{
			get
			{
				return rejectrequestCommand ??
					(rejectrequestCommand = new RelayCommand(obj =>
					{
						try
						{
							Admin.DeleteSelectedItem(SelectedRequest.Description, SelectedRequest.SmthId, SelectedRequest.Id);
						}
						catch (Exception ex)
						{ }
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
						try
						{
							Admin.ParseDescription(SelectedRequest.Description, SelectedRequest.SmthId, SelectedRequest.Id);
						}
						catch(Exception ex)
						{}
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
							if (Admin.AuthAdmin(Admin) != null)
							{
								Admin = Admin.AuthAdmin(Admin);
								Requests = Admin.CreateRequests(Admin.Id);
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
		public Admin Admin
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
		public ObservableCollection<Request> Requests
		{
			get { return requests; }
			set
			{
				requests = value;
				OnPropertyChanged("Requests");
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
