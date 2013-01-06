using DTOs;
namespace WcfServiceDirectory
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            var services = new Services();

            services.LoginFacade.WriteToLog();

            var request = new GetLoginRequest();
            services.LoginFacade.GetLogin(request, this.OnGetLoginComplete);
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
    }
}
