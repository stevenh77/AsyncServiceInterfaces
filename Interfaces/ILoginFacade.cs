
using DTOs;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Interfaces
{
    [ServiceContract]
    public interface ILoginFacade
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "GET", UriTemplate = "/Login/{request}")]
        GetLoginResponse GetLogin(string request);

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "PUT", UriTemplate = "/Login")]
        UpdateLoginResponse UpdateLogin(UpdateLoginRequest request);

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "GET", UriTemplate = "/Login/WriteToLog")]
        void WriteToLog();
    }
}