   
/***********************
**** GENERATED CODE ****
************************/
using System;
using Newtonsoft.Json;

namespace WcfServiceDirectory
{
	public partial class Services
    {
		public Services()
		{ 
			this.LoginFacade = new LoginFacade(); 
			this.TradeFacade = new TradeFacade(); 
		}

		public LoginFacade LoginFacade { get; set; }
		public TradeFacade TradeFacade { get; set; }
	}
    
	public class LoginFacade
	{
		private IServiceExecutor serviceExecutor;
			
		public LoginFacade()  { this.serviceExecutor = new ServiceExecutor(); }

		public void GetLogin(Action<CallCompleteEventArgs<DTOs.GetLoginResponse>> callback)
		{
			serviceExecutor.Get<DTOs.GetLoginResponse>("/Login", callback);
		}

		public void UpdateLogin(DTOs.UpdateLoginRequest request, Action<CallCompleteEventArgs<DTOs.UpdateLoginResponse>> callback)
		{
			var jsonRequest = JsonConvert.SerializeObject(request);
			serviceExecutor.Post<DTOs.UpdateLoginResponse>("/Login", jsonRequest, callback);
		}

		public void WriteToLog()
		{
			serviceExecutor.Get<Object>("/Login/WriteToLog", null);
		}

	}	
	
    
	public class TradeFacade
	{
		private IServiceExecutor serviceExecutor;
			
		public TradeFacade()  { this.serviceExecutor = new ServiceExecutor(); }

		public void UpdateTradesDatabase(System.String userId, Action<CallCompleteEventArgs<System.Int32>> callback)
		{
			var jsonRequest = JsonConvert.SerializeObject(userId);
			serviceExecutor.Post<System.Int32>("/Trades", jsonRequest, callback);
		}

	}	
	
}