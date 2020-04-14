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

    public static class FractionConverter
    {
        public static string Convert(decimal pvalue,
        bool skip_rounding = false, decimal dplaces = (decimal)0.0625)
        {
            decimal value = pvalue;

            if (!skip_rounding)
                value = FractionConverter.DecimalRound(pvalue, dplaces);

            if (value == Math.Round(value, 0)) // whole number check
                return value.ToString();

            // get the whole value of the fraction
            decimal mWhole = Math.Truncate(value);

            // get the fractional value
            decimal mFraction = value - mWhole;

            // initialize a numerator and denomintar
            uint mNumerator = 0;
            uint mDenomenator = 1;

            // ensure that there is actual a fraction
            if (mFraction > 0m)
            {
                // convert the value to a string so that
                // you can count the number of decimal places there are
                string strFraction = mFraction.ToString().Remove(0, 2);

                // store the number of decimal places
                uint intFractLength = (uint)strFraction.Length;

                // set the numerator to have the proper amount of zeros
                mNumerator = (uint)Math.Pow(10, intFractLength);

                // parse the fraction value to an integer that equals
                // [fraction value] * 10^[number of decimal places]
                uint.TryParse(strFraction, out mDenomenator);

                // get the greatest common divisor for both numbers
                uint gcd = GreatestCommonDivisor(mDenomenator, mNumerator);

                // divide the numerator and the denominator by the greatest common divisor
                mNumerator = mNumerator / gcd;
                mDenomenator = mDenomenator / gcd;
            }

            // create a string builder
            StringBuilder mBuilder = new StringBuilder();

            // add the whole number if it's greater than 0
            if (mWhole > 0m)
            {
                mBuilder.Append(mWhole);
            }

            // add the fraction if it's greater than 0m
            if (mFraction > 0m)
            {
                if (mBuilder.Length > 0)
                {
                    mBuilder.Append(" ");
                }

                mBuilder.Append(mDenomenator);
                mBuilder.Append("/");
                mBuilder.Append(mNumerator);
            }

            return mBuilder.ToString();
        }

        private static uint GreatestCommonDivisor(uint valA, uint valB)
        {
            // return 0 if both values are 0 (no GSD)
            if (valA == 0 &&
              valB == 0)
            {
                return 0;
            }
            // return value b if only a == 0
            else if (valA == 0 &&
                  valB != 0)
            {
                return valB;
            }
            // return value a if only b == 0
            else if (valA != 0 && valB == 0)
            {
                return valA;
            }
            // actually find the GSD
            else
            {
                uint first = valA;
                uint second = valB;

                while (first != second)
                {
                    if (first > second)
                    {
                        first = first - second;
                    }
                    else
                    {
                        second = second - first;
                    }
                }

                return first;
            }

        }

        private static decimal DecimalRound(decimal val, decimal places)
        {
            string sPlaces = FractionConverter.Convert(places, true);
            string[] s = sPlaces.Split('/');

            if (s.Count() == 2)
            {
                int nPlaces = System.Convert.ToInt32(s[1]);
                decimal d = Math.Round(val * nPlaces);
                return d / nPlaces;
            }

            return val;
        }
    }
        
}
