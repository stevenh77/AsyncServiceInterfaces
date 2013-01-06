
using DTOs;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Interfaces
{
    [ServiceContract]
    public interface ILoginFacade
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "GET", UriTemplate = "/Login")]
        GetLoginResponse GetLogin(GetLoginRequest request);

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "PUT", UriTemplate = "/Login")]
        UpdateLoginResponse UpdateLogin();

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "GET", UriTemplate = "/Login")]
        void WriteToLog();
    }
}