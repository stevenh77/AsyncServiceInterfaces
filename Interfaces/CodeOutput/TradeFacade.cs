    
/***************************************************************************************
**** GENERATED CODE:  Use t4toolbox & tangiblet4editor to update AsyncInterfaces.tt ****
****************************************************************************************/
using System;
using Newtonsoft.Json;

namespace WcfServiceDirectory
{
	public class TradeFacade
	{
		private IServiceExecutor serviceExecutor;
			
		public TradeFacade()  { this.serviceExecutor = new ServiceExecutor(); }

		public void UpdateTradesDatabase(System.String userId, Action<CallCompleteEventArgs<System.Int32>> callback)
		{
			serviceExecutor.Put<System.Int32>("/Trades", JsonConvert.SerializeObject(userId), callback);
		}

	}
}	
