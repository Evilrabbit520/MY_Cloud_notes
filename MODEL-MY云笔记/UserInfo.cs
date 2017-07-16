using DbManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL_MY云笔记
{
    public class UserInfo:BaseModel
    {
        public UserInfo() : base() { }
        public UserInfo(DataRow dr) : base(dr) { }
        /// <summary>
        /// 账户名
        /// </summary>
        public string Account { set; get; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }
        public bool? RememberMe { get; set; }
        public string RememberPassWord { get; set; }
        public string LoginMsg { get; set; }
        public bool LoginFlag { get; set; } = false;
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string IDCard { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string UserAddress { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }
    }
}
