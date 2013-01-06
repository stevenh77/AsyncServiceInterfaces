   
/***********************
**** GENERATED CODE ****
************************/
using System;
using Newtonsoft.Json;

namespace WcfServiceDirectory
{
	public partial class Services
    {
		public Services()
		{ 
			this.LoginFacade = new LoginFacade(); 
			this.TradeFacade = new TradeFacade(); 
		}

		public LoginFacade LoginFacade { get; set; }
		public TradeFacade TradeFacade { get; set; }
	}
    
	public class LoginFacade
	{
		private IServiceExecutor serviceExecutor;
			
		public LoginFacade() 
		{
			this.serviceExecutor = new ServiceExecutor();
		}
        
		public LoginFacade(IServiceExecutor serviceExecutor) 
		{ 
			this.serviceExecutor = serviceExecutor; 
		}

        } 

        } 

        } 

	}
    
	public class TradeFacade
	{
		private IServiceExecutor serviceExecutor;
			
		public TradeFacade() 
		{
			this.serviceExecutor = new ServiceExecutor();
		}
        
		public TradeFacade(IServiceExecutor serviceExecutor) 
		{ 
			this.serviceExecutor = serviceExecutor; 
		}

        } 

	}
}