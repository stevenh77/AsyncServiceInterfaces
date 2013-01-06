using DTOs;
namespace WcfServiceDirectory
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            var services = new Services();

            // First service call
            services.LoginFacade.GetLogin(this.OnGetLoginComplete);

            // Second service
            var request = new UpdateLoginRequest() { Payload = "Steve (calling UpdateLogin)" };
            services.LoginFacade.UpdateLogin(request, this.OnUpdateLoginComplete);

            // Third service
            services.LoginFacade.WriteToLog(null);
        }

        private void OnGetLoginComplete(CallCompleteEventArgs<GetLoginResponse> e)
        {
            if (e.Error == null && e.Result != null)
            {
                //success

            }
            else
            {
                //failed
            }
        }

        private void OnUpdateLoginComplete(CallCompleteEventArgs<UpdateLoginResponse> e)
        {
            if (e.Error == null && e.Result != null)
            {
                //success

            }
            else
            {
                //failed
            }
        }
    }
}
