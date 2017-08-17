using MODEL_MY云笔记;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbManager.Extensions;

namespace DAL_MY云笔记
{
    public class UserLoginDal
    {
        public static UserInfo Login(UserInfo user)
        {
            //登录就在这里写了、

            //连接数据库比对，后面写三层架构的时候把数据库的操作写进去
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "user id=Digital Technology;Data Source=mssql.ybj.pw;database=Digital Technology;password=DigitalTechnology2017";
            con.Open();
            if (user.UserName == "" || user.PassWord == "")
            {
                user.LoginMsg= "请输入账号或密码";
            }
            else//这里
            {
                SqlCommand com = new SqlCommand("select count(*) from Digital_Technology_Users where Account='" + user.UserName + "' and UserPwd='" + user.PassWord.HashPassWord() + "'", con);
                //com.CommandText = ;
                var a = com.ExecuteScalar();
                int num = Convert.ToInt32(a);
                if (num > 0)
                {
                    con.Close();
                    user.LoginFlag = true;
                    user.LoginMsg="开发账户登录成功" ;
                    
                }
                else
                {
                    user.LoginMsg= "请检查您的用户名或者密码";
                }
            }
            return user;
        }
    }
}
