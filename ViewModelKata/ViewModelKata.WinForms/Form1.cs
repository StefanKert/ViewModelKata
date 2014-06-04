using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModelKata.Contracts;

namespace ViewModelKata.WinForms
{
    public partial class Form1 : Form, IUI
    {
        public Form1()
        {
            InitializeComponent();
            this.button1.Click += (o, e) => ClickButton(); 
        }

        public event Action ClickButton;

        public void ShowMessage(String message)
        {
            MessageBox.Show("Neue Nachricht für WinForms: " + message);
        }
    }
}
