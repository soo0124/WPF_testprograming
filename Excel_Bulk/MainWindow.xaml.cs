using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace Excel_Bulk
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

        private string mFileName = string.Empty;

        private void btn_click1(object sender, RoutedEventArgs e)
        {
            //파일선택 윈도우창 라이브러리 호출
            System.Windows.Forms.OpenFileDialog of = new System.Windows.Forms.OpenFileDialog();
            of.Multiselect = false; //파일 여러개 선택 옵션 비활성화

            //showdialog = 화면에 출력해주는 메소드
            if (of.ShowDialog() == System.Windows.Forms.DialogResult.OK) //확인 눌렀어?
            {
                mFileName = of.FileName;

                MessageBox.Show(mFileName);
            }
        }

        private void btn_click2(object sender, RoutedEventArgs e)
        {
            string fileName = "Excel_Bulk.Resources.testfile.txt";
            
            Assembly assembly = Assembly.GetExecutingAssembly();

            Stream reader = assembly.GetManifestResourceStream(fileName);

            if(reader != null)
            {
                var copyFile = File.Create("D:\\CopyFile.txt");
                reader.CopyTo(copyFile);
                copyFile.Close();
                reader.Close();
            }

        }
    }
}
