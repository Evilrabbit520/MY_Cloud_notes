using DAL_MY云笔记;
using MODEL_MY云笔记;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util_MY云笔记;

namespace BLL_MY云笔记
{
    public class LoginManager
    {
        public UserInfo UserLogin(UserInfo user)
        {
            user=UserLoginDal.Login(user);
            if (!user.LoginFlag) return user;
            if (user.RememberMe==true)
            {
                user.RememberPassWord = Encrypt.MD5ToString(user.UserName,user.PassWord);
            }
            else
            {
                user.RememberPassWord = "";
            }
            SaveRememberUser(user);
            return user;
        }
        public static void SaveRememberUser(UserInfo user)
        {
            AppConfig.SaveConfig("UserName", user.UserName);
            AppConfig.SaveConfig("PassWord", user.RememberPassWord);
            AppConfig.SaveConfig("RememberMe", user.RememberMe.ToString());
        }
        public static UserInfo GetRememberUser()
        {
            UserInfo user = new UserInfo();
            user.UserName = AppConfig.GetConfig("UserName");
            user.PassWord = AppConfig.GetConfig("PassWord");
            user.RememberMe = AppConfig.GetConfig("RememberMe") == "True";
            return user;
        }
    }
}
