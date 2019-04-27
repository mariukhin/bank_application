namespace bank_application.Command.VisitorPattern
{
	interface IVisitor
	{
		void VisitClientAcc(Client acc);
		void VisitAdminAc(Admin acc);
	}
}
