using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelKata.Contracts
{
    public interface IViewModel : INotifyPropertyChanged
    {
        event Action<String> ShowMessage;
        void OnShowMessage();
    }
}
