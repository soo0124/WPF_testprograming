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

namespace Wpf_Process
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            //현재실행되어있는 프로그램 정보 
            Process currentProcess = Process.GetCurrentProcess();

            //현재PC에 실행중인 프로세스들을 배열로 갖고온다.
            Process[] processList = Process.GetProcesses();
            this.LBO_processList.ItemsSource = processList;

            foreach (Process process in processList)
            {
                if(process.ProcessName.Equals(currentProcess.ProcessName))
                {
                    if (process.Id == currentProcess.Id)
                    {
                        continue;
                    }
                    else process.Kill();
                }
            }
        }
    }
}
