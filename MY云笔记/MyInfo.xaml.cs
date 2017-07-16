using BLL_MY云笔记;
using MODEL_MY云笔记;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MY云笔记
{
    /// <summary>
    /// MyInfo.xaml 的交互逻辑
    /// </summary>
    public partial class MyInfo : Window
    {
        /// <summary>
        /// 委托类型原型，用于使上级 窗口？ 更新用户信息
        /// </summary>
        public delegate void DelegateUpdateUserInfo();
        /// <summary>
        /// 委托方法，用于使上级 窗口？ 更新用户信息
        /// </summary>
        public DelegateUpdateUserInfo UpdateUserInfo;

        public MyInfo()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        public string Account;
        private void MYDH_MouseDown(object sender, MouseEventArgs e)       //登录窗口移动
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var pint = Mouse.GetPosition(this);
                if (pint.X < 50 || pint.Y < 120)
                    //此处会在点击名字文本框的同时移动鼠标时发生
                    DragMove();
            }
        }
        private void button_Close(object sender, RoutedEventArgs e)
        {
            this.Close();   //关闭用户信息窗口
        }
        private void MyInfo_Loaded(object sender, RoutedEventArgs e)
        {
            ///获取账号还没做完
            var task = Task.Run(() => UserInfoBL.SelectUserInfoByAccount(Account));
            task.Wait();
            List<UserInfo> UserInfoList = task.Result;
            UserName_TextBox.Text = UserInfoList.FirstOrDefault()?.UserName;
            if (UserInfoList.FirstOrDefault()?.Gender == "1")
            {
                Gender_Text.Content = "男";
            }
            if (UserInfoList.FirstOrDefault()?.Gender == "2")
            {
                Gender_Text.Content = "女";
            }
            IDCard_Text.Content = UserInfoList.FirstOrDefault()?.IDCard;
            Email_TextBox.Text = UserInfoList.FirstOrDefault()?.Email;
            Address_TextBox.Text = UserInfoList.FirstOrDefault()?.UserAddress;
            Phone_TextBox.Text = UserInfoList.FirstOrDefault()?.Phone;
        }
        /// <summary>
        /// 修改按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            UserInfo UI = new UserInfo();
            UI.Account = Account;
            UI.UserName = UserName_TextBox.Text;
            UI.Email = Email_TextBox.Text;
            UI.UserAddress = Address_TextBox.Text;
            UI.Phone = Phone_TextBox.Text;
            if (UserName_TextBox.Text == null || UserName_TextBox.Text == "")
            {
                MessageBox.Show("请输入昵称");
                return;
            }
            if (Email_TextBox.Text == null || Email_TextBox.Text == "")
            {
                MessageBox.Show("请输入邮箱");
                return;
            }
            if (Address_TextBox.Text == null || Address_TextBox.Text == "")
            {
                MessageBox.Show("请输入地址");
                return;
            }
            if (Phone_TextBox.Text == null || Phone_TextBox.Text == "")
            {
                MessageBox.Show("请输入电话");
                return;
            }
            var task = Task.Run(() => UserInfoBL.UpdateUserInfoByAccount(UI.Account, UI.UserName, UI.Email,UI.UserAddress, UI.Phone));
            task.Wait();
            int Result = Convert.ToInt32(task.Result);
            if (Result == 1)
            {
                MessageBox.Show("修改信息成功");
                //测试成功（用户名与窗口移动pint.X/Y变量有冲突.）
                this.Close();
            }
            else
            {
                MessageBox.Show("修改信息失败");
            }
        }

        private void Grid_Unloaded(object sender, RoutedEventArgs e)
        {
            //更新上级窗口用户信息
            this.UpdateUserInfo();
        }
    }
}
