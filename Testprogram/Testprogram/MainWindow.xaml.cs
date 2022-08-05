using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Testprogram
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<DTC_setting> DTC_List { get; set; } = new ObservableCollection<DTC_setting>(); //DTC 리스트 설정
        public ObservableCollection<RCU_Setting> RCU_LS_List { get; set; } = new ObservableCollection<RCU_Setting>(); //RCU 라이트스위치 리스트 설정


        SerialPort serialPort;

        String[] cb_mode_Names = { "RCB-1", "RCB-2", "RCB-3", "RCB-4", "RCB-5", "RCB-6", "RCB-7", "RCB-8", "RCB-9", "RCB-10" };
        
        int[] normal_items = { 0,1,2,3,4 };
        private int backup_data { get; set; }
        public int Normal_Select
        {
            get => backup_data;
            set
            {
                backup_data = value+10;

                List<ButtonItem> deleteList = new List<ButtonItem>();

                if (RCU_LS_List.Count > 0)
                {
                    foreach (var btn in RCU_LS_List[0].Buttons)
                    {
                        if (btn.Key.Contains("번 B접점"))
                        {
                            deleteList.Add(btn);
                        }
                    }
                }

                for (int i = 0; i < RCU_LS_List.Count; i++)
                {
                    for (int j = 0; j < deleteList.Count; j++)
                    {
                        RCU_LS_List[i].Buttons.Remove(deleteList[j]);
                    }
                }

                for (int i = 0; i < RCU_LS_List.Count; i++)
                {
                    // 전열 추가
                    for (int j = 11; j <= backup_data; j++)
                    {
                        RCU_LS_List[i].Buttons.Add(new ButtonItem(j-10 + "번 B접점", j.ToString()));
                    }
                }

            }
        }

        private int _backup_data { get; set; }
        public int Valve_Select
        {
            get => _backup_data;
            set
            {
                _backup_data = value+6;

                List<ButtonItem> deleteList = new List<ButtonItem>();

                if (RCU_LS_List.Count > 0)
                {
                    foreach (var btn in RCU_LS_List[0].Buttons)
                    {
                        if (btn.Key.Contains("번 A접점"))
                        {
                            deleteList.Add(btn);
                        }
                    }
                }

                for (int i = 0; i < RCU_LS_List.Count; i++)
                {
                    for (int j = 0; j < deleteList.Count; j++)
                    {
                        RCU_LS_List[i].Buttons.Remove(deleteList[j]);
                    }
                }

                for (int i = 0; i < RCU_LS_List.Count; i++)
                {
                    // 전열 추가
                    for (int j = 7; j <= _backup_data; j++)
                    {
                        RCU_LS_List[i].Buttons.Add(new ButtonItem(j-6 + "번 A접점", j.ToString()));
                    }
                }

            }
        }

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;

            portNum.ItemsSource = SerialPort.GetPortNames();    
            portNum.SelectedIndex = 2;

            CB_MODE.ItemsSource = cb_mode_Names;
            CB_MODE.SelectedIndex = 0;

            CB_MODE_RELAY.ItemsSource = cb_mode_Names;
            CB_MODE_RELAY.SelectedIndex = 0;

            normal_relay.ItemsSource = normal_items;
            valve_relay.ItemsSource = normal_items;

            //ListBox 설정
            ListDTC.ItemsSource = DTC_List; 
            lsList.ItemsSource = RCU_LS_List;
        }


        public void isTX_DATA(byte[] packet)
        {
            if(serialPort == null || serialPort.IsOpen == false)
            {
                MessageBox.Show("* 통신 포트 연결상태를 확인하세요 *", "ERROR");
                tabControl_Xaml.SelectedIndex = 0;
            }
            else
            {
                serialPort.Write(packet, 0, packet.Length);
                MessageBox.Show(" 설정상태 전송 완료! ", "설정");
                Console.WriteLine(BitConverter.ToString(packet));
            }            
        }

        //---------------------------------------------------[환경설정 TAB]---------------------------------------------------//
        private void portNumOpen(object sender, RoutedEventArgs e)
        {
            serialPort = new SerialPort(portNum.SelectedValue.ToString(), 19200, Parity.None, 8, StopBits.One);

            serialPort.DataReceived += SerialPort_DataReceived;

            try
            {
                if (!serialPort.IsOpen) // 안열려 있는 경우..
                {
                    serialPort.Open();
                    MessageBox.Show($"{portNum.SelectedValue} 연결완료", "통신포트");
                    portStatus.Background = Brushes.Yellow;
                    portStatus.Content = "포트 열림";
                    tabControl_Xaml.Background = Brushes.Yellow;
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        private void portNumClose(object sender, RoutedEventArgs e)
        {
            
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
                MessageBox.Show($"{portNum.SelectedValue} 연결해제", "통신포트");
                portStatus.Background = Brushes.DarkGreen;
                portStatus.Content = "포트 닫힘";
                tabControl_Xaml.Background = Brushes.DarkGreen;
            }
        }

        private void falling_Set(object sender, RoutedEventArgs e)
        {
            int btn_fallingCount = Convert.ToInt32(falling_Speed.Text);

            byte[] packet = new byte[8];

            packet[0] = 0x28;
            packet[1] = 0xff;
            packet[2] = 0xff;
            packet[3] = 0xff;
            packet[4] = 0xff;
            packet[5] = (Byte)'~';
            packet[6] = (Byte)btn_fallingCount;
            packet[7] = 0x29;

            isTX_DATA(packet);
        }

        private void falling_reSet(object sender, RoutedEventArgs e)
        {
            byte[] packet = new byte[7];

            packet[0] = 0x28;
            packet[1] = 0xff;
            packet[2] = 0xff;
            packet[3] = 0xff;
            packet[4] = 0xff;
            packet[5] = (Byte)'-';
            packet[6] = 0x29;

            isTX_DATA(packet);
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort serialPort = sender as SerialPort;
            if (serialPort.BytesToRead > 0)
            {
                byte[] packet = new byte[serialPort.BytesToRead];
                serialPort.Read(packet, 0, packet.Length);
                Console.WriteLine(BitConverter.ToString(packet));
            }
        }
        //-------------------------------------------------------------------------------------------------------------------//


        //--------------------------------------------------[중계기 설정 TAB]-------------------------------------------------//
        private void RCU_SET_Click(object sender, RoutedEventArgs e) //RCU 전체개수 설정
        {
            int btn_rcuAllCount = Convert.ToInt32(rcuAllCount.Text);

            byte[] packet = new byte[8];

            packet[0] = 0x28;
            packet[1] = 0xff;
            packet[2] = 0xff;
            packet[3] = 0xff;
            packet[4] = 0xff;
            packet[5] = (Byte)'!';
            packet[6] = (Byte)btn_rcuAllCount;
            packet[7] = 0x29;

            isTX_DATA(packet);
        }

        private void DTC_SET_Click(object sender, RoutedEventArgs e) //DTC 전체개수 설정
        {
            int btn_dtcAllCount = Convert.ToInt32(dtcAllCount.Text);
            byte[] packet = new byte[8];
    
            packet[0] = 0x28;
            packet[1] = 0xff;
            packet[2] = 0xff;
            packet[3] = 0xff;
            packet[4] = 0xff;
            packet[5] = (Byte)'@';
            packet[6] = (Byte)btn_dtcAllCount;
            packet[7] = 0x29;

            isTX_DATA(packet);

            DTC_List.Clear();
    
            for (int i = 1; i <= btn_dtcAllCount; i++)
            {
                DTC_List.Add(new DTC_setting("DTC " + i, i));
            }
        }

        private void DTC_ALL_Connect(object sender, RoutedEventArgs e) //각 DTC 설정 전체 적용
        {
            int btn_dtcAllCount = DTC_List.Count;

            byte[] packet = new byte[(btn_dtcAllCount*2) + 8];

            packet[0] = 0x28;
            packet[1] = 0xff;
            packet[2] = 0xff;
            packet[3] = 0xff;
            packet[4] = 0xff;
            packet[5] = (byte)'&';
            packet[6] = (byte)DTC_List.Count;

            for(int i = 0, j = 6; i < DTC_List.Count; i++, j+=2)
            {
                packet[j + 1] = (byte)(DTC_List[i].Address-1);
                packet[j + 2] = (byte)DTC_List[i].RcuCount;
            }

            packet[(btn_dtcAllCount*2) + 7] = 0x29;

            isTX_DATA(packet);
        }

        //-------------------------------------------------------------------------------------------------------------------//


        //---------------------------------------------------[RCU 설정 TAB]--------------------------------------------------//
        private void LS_Add(object sender, RoutedEventArgs e)
        {
            int count = RCU_LS_List.Count > 0 ? RCU_LS_List.Max(ls => ls.Relay_List.Count) : 0;

            var rcu = new RCU_Setting(RCU_LS_List.Count + 1);
            rcu.RelayInit(count);
            RCU_LS_List.Add(rcu);
        }

        private void LS_Delete(object sender, RoutedEventArgs e)
        {
            RCU_LS_List.RemoveAt(RCU_LS_List.Count - 1);
        }

        private void RELAY_ADD(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < RCU_LS_List.Count; i++)
            {
                if(RCU_LS_List[i].Relay_List.Count < 4)
                {
                    RCU_LS_List[i].Relay_List.Add(new Relay_Setting(RCU_LS_List[i].Relay_List.Count));
                }
            }
            Relay_Column_Add();
        }

        private void RELAY_DELETE(object sender, RoutedEventArgs e)
        {
            int count = RCU_LS_List.Max(ls => ls.Relay_List.Count);

            for (int i = 0; i < RCU_LS_List.Count; i++)
            {
                RCU_LS_List[i].Relay_List.RemoveAt(RCU_LS_List[i].Relay_List.Count - 1);
            }
        }

        /// <summary>
        /// 데이터 그리드 컬럼 셋업 (릴레이 리스트)
        /// </summary>
        private void Relay_Column_Add()
        {
            int count = RCU_LS_List.Max(ls => ls.Relay_List.Count);

            int relayListCount = (RelayList.Columns.Count - 1) / 8;

            if (relayListCount < count)
            {
                for (int i = 1; i <= 8; i++)
                {
                    var column = new DataGridTemplateColumn();

                    // 컬럼 헤더 셋업.
                    //릴레이설정TAB, 릴레이 데이터 테이블 자동 할당 (*규칙: 릴레이 추가 버튼 누름 횟수 이용) 
                    //※1개 추가 8개 RELAY 생성
                    int portNum = count == 1 ? i : i + (8 * (count - 1)); // Relay Port Numver
                    column.Header = $"RELAY {portNum}";
                    Style style = new Style(typeof(DataGridColumnHeader));
                    style.Setters.Add(new Setter(DataGridColumnHeader.BackgroundProperty, Brushes.YellowGreen));
                    style.Setters.Add(new Setter(DataGridColumnHeader.HorizontalContentAlignmentProperty, HorizontalAlignment.Center));
      
                    column.HeaderStyle = style;
                    column.Width = 105;

                    // 셀 스타일 셋업.
                    Style style1 = new Style(typeof(ComboBoxItem));
                    string relayNum = string.Format("Relay_List[{0}].Relay_CK{1}", relayListCount, i);

                    // 체크박스: LS 매칭 여부.
                    var checkBox = new FrameworkElementFactory(typeof(CheckBox));
                    checkBox.SetBinding(CheckBox.IsCheckedProperty, new Binding(relayNum));

                    // 콤보박스: LS 버튼 매칭 넘버.
                    var comboBox = new FrameworkElementFactory(typeof(ComboBox));

                    comboBox.SetBinding(ComboBox.ItemsSourceProperty, new Binding("Buttons"));

                    Binding binding = new Binding($"Relay_List[{relayListCount}].Relay_LsBtnNo{i}");
                    binding.Mode = BindingMode.TwoWay;
                    binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                    comboBox.SetBinding(ComboBox.SelectedValueProperty, binding);

                    comboBox.SetValue(ComboBox.DisplayMemberPathProperty, "Key");
                    comboBox.SetValue(ComboBox.SelectedValuePathProperty, "Value");

                    comboBox.SetValue(ComboBox.WidthProperty, 100.0);

                    var combobox2 = new FrameworkElementFactory(typeof(ComboBoxItem));

                    var stackPanel = new FrameworkElementFactory(typeof(StackPanel));
                    stackPanel.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
                    stackPanel.AppendChild(checkBox);
                    stackPanel.AppendChild(comboBox);

                    var dataTemplate = new DataTemplate();
                    dataTemplate.VisualTree = stackPanel;

                    column.CellTemplate = dataTemplate; // this.Resources["DgRelay"] as DataTemplate;
                    RelayList.Columns.Add(column);
                }
            }
        }

        private void RCU_TYPE_SET_CLICK(object sender, RoutedEventArgs e) //RCU 전체 적용
        {
            byte[] packet = new byte[(RCU_LS_List.Count * 5)+9];

            packet[0] = 0x28;
            packet[1] = 0xff;
            packet[2] = 0xff;
            packet[3] = 0xff;
            packet[4] = 0xff;
            packet[5] = (byte)'*';
            packet[6] = (byte)CB_MODE.SelectedIndex;
            packet[7] = (byte)RCU_LS_List.Count;
            
            for (int i = 0, j = 8; i < RCU_LS_List.Count; i++, j+=5)
            {
                packet[j] = (byte)RCU_LS_List[i].lightName;
                packet[j + 1] = (byte)RCU_LS_List[i].lightNum_Select;
                packet[j + 2] = Convert.ToByte(RCU_LS_List[i].isMaster);
                packet[j + 3] = Convert.ToByte(RCU_LS_List[i].isBath);
                packet[j + 4] = Convert.ToByte(RCU_LS_List[i].isGiga);
            }

            packet[(RCU_LS_List.Count * 5) + 8] = 0x29;

            isTX_DATA(packet);
            
        }
        //-------------------------------------------------------------------------------------------------------------------//

        //--------------------------------------------------[릴레이 설정 TAB]-------------------------------------------------//
        private void Relay_setting(object sender, RoutedEventArgs e)
        {
            int All_lightNum = 0; 
            for (int k = 0; k < RCU_LS_List.Count; k++)
            {
                All_lightNum += RCU_LS_List[k].lightNum_Select;
            }
           
            byte[] packet = new byte[((All_lightNum) *3)+11+((RCU_LS_List[0].Buttons.Count - RCU_LS_List[0].lightNum_Select)*3)];

            packet[0] = 0x28;
            packet[1] = 0xff;
            packet[2] = 0xff;
            packet[3] = 0xff;
            packet[4] = 0xff;
            packet[5] = (byte)'+';
            packet[6] = (byte)CB_MODE_RELAY.SelectedIndex;
            packet[7] = (byte)RCU_LS_List.Count;
            packet[8] = (byte)(All_lightNum + (RCU_LS_List[0].Buttons.Count - RCU_LS_List[0].lightNum_Select));
            packet[9] = (byte)RCU_LS_List[0].Relay_List.Count;

            Dictionary<int, List<string>> ls_Btn_Mappings = new Dictionary<int, List<string>>();

            // LS 리스트 루프.
            for (int i = 0; i < RelayList.Items.Count; i++)
            {
                var rcu_ls = RelayList.Items[i] as RCU_Setting;
                int ls_address = rcu_ls.lightName;

                List<string> values = new List<string>();

                ls_Btn_Mappings.Add(ls_address, values);

                // 각 LS 별 릴레이 세트를 루프 (1세트 ~ 4세트, 4세트 당 릴레이 포트 8개)
                for (int j = 0; j < rcu_ls.Relay_List.Count; j++)
                {
                    // 릴레이. (8개의 포트를 가짐)
                    var relay = rcu_ls.Relay_List[j];

                    // 릴레이 내에 8개의 포트 변수를 루프.
                    for (int k = 0, number = 1; k < 8; k++, number++)
                    {
                        // 릴레이 클레스에서 특정 프로퍼티 추출.
                        var relay_No = relay.GetType().GetProperty($"Relay_Num{number}").GetValue(relay);
                        var ls_btn = relay.GetType().GetProperty($"Relay_LsBtnNo{number}").GetValue(relay);

                        // 1번부터 8번 포트까지 설정 값 추출. (포트명, 포트에 매칭된 LS 버튼 구수, 포트넘버)
                        string ls_Name = ls_address.ToString();
                        string ls_Btn_Name = ls_btn.ToString();
                        string relay_Name = relay_No.ToString();

                        // LS 넘버, LS 버튼넘버, 릴레이 넘버
                        // Console.WriteLine("LS No: {0}, LS Btn No: {1}, Relay No: {2}", ls_Name, ls_Btn_Name, relay_Name);

                        //ls_Btn_Mappings[ls_address].Add($"{ls_Btn_Name}:{relay_Name}");
                        ls_Btn_Mappings[ls_address].Add($"{ls_Btn_Name}");
                        ls_Btn_Mappings[ls_address].Add($"{relay_Name}");
                    }
                }
            }
            
            int index = 10;
            foreach (var ls in ls_Btn_Mappings)
            {
                for (int test1 = 0, i = 0, k = 1; test1 < RCU_LS_List[0].Relay_List.Count * 8; test1++, i += 2, k += 2)
                {
                    int abc =  Convert.ToInt32(ls.Value[i]);

                    if (abc > 0)
                    { 
                        packet[index] = (byte)ls.Key; //전등이름
                        packet[index + 1] = Convert.ToByte(ls.Value[i]); //회로
                        packet[index + 2] = Convert.ToByte(ls.Value[k]); //릴레이
                        index += 3;
                    }
                }
            }
            packet[((All_lightNum) * 3) + 10 + ((RCU_LS_List[0].Buttons.Count - RCU_LS_List[0].lightNum_Select) * 3)] = 0x29;

            isTX_DATA(packet);
        }
        //-------------------------------------------------------------------------------------------------------------------//
    }
}
