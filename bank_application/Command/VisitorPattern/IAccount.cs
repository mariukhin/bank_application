namespace bank_application.Command.VisitorPattern
{
	interface IAccount
	{
		void Accept(IVisitor visitor);
	}
}
