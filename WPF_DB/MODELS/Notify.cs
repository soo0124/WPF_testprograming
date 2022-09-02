using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPF_DB.MODELS
{
    public class Notify : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool OnPropertyChanged<T>(ref T property, T value, [CallerMemberName] string propertyName = "")
        {
            //입력된 값과 출력 값이 동일한 데이터 형식인경우
            if (!EqualityComparer<T>.Default.Equals(property, value))
            {
                property = value; //입력된 값을 출력값에 넣는다

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); // 화면으로 변경된 출력값을 이벤트로 신호로 알려줌 (클래스 파일 -> xaml 파일이 알수있게끔)

                return true;
            }
            else
            {
                return false;
            }
        }

        protected void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
