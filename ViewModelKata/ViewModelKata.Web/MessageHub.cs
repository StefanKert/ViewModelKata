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

        public MessageHub()
        {
            this.ClickButton += () => StaticClickButton();
            this.ClickButtonChangeProperty += () => StaticClickButtonChangeProperty();
        }
        public void Show()
        {
        }

        public event Action ClickButton;
        public event Action ClickButtonChangeProperty;

        public static event Action StaticClickButton;
        public static event Action StaticClickButtonChangeProperty;

        public void ClickButtonInvoker()
        {
            ClickButton.Invoke();
        }
        public void ClickButtonChangePropertyInvoker()
        {
            ClickButtonChangeProperty.Invoke();
        }

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