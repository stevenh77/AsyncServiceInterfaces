using DTOs;
using Interfaces;
using System.Diagnostics;

namespace WcfServiceDirectory.Web
{
    public class LoginFacade : ILoginFacade
    {
        public GetLoginResponse GetLogin(GetLoginRequest request)
        {
            return new GetLoginResponse() { Payload = "Welcome " + request.Payload}; 
        }

        public UpdateLoginResponse UpdateLogin()
        {
            return new UpdateLoginResponse() { Payload = "Updated!" }; 
        }

        public void WriteToLog()
        {
            Debug.WriteLine("Writing to log...");
        }
    }
}
