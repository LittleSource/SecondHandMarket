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
        private int id;
        private string name;
        private string passWord;
        private static string nowLoginName = "";

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public static string NowLoginName { get => nowLoginName;set{if(NowLoginName == "") nowLoginName = value;}}//加入set条件以提高安全性
        
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

        //下面的函数没有具体业务，懒得实现，有兴趣扩展本项目的自己实现吧

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
