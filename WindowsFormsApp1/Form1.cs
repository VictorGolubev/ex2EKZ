using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            listBox1.Items.Clear();
            Executor t = new Executor();
            double eps = Convert.ToDouble(textBox1.Text);
            double x = Convert.ToDouble(textBox2.Text);
            t.getSum(x, eps, listBox1);
            textBox3.Text = t.res.ToString();
            
        }

    }

    class Executor
    {
        public double res;

        private double getS(double x,int n)
        {
            int factorial = 1;
            for (int i = 2; i <= (2*n-1); i++) // факториал n
            {
                factorial = factorial * i;
            }
            return Math.Pow(-1,n)*(Math.Pow(x,n+1))/factorial;
        }
        public void getSum(double x, double e, ListBox l)
        {
            double an = -x * x;
            double sum = an;
            int count = 2;
            while(Math.Abs(an - getS(x,count)) > e)
            {
                an = getS(x, count);
                l.Items.Add(an);
                count++;
            }
            res = getS(x, count);
            
        }
    }
}
