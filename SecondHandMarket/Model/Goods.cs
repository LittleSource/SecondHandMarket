using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandMarket.Model
{
    public class Goods : IModel
    {
        private Db db = new Db();
        private int id;//商品id
        private string goodName;//商品名称
        private byte[] picture;//二进制图片
        private float newPirce;//新品价格
        private float oldPirce;//二手价格
        private string addDate;//发布日期
        private string userName;//用户名，也就是手机号

        public int Id { get => id; set => id = value; }
        public string GoodName { get => goodName; set => goodName = value; }
        public byte[] Picture { get => picture; set => picture = value; }
        public float NewPirce { get => newPirce; set => newPirce = value; }
        public float OldPirce { get => oldPirce; set => oldPirce = value; }
        public string AddDate { get => addDate; set => addDate = value; }
        public string UserName { get => userName; set => userName = value; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="goodName"></param>
        /// <param name="picture"></param>
        /// <param name="newPirce"></param>
        /// <param name="oldPirce"></param>
        /// <param name="addDate"></param>
        /// <param name="userName"></param>
        public Goods(int id, string goodName, byte[] picture, float newPirce, float oldPirce, string addDate, string userName)
        {
            this.Id = id;
            this.GoodName = goodName;
            this.Picture = picture;
            this.NewPirce = newPirce;
            this.OldPirce = oldPirce;
            this.AddDate = addDate;
            this.UserName = userName;
        }
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public Goods()
        {
        }
        /// <summary>
        /// 构造函数
        /// 传入参数id从数据库取出id等于传入id的实例
        /// </summary>
        /// <param name="id"></param>
        public Goods(int id)
        {
            List<Goods> goodList = getWhere("id", id.ToString());
            this.Id = goodList[0].Id;
            this.GoodName = goodList[0].GoodName;
            this.Picture = goodList[0].Picture;
            this.NewPirce = goodList[0].NewPirce;
            this.OldPirce = goodList[0].OldPirce;
            this.AddDate = goodList[0].AddDate;
            this.UserName = goodList[0].UserName;
            this.GoodName = goodList[0].GoodName;
        }
        /// <summary>
        /// 获取所有商品
        /// </summary>
        /// <returns>List<Goods></returns>
        public List<Goods> getAll()
        {
            return getWhere("","");
        }
        /// <summary>
        /// 根据条件从数据库获取商品
        /// </summary>
        /// <param name="field">字段</param>
        /// <param name="value">字段对应值</param>
        /// <returns>List<Goods></returns>
        public List<Goods> getWhere(string field, string value)
        {
            string sqlString = "select * from [Goods] order by add_date desc";
            if(field != "" && value != "")
            {
                sqlString = "select * from [Goods] where " + field + "='" + value + "' order by add_date desc";
            }
            List<Goods> goodsList = new List<Goods>();
            SqlDataAdapter da = db.getSqlDataAdapter(sqlString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)//dt.Rows.Count 获取数据表dt中行的个数
            {
                DataRow dr = dt.Rows[i];//构建的数据表中一行的数据 ,行的集合
                if (dr["picture"] is DBNull)
                {
                    using (MemoryStream mostream = new MemoryStream())
                    {
                        Bitmap bmp = Properties.Resources.icons8_File_Nopicture_40px;//加入默认图片
                        bmp.Save(mostream, System.Drawing.Imaging.ImageFormat.Bmp);//将图像以指定的格式存入缓存内存流
                        byte[] bt = new byte[mostream.Length];
                        mostream.Position = 0;//设置流的初始位置
                        mostream.Read(bt, 0, Convert.ToInt32(bt.Length));
                        dr["picture"] = bt;
                    }
                }
                goodsList.Add(new Goods(Int32.Parse(dr["id"].ToString()), dr["good_name"].ToString(), (byte[])dr["picture"], (float)Convert.ToDouble(dr["new_pirce"].ToString()), (float)Convert.ToDouble(dr["old_pirce"].ToString()), dr["add_date"].ToString(), dr["user_name"].ToString()));
            }
            return goodsList;
        }
        /// <summary>
        /// 添加一个商品
        /// </summary>
        /// <returns>bool</returns>
        public bool add()
        {
            string sqlString = "insert into Goods([good_name],[picture],[new_pirce],[old_pirce],[add_date],[user_name])values(@GoodName,@Picture,@NewPirce,@OldPirce,@AddDate,@UserName)";
            SqlCommand com = db.getSqlCommand(sqlString);
            //--参数绑定
            com.Parameters.Add("GoodName", SqlDbType.Text);
            com.Parameters["GoodName"].Value = GoodName;

            com.Parameters.Add("Picture", SqlDbType.Image);
            com.Parameters["Picture"].Value = Picture;

            com.Parameters.Add("NewPirce", SqlDbType.Float);
            com.Parameters["NewPirce"].Value = NewPirce;

            com.Parameters.Add("OldPirce", SqlDbType.Float);
            com.Parameters["OldPirce"].Value = OldPirce;

            com.Parameters.Add("AddDate", SqlDbType.Date);
            com.Parameters["AddDate"].Value = DateTime.Now.ToShortDateString();

            com.Parameters.Add("UserName", SqlDbType.Text);
            com.Parameters["UserName"].Value = User.NowLoginName;
            //绑定结束--
            if (com.ExecuteNonQuery() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一个商品
        /// </summary>
        /// <returns>bool</returns>
        public bool del()
        {
            string sqlString = "DELETE FROM [Goods] WHERE id ="+Id;
            SqlCommand com = db.getSqlCommand(sqlString);
            if (com.ExecuteNonQuery() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 编辑商品
        /// </summary>
        /// <returns>bool</returns>
        public bool edit()
        {
            string sqlString = "UPDATE [dbo].[Goods] SET [good_name] = @GoodName,[picture] = @Picture,[new_pirce] = @NewPirce ,[old_pirce] = @OldPirce WHERE id = @Id";
            SqlCommand com = db.getSqlCommand(sqlString);
            //--参数绑定
            com.Parameters.Add("Id", SqlDbType.Int);
            com.Parameters["Id"].Value = Id;

            com.Parameters.Add("GoodName", SqlDbType.Text);
            com.Parameters["GoodName"].Value = GoodName;

            com.Parameters.Add("Picture", SqlDbType.Image);
            com.Parameters["Picture"].Value = Picture;

            com.Parameters.Add("NewPirce", SqlDbType.Float);
            com.Parameters["NewPirce"].Value = NewPirce;

            com.Parameters.Add("OldPirce", SqlDbType.Float);
            com.Parameters["OldPirce"].Value = OldPirce;
            //绑定结束--
            if (com.ExecuteNonQuery() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool hasGoods(string userName)
        {
            List<Goods> goodList = getWhere("user_name", userName);
            if(goodList.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 无实际业务故未实现
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool findByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
