using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using ViewModelKata.Contracts;

namespace ViewModelKata.Web
{
    public class MessageHub : Hub, IUI
    {
        public bool IsStaticClass = false;

        public void Show()
        {
        }

        public void ClickButtonInvoker()
        {
            if (!this.IsStaticClass)
                WebApiApplication.MessageHub.ClickButtonInvoker();
            else
                ClickButton.Invoke();
        }

        public void ClickButtonChangePropertyInvoker()
        {
            if (!this.IsStaticClass)
                WebApiApplication.MessageHub.ClickButtonChangeProperty();
            else
                ClickButtonChangeProperty.Invoke();
        }

        public event Action ClickButton;
        public event Action ClickButtonChangeProperty;

        public void PropertyHasChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<MessageHub>();
            context.Clients.All.broadcastMessage("Property " + sender.ToString() + " has Changed");
        }
        public void ShowMessage(String message)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<MessageHub>();
            context.Clients.All.broadcastMessage(message);
            //this.Clients.All.broadcastMessage(message);
        }
    }
}