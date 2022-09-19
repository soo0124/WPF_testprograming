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

namespace WPF_Basic
{
    /// <summary>
    /// SubWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SubWindow : Window
    {
        private bool mResult = false;

        public SubWindow(string message)
        {
            InitializeComponent();
            this.Txt_Msg.Text = message;
        }

        internal new bool ShowDialog()
        {
            base.ShowDialog();
            return mResult;
        }

        private void Btn_YES(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.mResult = true;
        }

        private void Btn_NO(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.mResult = false;
        }

        private void Btn_Cancle(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.mResult = false;
        }
    }
}
