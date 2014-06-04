using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ViewModelKata.Contracts;
using ViewModelKata.Domain;

namespace ViewModelKata.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static MessageHub MessageHub = new MessageHub();
        public static ViewModel ViewModel = new ViewModel();

        protected void Application_Start()
        {
            MessageHub.IsStaticClass = true;
            ViewModel.ShowMessage += MessageHub.ShowMessage;
            ViewModel.PropertyChanged += MessageHub.PropertyHasChanged;
            MessageHub.ClickButton += ViewModel.OnShowMessage;
            MessageHub.ClickButtonChangeProperty += () => ViewModel.RandomString = Path.GetRandomFileName();
 
            
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
