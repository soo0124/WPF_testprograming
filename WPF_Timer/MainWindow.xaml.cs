using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WPF_Timer
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            //OnTimerStart();

            //1. 일반적인 타이머 : 이벤트 구조
            DispatcherTimer dTimer = new DispatcherTimer();

            dTimer.Interval = new TimeSpan(0, 0, 1); //시 분 초
            dTimer.Tick += (sender, e) =>
            {
                this.TxtTime.Text = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}";
            };

            dTimer.Start();
        }

        //public void Method(object sender, ElapsedEventArgs e)
        //{

        //}

        public void OnTimerStart()
        {
            
                //2. 프로그램에서 이벤트를 생성하는 타이머
                System.Timers.Timer timer = new System.Timers.Timer();
                timer.Interval = 1000;
                //timer.Elapsed += Method;
                timer.Elapsed += (sender, e) =>
                {
                    App.Current.Dispatcher.Invoke(() =>
                    {
                        //메소드 구현내용을 바로 입력하는 형식 = 무명 메소드 
                        this.TxtTime.Text = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}";
                    });
                };

                timer.Start();
            

            

            //3. 지정된 간격으로 메소드를 실행하는 타이머 
            System.Threading.Timer tTimer = new System.Threading.Timer(
                (object a) => { },
                null,
                0,
                1000);

            tTimer.Dispose();
        }
    }
}
