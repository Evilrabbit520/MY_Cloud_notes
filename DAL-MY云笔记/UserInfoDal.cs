using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbManager;
using MODEL_MY云笔记;
using System.Data.SqlClient;
using System.Data;

namespace DAL_MY云笔记
{
    public class UserInfoDal
    {
        public static async Task<DataTable> SelectUserInfoByAccount(string Account)
        {
            using (
                var cmd =
                    new SqlCommand(
                        @"select * from [Digital Technology].dbo.Digital_Technology_Users (nolock) where Account = @Account ")
            )
            {
                cmd.Parameters.AddWithValue("@Account", Account);
                return await DbHelper.ExecuteDataTableAsync(cmd);
            }
        }
        public static async Task<int> UpdateUserInfoByAccount(string Account,string UserName,string Email,string UserAddress,string Phone)
        {
            using (
                var cmd =
                    new SqlCommand(
                        @"update [Digital Technology].dbo.Digital_Technology_Users  set UserName = @UserName , Email = @Email , UserAddress = @UserAddress , Phone = @Phone where Account = @Account ")
                        //@"update [Digital Technology].dbo.Digital_Technology_Users  set UserName = '" +UserName+"' , Email = '"+Email+"' , UserAddress = '"+UserAddress+"' , Phone = '"+Phone+"' where Account = '"+Account+"' ")
            )
            {
                cmd.Parameters.AddWithValue("@Account", Account);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@UserAddress", UserAddress);
                cmd.Parameters.AddWithValue("@Phone", Phone);
            return await DbHelper.ExecuteNonQueryAsync(cmd);
            }
        }
    }
}
