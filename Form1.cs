namespace 挂机锁
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int number;
        private void button2_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(this.textBox1.Text)) { MessageBox.Show("请输入密码"); }
            else if (string.IsNullOrEmpty(this.textBox2.Text)) { MessageBox.Show("请确认密码"); }
            else if (textBox2.Text != textBox1.Text) { MessageBox.Show("两次密码不一致"); }
            else if (!string.IsNullOrEmpty(this.textBox3.Text) && !int.TryParse(this.textBox3.Text, out number)|| number < 0)
            {
                MessageBox.Show("定时输入无效");
            }
            else if(this.textBox3.Text == "0") { MessageBox.Show("定时输入无效"); }
            else
            {
                Form2 form2 = new Form2();
                this.Hide();
                form2.password = this.textBox1.Text;
                //将textBox3.Text转化为timer2的Interval.
                if (int.TryParse(this.textBox3.Text, out number))
                {
                    form2.time = number * 1000;
                    form2.TimerStart();
                }
                form2.Opacity = 0.2;//设置透明度
                form2.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}