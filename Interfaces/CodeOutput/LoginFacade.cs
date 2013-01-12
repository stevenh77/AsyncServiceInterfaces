    
/***************************************************************************************
**** GENERATED CODE:  Use t4toolbox & tangiblet4editor to update AsyncInterfaces.tt ****
****************************************************************************************/
using System;
using Newtonsoft.Json;

namespace WcfServiceDirectory
{
	public class LoginFacade
	{
		private IServiceExecutor serviceExecutor;
			
		public LoginFacade()  { this.serviceExecutor = new ServiceExecutor(); }

		public void GetLogin(Action<CallCompleteEventArgs<DTOs.GetLoginResponse>> callback)
		{
			serviceExecutor.Get<DTOs.GetLoginResponse>("/Login",  callback);
		}

		public void UpdateLogin(DTOs.UpdateLoginRequest request, Action<CallCompleteEventArgs<DTOs.UpdateLoginResponse>> callback)
		{
			serviceExecutor.Put<DTOs.UpdateLoginResponse>("/Login", JsonConvert.SerializeObject(request), callback);
		}

		public void WriteToLog(Action<CallCompleteEventArgs<Object>> callback)
		{
			serviceExecutor.Get<Object>("/Login/WriteToLog",  callback);
		}

	}
}	
