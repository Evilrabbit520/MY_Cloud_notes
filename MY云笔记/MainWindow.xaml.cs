 using System;      //测试
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MODEL_MY云笔记;
using BLL_MY云笔记;
using System.Windows.Markup;

namespace MY云笔记
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
#pragma warning disable CS0169 // 从不使用字段“MainWindow.mssql”
        private readonly object mssql;
#pragma warning restore CS0169 // 从不使用字段“MainWindow.mssql”

        /// <summary>
        /// 用户名
        /// </summary>
        private string UserId { get; set; }
        /// <summary>
        /// 获取用户名数组
        /// </summary>
        private string TakeUserId { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            InitUserConfig();
        }

        private void InitUserConfig()
        {
            UserInfo user = LoginManager.GetRememberUser();

            txtLog.Text = user.UserName;
            txtPass.Password = user.PassWord;
            ChechBox_RememberMe.IsChecked = user.RememberMe;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //if(txtLog.Text !=""&txtPass.Password !="")
            //{
            //    SqlDataReader temDR = MyClass.getcom("select*from Digital Technology Users where Name="'+ texName.Text.Trim()+"');

            //}
            UserInfo user = new UserInfo();
            //取出用户界面的数据
            user.UserName = txtLog.Text;
            user.PassWord = txtPass.Password.Trim();
            user.RememberMe = ChechBox_RememberMe.IsChecked;

            LoginManager mgr = new LoginManager();
            user = mgr.UserLogin(user);

            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            MessageBox.Show(user.LoginMsg);
            if (user.LoginFlag)
            {
                MYDH DH = new MYDH(user);
                DH.Account = txtLog.Text;
                DH.Show();
                //new MYDH(user).Show();
                Close(); // Close the current window
            }
            else
            {
                return;
            }
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            Process.Start("http://www.idigitaltechnology.com/Home/Register");     //注册账号
        }

        private void button1_Copy_Click_1(object sender, RoutedEventArgs e)
        {
            Process.Start("http://www.baidu.com");      //忘记密码
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;    //最小化
        }

        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void MYDLOGIN_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var pint = Mouse.GetPosition(this);
                if (pint.X < 50 || pint.Y < 120)
                    DragMove();
            }
        }



    }

        internal class Persist
        {

        }
    
}
