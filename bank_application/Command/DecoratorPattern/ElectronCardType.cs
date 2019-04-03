namespace bank_application.Command.DecoratorPattern
{
	class ElectronCardType : CardDecorator
	{
		public ElectronCardType(ComponentCardType comp) 
			: base(comp.Name + " Electron", 0, comp)
		{}

		public override string GetInfo()
		{
			return comp.GetInfo() + " Electron";
		}
	}
}
