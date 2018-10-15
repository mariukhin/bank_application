using System;
using System.Collections.Generic;

namespace bank_application
{
	public class Base<T> : Object where T : Base<T>
	{
		public static Dictionary<Guid, T> data = new Dictionary<Guid, T>();
		public Guid ID;
		public string Name;

		public Base(string Name)
		{
			this.Name = Name;
			ID = Guid.NewGuid();
		}
		public override string ToString()
		{
			return Name;
		}
	}
}
