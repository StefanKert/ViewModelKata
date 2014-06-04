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
            this.button1.Click += new EventHandler(button1_Click);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ClickButton != null)
            {
                ClickButton();
            }
        }

        public event Action ClickButton;

        public void ShowMessage(String message)
        {
            MessageBox.Show("Neue Nachricht für WinForms: " + message);
        }
    }
}
