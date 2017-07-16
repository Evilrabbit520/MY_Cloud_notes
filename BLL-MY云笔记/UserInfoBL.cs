using MODEL_MY云笔记;
using DAL_MY云笔记;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_MY云笔记
{
    public class UserInfoBL
    {
        public static async Task<List<UserInfo>> SelectUserInfoByAccount(string Account)
        {
            var dt =await DAL_MY云笔记.UserInfoDal.SelectUserInfoByAccount(Account);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            return dt.Rows.OfType<DataRow>().Select(x => new UserInfo(x)).ToList();//这个返回的是list
            //return dt.Rows.OfType<DataRow>().Select(x => new UserInfo(x)).FirstOrDefault();//这个返回的是序列的第一个元素
        }
        public static async Task<int> UpdateUserInfoByAccount(string Account, string UserName, string Email, string UserAddress, string Phone)
        {
            return await DAL_MY云笔记.UserInfoDal.UpdateUserInfoByAccount(Account,UserName,Email,UserAddress,Phone);
            
        }
    }
}
