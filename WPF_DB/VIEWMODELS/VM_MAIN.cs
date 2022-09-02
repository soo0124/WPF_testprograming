using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_DB.MODELS;
using WPF_DB.MODELS.VIEWITEM;

namespace WPF_DB.VIEWMODELS
{
    public class VM_MAIN : Notify
    {
        SerialCom serialCom;

        public ObservableCollection<CommLog> logList { get; set; } = new ObservableCollection<CommLog>();

        private ObservableCollection<String> _portLists = new ObservableCollection<string>();
        public ObservableCollection<String> portLists
        {
            get => _portLists;
            set => base.OnPropertyChanged(ref _portLists, value);
        }

        //Select comport
        private string _selectPort;
        public string selectPort
        {
            get => _selectPort;
            set => base.OnPropertyChanged(ref _selectPort, value);
        }

        private string _txPacket;
        public string txPacket
        {
            get => _txPacket;
            set => base.OnPropertyChanged(ref _txPacket, value);
        }

        private string _ConnectionString = "" +
            "Server=localhost;" +
            "Port=3306;" +
            "Uid=root;" +
            "Password=racos5117;" +
            "Database=encoder;";

        public VM_MAIN()
        {
            serialCom = new SerialCom();

            Init();
            //logList.Add(new CommLog() 
            //{ 
            //    No = 1,
            //    EventDateTime = DateTime.Now,
            //    Division = true,
            //    packet = "7B7D"
            //});

            BtnClick_Refresh();
        }

        public void Init()
        {
            foreach (string port in SerialPort.GetPortNames())
            {
                portLists.Add(port);
            }
        }

        public void Btn_Connect()
        {
            if (!serialCom.IsOpen)
            {
                serialCom.OpenCom(selectPort, 19200, 8, StopBits.One, Parity.None);
               
            }
            else
            {
                serialCom.CloseCom();
            
            }
        }

        public void Btn_TX()
        {

        }

        public void BtnClick_Refresh()
        {
            //1. DB 접속
            //2. DB SELECT로 데이터 가져오기
            //3. ENCODER 테이블 데이터를 프로그램에서 사용할 Commlog 클래스를 리스트화하여 변환한다.
            //4. LIST된 내용을 화면과 바인딩 해줘야한다.

            string sql = "SELECT * FROM encoder.commlog WHERE 1 = 1;";

            DataTable dt = MariaDB.ExecuteDataTable(_ConnectionString, sql);

            if(dt != null)
            {
                logList.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    logList.Add(new CommLog()
                    {
                        No = Convert.ToInt32(row["No"]),
                        EventDateTime = Convert.ToDateTime(row["EventDateTime"]),
                        Division = Convert.ToBoolean(row["Division"]), //Division = Convert.ToInt32(row["Division"]) == 1? true : false,
                        packet = Convert.ToString(row["Packet"]),
                    });
                }
            }

        }

        public void Btn_insert()
        {
            //1 로그리스트의 마지막값을 복사
            //2 마지막 값에서 Index + 1
            //3 데이터베이스의 직접적으로 Insert 쿼리를 날림
            //4 Insert가 성공되면 화면의 logList 리스트에 추가 

            if(logList.Count == 0)
            {
                return;
            }

            var lastLog = logList.Last();
            lastLog.No += 1;
            lastLog.Division = false;
            lastLog.EventDateTime = DateTime.Now;
            lastLog.packet = "7B7D";

            int division = lastLog.Division ? 1 : 0;

            string sql = $"INSERT INTO `encoder`.`commlog` (`No`, `EventDateTime`, `Division`, `Packet`) " +
                $"VALUES ('{lastLog.No}', '{lastLog.EventDateTime:yyyy-MM-dd HH:mm:ss}', '{division}', '{lastLog.packet}');";

            if(MariaDB.ExecuteNonQuery(_ConnectionString, sql) > 0)
            {
                logList.Add(lastLog);
            }
            else
            {
                MessageBox.Show("데이터 추가 실패");
            }
        }

        public void Btn_update()
        {
            //1 마지막값에 디비젼을 반전시켜주는 내용의 버튼 로직구현
            
            if(logList.Count < 1)
            {
                return;
            }

            CommLog lastLog = logList.Last();
            lastLog.Division = !lastLog.Division;

            int division = lastLog.Division ? 1 : 0;

            string sql = $"UPDATE `Encoder`.`commlog` SET `Division`='{division}' WHERE `No`={lastLog.No};";

            if (MariaDB.ExecuteNonQuery(_ConnectionString, sql) > 0)
            {
                logList[logList.Count - 1] = lastLog;
                //logList.Last().Division = lastLog.Division;

                //base.OnPropertyChanged("logList");
            }
            else
            {
                MessageBox.Show("데이터 업데이트 실패");
            }
        }

        public void Btn_delete()
        {
            //1 마지막값을 삭제한다. DELETE 
        }
    }
}
