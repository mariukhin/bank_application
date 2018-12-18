using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BankHost
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var host = new ServiceHost(typeof(WcfServiceApp.CountService)))
			{
				host.Open();
				Console.WriteLine("Server is active");
				Console.ReadKey();
			}
		}
	}
}
