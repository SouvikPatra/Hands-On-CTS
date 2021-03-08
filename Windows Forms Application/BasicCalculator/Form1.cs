using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textInput1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(textInput1.Text);
            double b = Convert.ToDouble(textInput2.Text);
            double result=0;
            if (radioButton1.Checked)
            {
                result = a + b;
            }
            else if (radioButton2.Checked)
            {
                result = a - b;
            }
            else if (radioButton3.Checked)
            {
                result = a * b;
            }
            else if (radioButton4.Checked)
            {
                result = a / b;
            }
            MessageBox.Show(result.ToString());
        }
    }
}
