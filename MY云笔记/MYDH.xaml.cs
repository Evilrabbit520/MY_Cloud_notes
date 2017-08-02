using BLL_MY云笔记;
using MODEL_MY云笔记;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// MYDH.xaml 的交互逻辑
    /// </summary>
    public partial class MYDH : Window
    {
       
        public MYDH(UserInfo user)
        {
            InitializeComponent();
            InitMYDH(user);
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Fweather.Source = new Uri("https://www.baidu.com/");    //天气模块Frame的URL
            Fad.Source = new Uri("https://www.baidu.com/");    //文字列表广告模块Frame的URL
        }
        private void InitMYDH(UserInfo user)
        {
           
        }

        private void button_Click(object sender, RoutedEventArgs e)     //关闭登录窗口
        {
            App.Current.Shutdown();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
             this.WindowState = System.Windows.WindowState.Minimized;    //最小化登录窗口
        }

        private void MYDH_MouseDown(object sender, MouseEventArgs e)       //登录窗口移动
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var pint = Mouse.GetPosition(this);
                if (pint.X < 50 || pint.Y < 120)
                    DragMove();
            }
        }

        private void MyInfo_Click(object sender, RoutedEventArgs e)
        {
            MyInfo MI = new MyInfo();
            MI.Account = Account;

            //在这里将委托赋值，即运行更新信息的函数
            MI.UpdateUserInfo = () => {
                this.UpdateUserInfo();
            };

            MI.Show();
        }

        private void UpdateUserInfo()
        {
            //此处应填写更新用户信息的代码
            this.Window_Loaded(null,null);
            //throw new NotImplementedException();
        }

        public string Account;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var task = Task.Run(() => UserInfoBL.SelectUserInfoByAccount(Account));
            task.Wait();
            List<UserInfo> UserInfoList = task.Result;
            MyInfo.Content = UserInfoList.FirstOrDefault()?.UserName;
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            New DH = new New();
            DH.Show();
        }

    }
}
