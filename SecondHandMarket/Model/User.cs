using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandMarket.Model
{
    class User : IModel
    {
        private Db db = new Db();
        private int id;//用户id
        private string name;//用户名
        private string passWord;//密码
        private static string nowLoginName = "";//当前登录的用户名

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public static string NowLoginName { get => nowLoginName;set{if(NowLoginName == "") nowLoginName = value;}}//加入set条件以提高安全性
        /// <summary>
        /// 根据用户名查找用户
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool findByName(string name)
        {
            SqlDataReader dr = db.getSqlDataReader("select * from [User] where name = '" + name + "'");
            try
            {
                dr.Read();
                this.Name = dr["name"].ToString();
                this.PassWord = dr["password"].ToString();

                return true;
            }
            catch
            {
                return false;
            }
        }

        //下面的方法没有具体业务，懒得实现
        //有兴趣扩展本项目的自己实现吧(比如管理员身份会用到下面的方法)
        public bool add()
        {
            throw new NotImplementedException();
        }

        public bool del()
        {
            throw new NotImplementedException();
        }

        public bool edit()
        {
            throw new NotImplementedException();
        }
    }
}
