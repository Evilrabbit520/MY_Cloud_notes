using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MY云笔记
{
    public partial class Excel : Form
    {
        public Excel()
        {
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");     //此Excel页面的汉化语句引用Dubug文件夹下的zh-CN.   ——王嘉宁
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            App.Current.Shutdown();     //关闭窗口
        }

        private void barCheckItem1_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void Excel_Load(object sender, EventArgs e)
        {

        }

        private void spreadsheetControl1_Click(object sender, EventArgs e)
        {

        }

        private void spreadsheetCommandBarButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
