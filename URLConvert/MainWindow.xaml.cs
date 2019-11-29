using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace URLConvert
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        const string KDUrl = "https://kandian.qq.com/mqq/kdapp/html/videoShare.html?_wv=1&x5PreFetch=1&channel_id=29&rowkey=";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnConvert_Click(object sender, RoutedEventArgs e)
        {
            string url = this.txtUrl.Text;
            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("请输入腾讯看点视频地址！");
                return;
            }
            int index  = url.LastIndexOf('/');
            int index2 = url.IndexOf('?');
            if(index <= 0 || index2 <= 0)
            {
                MessageBox.Show("腾讯看点视频地址解析出错！");
                return;
            }
            string newurl = url.Substring(index, index2 - index);
            string[] newurls = newurl.Split('-');
            this.txtKDUrl.Text = $"{KDUrl}{newurls[1]}";
            try
            {
                Clipboard.SetText(this.txtKDUrl.Text);
            }
            catch
            {

            }
        }

        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            string url = this.txtKDUrl.Text;
            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("看点视频地址为空！");
                return;
            }
            Process.Start(url);
        }
    }
}
