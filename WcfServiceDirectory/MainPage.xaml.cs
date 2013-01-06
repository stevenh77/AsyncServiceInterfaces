using DTOs;
using System;

namespace WcfServiceDirectory
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            try
            {
                var services = new Services();

                // First service call
                services.LoginFacade.GetLogin(this.OnGetLoginComplete);

                // Second service
                var request = new UpdateLoginRequest() { Payload = "Steve (calling UpdateLogin)" };
                services.LoginFacade.UpdateLogin(request, this.OnUpdateLoginComplete);

                // Third service
                services.LoginFacade.WriteToLog(null);
            }
            catch (Exception e)
            {
                this.ErrorTextBlock.Text = Environment.NewLine + "Exception: " + e.Message;
            }
        }

        private void OnGetLoginComplete(CallCompleteEventArgs<GetLoginResponse> e)
        {
            if (e.Error == null && e.Result != null)
            {
                //success
                this.GetLoginResponseTextBlock.Text = "GetLoginResponse received " + e.Result.Payload;
            }
            else
            {
                //failed
                this.ErrorTextBlock.Text = Environment.NewLine + "GetLogin exception: " + e.Error.Message;
            }
        }

        private void OnUpdateLoginComplete(CallCompleteEventArgs<UpdateLoginResponse> e)
        {
            if (e.Error == null && e.Result != null)
            {
                //success
                this.UpdateLoginResponseTextBlock.Text = "UpdateLoginResponse received " + e.Result.Payload;
            }
            else
            {
                //failed
                this.ErrorTextBlock.Text += Environment.NewLine + "UpdateLogin exception: " + e.Error.Message;
            }
        }
    }
}
