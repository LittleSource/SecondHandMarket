using SecondHandMarket.Model;
using SecondHandMarket.ViewController.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecondHandMarket
{
    
    public partial class MyGoods : Form
    {
        public MyGoods()
        {
            InitializeComponent();
        }
        private void MyGoods_Load(object sender, EventArgs e)
        {
            listView1_Load();
        }

        /// <summary>
        /// 加载“我的”商品数据
        /// </summary>
        private void listView1_Load()//hasGoods没写没判断
        {
            Goods goods = new Goods();
            List<Goods> goodsList = goods.getWhere("user_name", User.NowLoginName);
            for (int i = 0; i < goodsList.Count; i++)//dt.Rows.Count 获取数据表dt中行的个数
            {
                toolStripComboBox1.Items.Add(goodsList[i].Id.ToString());//将ID加载到下拉框

                listView1.Items.Add(goodsList[i].Id.ToString());

                //根据列名将SubItems集合的元素分别添加进去，第二列第二行开始，集合中的元素按行排列
                listView1.Items[i].SubItems.Add(goodsList[i].GoodName.ToString());
                listView1.Items[i].ImageIndex = i;
                listView1.Items[i].SubItems.Add(goodsList[i].NewPirce.ToString());
                listView1.Items[i].SubItems.Add(goodsList[i].OldPirce.ToString());
                listView1.Items[i].SubItems.Add(goodsList[i].AddDate.ToString().Substring(0, 11));
                listView1.Items[i].SubItems.Add(goodsList[i].UserName.ToString());

                MemoryStream ms = new MemoryStream(goodsList[i].Picture);
                imageList1.Images.Add(Image.FromStream(ms));

                listView1.SmallImageList = imageList1;
            }
            toolStripComboBox1.SelectedIndex = 0;
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            new Edit(Int32.Parse(toolStripComboBox1.SelectedItem.ToString())).ShowDialog();
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(toolStripComboBox1.SelectedItem.ToString());
            DialogResult dr = MessageBox.Show("确定要删除商品"+id+"吗?", "系统提示", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                Goods good = new Goods(id);
                if (good.del())
                {
                    MessageBox.Show("删除成功，请刷新！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("删除失败，请联系小源！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            imageList1.Images.Clear();
            listView1_Load();
        }
    }
}
