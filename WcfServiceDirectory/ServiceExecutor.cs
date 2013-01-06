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
        void Get(Type responseType, string uriTemplate);
        void Post(Type responseType, string uriTemplate);
    }

    public class ServiceExecutor : IServiceExecutor
    {
        ServiceEnvironment serviceEnvironment = new ServiceEnvironment() 
            { 
                UseHttpS = false, BaseAddress = "localhost", Port = 52802 
            };

        public void Get(Type responseType, string uriTemplate)
        {
            var client = new WebClient();
            var address = GetUri(uriTemplate);
			client.DownloadStringCompleted += (sender, eventArgs) => GetCompletedDelegate(responseType);
            client.DownloadStringAsync(address);
        }

        public void Post(Type responseType, string uriTemplate)
        {
            var client = new WebClient();
            var address = GetUri(uriTemplate);
			client.UploadStringCompleted += (sender, eventArgs) => GetCompletedDelegate(responseType);
            client.UploadStringAsync(address, "");
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

        private Action GetCompletedDelegate(Type responseType)
        {
            return new Action(() => System.Diagnostics.Debug.WriteLine("callback fired"));

            //var response = JsonConvert.DeserializeObject<typeof(responseType)>(eventArgs.Result);
            //callback(new CallCompleteEventArgs<typeof(responseType)>(response, eventArgs));   
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
