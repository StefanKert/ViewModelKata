using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModelKata.Contracts;
using ViewModelKata.Domain.Annotations;

namespace ViewModelKata.Domain
{
    public sealed class ViewModel : IViewModel
    {
        private int counter = 0;


        private String _randomString;
        public String RandomString
        {
            get { return this._randomString; }
            set { this.OnPropertyChanged(ref _randomString, value); }
        }

        public event Action<String> ShowMessage;

        public void OnShowMessage()
        {
            counter++;

            var handler = this.ShowMessage;
            if (handler != null) 
                handler(string.Format("Die Action wurde bereits: {0} mal aufgerufen.", counter));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            var handler = this.PropertyChanged;
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
}
