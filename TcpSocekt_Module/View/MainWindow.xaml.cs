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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TcpSocekt_Module.Service;

namespace TcpSocekt_Module.View
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public int openPort { get; set; } = 5012;

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;

            TCP_Server_Module test = new TCP_Server_Module();
            test.TcpOpen(openPort);
        }
    }
}
