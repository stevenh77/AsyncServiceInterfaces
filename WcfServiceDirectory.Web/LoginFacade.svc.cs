using DTOs;
using Interfaces;
using System.Diagnostics;

namespace WcfServiceDirectory.Web
{
    public class LoginFacade : ILoginFacade
    {
        public GetLoginResponse GetLogin(string request)
        {
            return new GetLoginResponse() { Payload = "Welcome " + request}; 
        }

        public UpdateLoginResponse UpdateLogin(UpdateLoginRequest request)
        {
            return new UpdateLoginResponse() { Payload = "Updated" + request.Payload }; 
        }

        public void WriteToLog()
        {
            Debug.WriteLine("Writing to log...");
        }
    }
}
