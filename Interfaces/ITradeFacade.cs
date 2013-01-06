using DTOs;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Interfaces
{
    [ServiceContract]
    public interface ITradeFacade
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "PUT", UriTemplate = "/Trades")]
        int UpdateTradesDatabase(string userId);
    }
}
