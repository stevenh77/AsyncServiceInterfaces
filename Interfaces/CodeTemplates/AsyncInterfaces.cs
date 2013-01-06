   
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
			
		public LoginFacade() 
		{
			this.serviceExecutor = new ServiceExecutor();
		}
        
		public LoginFacade(IServiceExecutor serviceExecutor) 
		{ 
			this.serviceExecutor = serviceExecutor; 
		}

		public void GetLogin(Action<CallCompleteEventArgs<DTOs.GetLoginResponse>> callback)
		{
			serviceExecutor.Get("/Login", typeof(DTOs.GetLoginResponse)); 
		}

		public void UpdateLogin(DTOs.UpdateLoginRequest request, Action<CallCompleteEventArgs<DTOs.UpdateLoginResponse>> callback)
		{
			var jsonRequest = JsonConvert.SerializeObject(request);
			serviceExecutor.Post("/Login", jsonRequest, typeof(DTOs.UpdateLoginResponse)); 
		}

		public void WriteToLog()
		{
			serviceExecutor.Get("/Login/WriteToLog", typeof(void)); 
		}

	}	
	
    
	public class TradeFacade
	{
		private IServiceExecutor serviceExecutor;
			
		public TradeFacade() 
		{
			this.serviceExecutor = new ServiceExecutor();
		}
        
		public TradeFacade(IServiceExecutor serviceExecutor) 
		{ 
			this.serviceExecutor = serviceExecutor; 
		}

		public void UpdateTradesDatabase(System.String userId, Action<CallCompleteEventArgs<System.Int32>> callback)
		{
			var jsonRequest = JsonConvert.SerializeObject(userId);
			serviceExecutor.Post("/Trades", jsonRequest, typeof(System.Int32)); 
		}

	}	
	
}