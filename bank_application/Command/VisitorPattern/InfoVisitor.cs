﻿using System.Windows;

namespace bank_application.Command.VisitorPattern
{
	class InfoVisitor : IVisitor
	{
		public void VisitAdminAc(Admin acc)
		{
			MessageBox.Show(acc.ToString());
		}

		public void VisitClientAcc(Client acc)
		{
			MessageBox.Show(acc.ToString());
		}
	}
}
