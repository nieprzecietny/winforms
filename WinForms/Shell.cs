using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForms.Presenters;
using WinForms.Views;

namespace WinForms
{
    public partial class Shell : Form, IShellView
    {
        public Shell()
        {
            InitializeComponent();
        }

        public EventHandler LoadMenu { get; set; }

        public Form Window { get { return this; } }

        public void LoadComponent(Control control)
        {
            panel1.Controls.Clear();
            if (!panel1.Controls.Contains(control))
            {
                panel1.Controls.Add(control);
                
            }
        }


        public void SetText(string newText)
        {
            this.Text = newText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (LoadMenu != null)
            {
                LoadMenu.Invoke(this, EventArgs.Empty);
            }
        }
    }
}