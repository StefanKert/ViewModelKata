using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelKata.Contracts
{
    public interface IUI
    {
        void Show();
        event Action ClickButton;
        void ShowMessage(String message);
    }
}
