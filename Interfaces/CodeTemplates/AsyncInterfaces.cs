   
/***********************
**** GENERATED CODE ****
************************/
using System;

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

		public void GetLogin(System.String request, Action<CallCompleteEventArgs<DTOs.GetLoginResponse>> callback)
        {
			serviceExecutor.Get(typeof(DTOs.GetLoginResponse), "/Login/{request}");
        } 

		public void UpdateLogin(DTOs.UpdateLoginRequest request, Action<CallCompleteEventArgs<DTOs.UpdateLoginResponse>> callback)
        {
			serviceExecutor.Post(typeof(DTOs.UpdateLoginResponse), "/Login");
        } 

		public void WriteToLog()
        {
			serviceExecutor.Get(typeof(void), "/Login/WriteToLog");
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
			serviceExecutor.Post(typeof(System.Int32), "/Trades");
        } 

	}
}