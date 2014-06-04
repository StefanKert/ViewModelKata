using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModelKata.Contracts;

namespace ViewModelKata.Domain
{
    public sealed class ViewModel : IViewModel
    {
        private int counter = 0;

        public event Action<String> ShowMessage;

        public void OnShowMessage()
        {
            counter++;

            var handler = this.ShowMessage;
            if (handler != null) 
                handler(string.Format("Die Action wurde bereits: {0} mal aufgerufen.", counter));
        }
    }
}
