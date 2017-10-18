using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TapToSpeed
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static List<int> time = new List<int>();
        public static List<int> span = new List<int>();
        public static int p = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            time.Add(Environment.TickCount);
            if (p == 0)
            {
                button1.Text = "Again";
                p++;
            }
            else
            {
                p++;
                span.Add(time[p-1]-time[p-2]);
                button1.Text = "OK";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (span.Count > 2)
            {
                double interv = span.Average();
                interv = interv / 1000D;
                int pads = Convert.ToInt32(60D / interv);
                label1.Text = pads.ToString();
            }
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            time.Clear();
            span.Clear();
            p = 0;
            label1.Text = "??";
            button1.Text = "点我";
        }
    }
}
