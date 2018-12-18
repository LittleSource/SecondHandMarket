using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandMarket
{
    class Db
    {
        private SqlConnection con = new SqlConnection();
        private SqlCommand com = new SqlCommand();
        private string conString;

        public SqlConnection Con { get => con; set => con = value; }
        public SqlCommand Com { get => com; set => com = value; }
        public string ConString { get => conString; set => conString = value; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// Config.ConString从配置类中取得数据库连接字符串
        /// <param name="ConString">数据库连接字符串</param>
        public Db()
        {
            Con.ConnectionString = Config.ConString;
            Con.Open();
            Com.Connection = Con;
        }

        public SqlDataReader getSqlDataReader(string sqlString)
        {
            SqlCommand com_ = getSqlCommand(sqlString);
            return com_.ExecuteReader();
        }

        public SqlConnection getSqlConnection()
        {
            return this.Con;
        }

        public SqlCommand getSqlCommand(string sqlString)
        {
            return new SqlCommand(sqlString, Con);
        }

        public SqlDataAdapter getSqlDataAdapter(string sqlString)
        {
            return new SqlDataAdapter(sqlString, this.Con);
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void close()
        {
            con.Close();
        }
    }
}
