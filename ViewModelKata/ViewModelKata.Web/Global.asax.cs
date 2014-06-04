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
        protected void Application_Start()
        {
            var viewModel = new ViewModel();
            var messageHub = new MessageHub();

            viewModel.ShowMessage += messageHub.ShowMessage;
            viewModel.PropertyChanged += messageHub.PropertyHasChanged;
            MessageHub.StaticClickButton += viewModel.OnShowMessage;
            MessageHub.StaticClickButtonChangeProperty += () => viewModel.RandomString = Path.GetRandomFileName();
 
            
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
