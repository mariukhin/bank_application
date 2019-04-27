using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
