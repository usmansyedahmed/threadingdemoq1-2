using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ThreadingDemo
{
    public partial class Form1 : Form
    {
        public delegate void updateUI(int id);
        public void UIdoSome(int id)
        {
            textBox1.AppendText("Hello, My Thread ID is : " + id);
            textBox1.AppendText(Environment.NewLine);
        }

        private void threadFunc()
        {
            object[] parametersArray = new object[] { Thread.CurrentThread.ManagedThreadId };
            textBox1.Invoke(new updateUI(UIdoSome), parametersArray);
            return;
        }
        private void createThreads(int n)
        {
            Thread[] threads = new Thread[n];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(new ThreadStart(threadFunc));
                threads[i].Start();
            }

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Random rndNum = new Random();
           int num = rndNum.Next(1, 6);
           createThreads(num); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
