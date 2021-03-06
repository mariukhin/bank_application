﻿using System.Windows;
using bank_application.ViewModel;
using bank_application.Command;


namespace bank_application
{
	/// <summary>
	/// Логика взаимодействия для Login.xaml
	/// </summary>
	public partial class Login : Window
	{
		ClientViewModel uvm;
		AdminViewModel avm;
		AdminDeterminant ad;

		public Login()
		{
			InitializeComponent();
			ad = new AdminDeterminant();
		}
		private void BtnReg_Click(object sender, RoutedEventArgs e)
		{
			Registration registration = new Registration();
			registration.Show();
		}
		private void BtnClose_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void PbPassword_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
		{
			if (ad.CheckAdmin(pbPassword.Text))
			{
				avm = new AdminViewModel(tbLogin.Text,pbPassword.Text);
				DataContext = avm;
			}
			else
			{
				uvm = new ClientViewModel(tbLogin.Text, pbPassword.Text);
				DataContext = uvm;
			}
		}

	}
}
