   
using DTOs;
using Newtonsoft.Json;
using System;
using System.Net;

namespace WcfServiceDirectory
{
	public class Services
    {
		public LoginFacade LoginFacade { get; set; }
		public TradeFacade TradeFacade { get; set; }
	}
    
	public class LoginFacade
	{
		public void GetLogin(GetLoginRequest request, Action<CallCompleteEventArgs<GetLoginResponse>> callback)
        {
            var client = new WebClient();
            var address = new Uri(string.Concat("http://server", "/Login"));
			
            client.DownloadStringCompleted += (sender, eventArgs) =>
            {
                var response = JsonConvert.DeserializeObject<GetLoginResponse>(eventArgs.Result);
                callback(new CallCompleteEventArgs<GetLoginResponse>(response, eventArgs));
            };
            
            client.DownloadStringAsync(address);
        }

		public void UpdateLogin(Action<CallCompleteEventArgs<UpdateLoginResponse>> callback)
        {
            var client = new WebClient();
            var address = new Uri(string.Concat("http://server", "/Login"));
			
            client.UploadStringCompleted += (sender, eventArgs) =>
            {
                var response = JsonConvert.DeserializeObject<UpdateLoginResponse>(eventArgs.Result);
                callback(new CallCompleteEventArgs<UpdateLoginResponse>(response, eventArgs));
            };
            
            client.UploadStringAsync(address);
        }

		public void WriteToLog()
        {
            var client = new WebClient();
            var address = new Uri(string.Concat("http://server", "/Login"));
			
            client.DownloadStringAsync(address);
        }

	}
    
	public class TradeFacade
	{
		public void UpdateTradesDatabase(String userId, Action<CallCompleteEventArgs<Int32>> callback)
        {
            var client = new WebClient();
            var address = new Uri(string.Concat("http://server", "/Trades"));
			
            client.UploadStringCompleted += (sender, eventArgs) =>
            {
                var response = JsonConvert.DeserializeObject<Int32>(eventArgs.Result);
                callback(new CallCompleteEventArgs<Int32>(response, eventArgs));
            };
            
            client.UploadStringAsync(address);
        }

	}
}