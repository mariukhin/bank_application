namespace bank_application.Command
{
	public interface IPrototype
	{
		IPrototype GetClone();
	}
}
