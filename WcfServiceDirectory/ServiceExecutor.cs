﻿using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Net;
using System.Text;

namespace WcfServiceDirectory
{
    public interface IServiceExecutor
    {
        void Get<TResponse>(string uriTemplate, Action<CallCompleteEventArgs<TResponse>> callback);
        void Put<TResponse>(string uriTemplate, string request, Action<CallCompleteEventArgs<TResponse>> callback);
    }

    public class ServiceExecutor : IServiceExecutor
    {
        ServiceEnvironment serviceEnvironment = new ServiceEnvironment() { UseHttpS = false, BaseAddress = "localhost", Port = 52802 };

        public void Get<TResponse>(string uriTemplate, Action<CallCompleteEventArgs<TResponse>> callback)
        {
            var client = new WebClient();
            var address = GetUri(uriTemplate);
            client.DownloadStringCompleted += (sender, eventArgs) => 
                {
                    if (callback == null) return;
                    var response = JsonConvert.DeserializeObject<TResponse>(eventArgs.Result);
                    callback(new CallCompleteEventArgs<TResponse>(response, eventArgs)); 
                };
            client.DownloadStringAsync(address);
        }

        public void Put<TResponse>(string uriTemplate, string request, Action<CallCompleteEventArgs<TResponse>> callback)
        {
            var client = new WebClient();
            var address = GetUri(uriTemplate);
			client.UploadStringCompleted += (sender, eventArgs) => 
                {
                    if (callback == null) return;
                    var response = JsonConvert.DeserializeObject<TResponse>(eventArgs.Result);
                    callback(new CallCompleteEventArgs<TResponse>(response, eventArgs)); 
                };
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.UploadStringAsync(address, "PUT", request);
        }

        private Uri GetUri(string uriTemplate)
        {
            var uriString = string.Format("http{0}://{1}:{2}/Facades{3}", 
                                        serviceEnvironment.UseHttpS ? "s" : "",
                                        serviceEnvironment.BaseAddress,
                                        serviceEnvironment.Port,
                                        uriTemplate);
            return new Uri(uriString);
        }
    }
}
