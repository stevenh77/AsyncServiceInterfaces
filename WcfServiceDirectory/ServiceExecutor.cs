using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Net;

namespace WcfServiceDirectory
{
    public class ServiceEnvironment
    {
        public bool UseHttpS { get; set; }
        public string BaseAddress { get; set; }
        public int Port { get; set; }
    }

    public interface IServiceExecutor
    {
        void Get<TResponse>(string uriTemplate, Action<CallCompleteEventArgs<TResponse>> callback);
        void Post<TResponse>(string uriTemplate, string request, Action<CallCompleteEventArgs<TResponse>> callback);
    }

    public class ServiceExecutor : IServiceExecutor
    {
        ServiceEnvironment serviceEnvironment = new ServiceEnvironment() 
            { 
                UseHttpS = false, BaseAddress = "localhost", Port = 52802 
            };

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

        public void Post<TResponse>(string uriTemplate, string request, Action<CallCompleteEventArgs<TResponse>> callback)
        {
            var client = new WebClient();
            var address = GetUri(uriTemplate);
			client.UploadStringCompleted += (sender, eventArgs) => 
                {
                    if (callback == null) return;
                    var response = JsonConvert.DeserializeObject<TResponse>(eventArgs.Result);
                    callback(new CallCompleteEventArgs<TResponse>(response, eventArgs)); 
                };

            client.UploadStringAsync(address, request);
        }

        private Uri GetUri(string uriTemplate)
        {
            var uriString = string.Format("http{0}://{1}:{2}{3}",
                                        serviceEnvironment.UseHttpS ? "s" : "",
                                        serviceEnvironment.BaseAddress,
                                        serviceEnvironment.Port,
                                        uriTemplate);
            return new Uri(uriString);
        }
    }

    #region CallbackWrapper

    public class CallCompleteEventArgs<T> : AsyncCompletedEventArgs
    {
        public CallCompleteEventArgs(T result, AsyncCompletedEventArgs sourceEventArgs)
            : base(sourceEventArgs.Error, sourceEventArgs.Cancelled, sourceEventArgs.UserState)
        {
            Result = result;
        }

        public CallCompleteEventArgs(T result, Exception exception, bool cancelled, object userState)
            : base(exception, cancelled, userState)
        {
            Result = result;
        }

        public T Result { get; private set; }
    }

    #endregion
}
