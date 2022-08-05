using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testprogram
{
    public class Relay_Setting
    {
        public int Relay_Num1 { get; set; } //relay_ck 32개 까지 만들어야 하지 않은가?
        public bool Relay_CK1 { get; set; }
        public int Relay_LsBtnNo1 { get; set; }

        public int Relay_Num2 { get; set; }
        public bool Relay_CK2 { get; set; }
        public int Relay_LsBtnNo2 { get; set; }

        public int Relay_Num3 { get; set; }
        public bool Relay_CK3 { get; set; }
        public int Relay_LsBtnNo3 { get; set; }

        public int Relay_Num4 { get; set; }
        public bool Relay_CK4 { get; set; }
        public int Relay_LsBtnNo4 { get; set; }

        public int Relay_Num5 { get; set; }
        public bool Relay_CK5 { get; set; }
        public int Relay_LsBtnNo5 { get; set; }

        public int Relay_Num6 { get; set; }
        public bool Relay_CK6 { get; set; }
        public int Relay_LsBtnNo6 { get; set; }

        public int Relay_Num7 { get; set; }
        public bool Relay_CK7 { get; set; }
        public int Relay_LsBtnNo7 { get; set; }

        public int Relay_Num8 { get; set; }
        public bool Relay_CK8 { get; set; }
        public int Relay_LsBtnNo8 { get; set; }

        public Relay_Setting(int count)
        {
            count += 1;
            switch(count)
            {
                case 1:

                    this.Relay_Num1 = count;
                    this.Relay_Num2 = count + 1;
                    this.Relay_Num3 = count + 2;
                    this.Relay_Num4 = count + 3;
                    this.Relay_Num5 = count + 4;
                    this.Relay_Num6 = count + 5;
                    this.Relay_Num7 = count + 6;
                    this.Relay_Num8 = count + 7;
                    break;

                case 2:

                    this.Relay_Num1 = count + 7;
                    this.Relay_Num2 = count + 8;
                    this.Relay_Num3 = count + 9;
                    this.Relay_Num4 = count + 10;
                    this.Relay_Num5 = count + 11;
                    this.Relay_Num6 = count + 12;
                    this.Relay_Num7 = count + 13;
                    this.Relay_Num8 = count + 14;
                    break;


                case 3:
                    this.Relay_Num1 = count + 14;
                    this.Relay_Num2 = count + 15;
                    this.Relay_Num3 = count + 16;
                    this.Relay_Num4 = count + 17;
                    this.Relay_Num5 = count + 18;
                    this.Relay_Num6 = count + 19;
                    this.Relay_Num7 = count + 20;
                    this.Relay_Num8 = count + 21;
                    break;
                    
                case 4:
                    this.Relay_Num1 = count + 21;
                    this.Relay_Num2 = count + 22;
                    this.Relay_Num3 = count + 23;
                    this.Relay_Num4 = count + 24;
                    this.Relay_Num5 = count + 25;
                    this.Relay_Num6 = count + 26;
                    this.Relay_Num7 = count + 27;
                    this.Relay_Num8 = count + 28;
                    break;
            }
        }

    }
}
