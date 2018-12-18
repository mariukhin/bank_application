using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ServiceHost
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var host = new ServiceHost(typeof(WcfServiceApp.CountService)))
			{
				host.Open();
				Console.WriteLine("Host started ...");
				Console.ReadKey();
			}
		}
	}
}
