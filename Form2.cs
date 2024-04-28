using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace 挂机锁
{
    public partial class Form2 : Form
    {
        public string password = "";
        public int time = 0;
        public Form2()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //调节button和texbox的位置
            this.textBox1.Location = new System.Drawing.Point(this.Width - 300, this.Height - 100);
            this.button1.Location = new System.Drawing.Point(this.Width - 290 + textBox1.Width, this.Height - 102);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == password) { Application.Exit(); return; }
            else { MessageBox.Show("密码错误"); }
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F4) && (e.Alt == true)) { e.Handled = true; return; }//禁用Alt+F4
            if ((e.KeyCode == Keys.R) && (e.Modifiers == Keys.LWin || e.Modifiers == Keys.RWin)) { e.Handled = true; return; }//禁用不了
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            Process[] p = Process.GetProcesses();
            foreach (Process proc in p)//禁用任务管理器
            {
                try
                {
                    if (proc.ProcessName.ToLower().Trim() == "taskmgr")
                    {
                        proc.Kill();
                        return;
                    }
                }
                catch { return; }
            }
        }
        public void TimerStart()
        {
            if (time != 0)
            {
                timer2.Interval = time;
                timer2.Start();
            }
        }
        public void timer2_Tick(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
