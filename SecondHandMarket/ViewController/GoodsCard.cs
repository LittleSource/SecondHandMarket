using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SecondHandMarket.Model;
using System.IO;

namespace SecondHandMarket.ViewController
{
    public partial class GoodsCard : UserControl
    {
        private Goods good;
        public GoodsCard(Goods good)
        {
            this.good = good;
            InitializeComponent();
        }

        private void GoodsCard_Load(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream(good.Picture);
            pictureBox1.Image = Image.FromStream(ms);
            labelGoodsName.Text = good.GoodName;
            labelOldPirce.Text = good.OldPirce.ToString().Insert(0,"￥");
            labelNewPirce.Text = good.NewPirce.ToString();
            labelAddDate.Text = good.AddDate.Substring(0,11);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("购买此二手商品请联系电话：" + good.UserName);
        }
    }
}
