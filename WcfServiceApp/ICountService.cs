using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceApp
{
	// ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "ICountService" в коде и файле конфигурации.
	[ServiceContract]
	public interface ICountService
	{
		[OperationContract]
		int CalcCredit(int Duration, int Money, DateTime date);

		[OperationContract]
		double CalcDeposit(int Duration, int Money, DateTime date);
	}
}
