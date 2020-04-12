using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;

            button1.Click += NumberClick;
            button2.Click += NumberClick;
            button3.Click += NumberClick;
            button4.Click += NumberClick;
            button5.Click += NumberClick;
            button6.Click += NumberClick;
            button7.Click += NumberClick;
            button8.Click += NumberClick;
            button9.Click += NumberClick;
            button10.Click += NumberClick;      
            
        }

        private void NumberClick(object sender, EventArgs e)
        {
            textBox.Text += ((Button)sender).Text;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            
        }
    }
}
