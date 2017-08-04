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
    /// New.xaml 的交互逻辑
    /// </summary>
    public partial class New : Window
    {
        internal object Shut;

        public New()
        {
            InitializeComponent();
        }
        private void Image_MouseLeftButtonDown_W(object sender, MouseButtonEventArgs e)
        {
           Word DH = new Word();
           DH.Show();
        }
        private void Image_MouseLeftButtonDown_E(object sender, MouseButtonEventArgs e)
        {
            Excel DH = new Excel();
            DH.Show();
        }
        private void Image_MouseLeftButtonDown_P(object sender, MouseButtonEventArgs e)
        {
            Word DH = new Word();
            DH.Show();
        }
        private void Image_MouseLeftButtonDown_XM(object sender, MouseButtonEventArgs e)
        {
            Word DH = new Word();
            DH.Show();
        }
        private void Image_MouseLeftButtonDown_T(object sender, MouseButtonEventArgs e)
        {
            Word DH = new Word();
            DH.Show();
        }
    }
}
