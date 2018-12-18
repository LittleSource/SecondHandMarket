using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SecondHandMarket.Model;

namespace SecondHandMarket
{
    public partial class login : Form
    {
        //鼠标移动窗体功能
        private bool formMove = false;//窗体是否移动
        Point formPoint;//窗体位置
        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            formPoint = new Point();
            if (e.Button == MouseButtons.Left)
            {
                formPoint = new Point(-e.X, -e.Y);
                formMove = true;//开始移动
            }
        }
        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            if (formMove == true)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(formPoint.X, formPoint.Y);
                Location = mousePos;
            }
        }
        private void Login_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//按下的是鼠标左键
            {
                formMove = false;//停止移动
            }
        }

        private void rest()
        {
            textBox2.Text = "";
            textBox1.Focus();
        }
        public login()
        {
            InitializeComponent();
        }

        private void label_login_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            string passWorld = textBox2.Text.Trim();
            if(name == "" || passWorld == "")
            {
                MessageBox.Show("账号或密码不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(name.Length > 11 || passWorld.Length > 20)//再判断一下，略微预防sql注入
            {
                MessageBox.Show("账号或密码格式错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                User user = new User();
                if(user.findByName(name))
                {
                    if (user.PassWord != passWorld)
                    {
                        MessageBox.Show("账号或密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        rest();
                    }
                    else
                    {
                        User.NowLoginName = user.Name;
                        Home home = new Home();
                        this.Visible = false;
                        home.ShowDialog();
                        this.Dispose();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("无此用户！","提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rest();
                }
            }
        }
    }
}
