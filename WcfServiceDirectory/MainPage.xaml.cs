using DTOs;
namespace WcfServiceDirectory
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            var services = new Services();
            var request = new GetLoginRequest();
            services.ILoginFacade.GetLogin(request, this.OnGetLoginComplete);
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
