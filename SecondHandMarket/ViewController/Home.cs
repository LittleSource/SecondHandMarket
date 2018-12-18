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
using System.IO;
using SecondHandMarket.Model;
using SecondHandMarket.ViewController;

namespace SecondHandMarket
{
    public partial class Home : Form
    {
        private Goods goods = new Goods();
        public Home()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 打开窗口时加载所有商品数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Home_Load(object sender, EventArgs e)
        {
            Goods goods = new Goods();
            List<Goods> goodsList = goods.getAll();
            flowLayoutPanel_Load(goodsList);
        }
        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            new Add().ShowDialog();
        }
        /// <summary>
        /// 刷新按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            this.flowLayoutPanel1.Controls.Clear();
            List<Goods> goodsList = goods.getAll();
            flowLayoutPanel_Load(goodsList);
        }
        /// <summary>
        /// 我的商品按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonMe_Click(object sender, EventArgs e)
        {
            new MyGoods().ShowDialog();
        }
        /// <summary>
        /// 搜索按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonFind_Click(object sender, EventArgs e)
        {
            string selectedText = toolStripComboBox1.SelectedText;
            string value = toolStripTextBox1.Text.Trim();
            if(selectedText == "" || value == "")
            {
                MessageBox.Show("搜索信息不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string field = "good_name";//默认根据商品名称查找
            switch (selectedText)
            {
                case "联系电话": field = "user_name";break;
                case "商品名称": field = "good_name";break;
            }
            List<Goods> goodsList = goods.getWhere(field,value);
            if(goodsList.Count < 1)
            {
                MessageBox.Show("未查询到相关商品！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                flowLayoutPanel_Load(goodsList);
            }
        }
        /// <summary>
        /// 从goodsList中取出所有商品加载到flowLayoutPanel控件中
        /// </summary>
        private void flowLayoutPanel_Load(List<Goods> goodsList)
        {
            for(int i = 0;i<goodsList.Count; i++)//dt.Rows.Count 获取数据表dt中行的个数
            {
                GoodsCard goodsCard = new GoodsCard(goodsList[i]);
                this.flowLayoutPanel1.Controls.Add(goodsCard);
            }
        }
    }
}
