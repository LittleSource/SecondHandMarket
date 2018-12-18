using SecondHandMarket.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecondHandMarket.ViewController.User
{
    public partial class Edit : Form
    {
        private Goods good;
        public Edit(int goodId)
        {
            good = new Goods(goodId);
            InitializeComponent();
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            textBox1.Text = good.GoodName;
            textBox2.Text = good.NewPirce.ToString();
            textBox3.Text = good.OldPirce.ToString();
            pictureBox1.Image = Image.FromStream(new MemoryStream(good.Picture));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "请选择要插入的图片";
            openFileDialog1.Filter = "JPG图片|*.jpg|PNG图片|*.png|BMP图片|*.bmp|Gif图片|*.gif";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double newPirce = 0.0;//新品价格
            double oldPirce = 0.0;//二手价格
            //开始验证
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "")
            {
                MessageBox.Show("商品信息不能为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                newPirce = Convert.ToDouble(textBox2.Text.Trim());
                oldPirce = Convert.ToDouble(textBox3.Text.Trim());
            }
            catch
            {
                MessageBox.Show("价格格式错误，当前支持正整数，正小数（小数位小于5）", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = "";
                textBox3.Text = "";
                textBox2.Focus();
            }
            //准备二进制图片
            byte[] imagebytes;
            if (pictureBox1.ImageLocation != null)
            {
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open);
                imagebytes = new byte[fs.Length];
                BinaryReader br = new BinaryReader(fs);
                imagebytes = br.ReadBytes(Convert.ToInt32(fs.Length));
            }
            else
            {
                imagebytes = this.good.Picture;
            }
            
            //写入字段
            good.GoodName = textBox1.Text.Trim();
            good.Picture = imagebytes;
            good.NewPirce = (float)newPirce;
            good.OldPirce = (float)oldPirce;
            //入库
            if (good.edit())
            {
                MessageBox.Show("修改成功，请刷新！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }
            else
            {
                MessageBox.Show("修改失败，请联系小源！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
