namespace bank_application.Command.DecoratorPattern
{
	abstract class ComponentCardType
	{
		public ComponentCardType(string name, int minamount)
		{
			this.Name = name;
			this.MinAmount = minamount;
		}
		public string Name { get; protected set; }
		public int MinAmount { get; protected set; }
		public abstract string GetInfo();
	}
}
