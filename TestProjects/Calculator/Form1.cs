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
        bool resetDisplayLabel = true;
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
            button17.Click += NumberClick;
            resetDisplay();
        }

        private void NumberClick(object sender, EventArgs e)
        {
            if(resetDisplayLabel)
            {
                resetDisplayLabel = false;
                clearDisplay();
            }
            textBox.Text = textBox.Text + ((Button)sender).Text;
            displayLabel.Text += ((Button)sender).Text;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            resetDisplay();
            resetDisplayLabel = true;
        }

        private void resetDisplay()
        {
            textBox.Text = "0";
            displayLabel.Text = "0";
        }

        private void clearDisplay()
        {
            textBox.Text = "";
            displayLabel.Text = "";
        }

    }
        
}
