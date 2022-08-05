using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testprogram
{
    public class ButtonItem
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public ButtonItem(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }

    public class RCU_Setting
    {
        public ObservableCollection<ButtonItem> Buttons { get; set; } = new ObservableCollection<ButtonItem>();

        public ObservableCollection<Relay_Setting> Relay_List { get; set; } = new ObservableCollection<Relay_Setting>(); //RCU 릴레이 리스트 설정

        public bool isCheck_Relay { get; set; }
        public int lightName { get; set; } //전등 스위치 이름(번호)
        public int[] lightNum { get; set; } = { 1, 2, 3, 4, 5, 6 }; //전등 회로수

        private int _lightNum_Select;
        public int lightNum_Select 
        { 
            get
            {
                return _lightNum_Select;
            }
            set
            {
                _lightNum_Select = value;

                List<ButtonItem> deleteList = new List<ButtonItem>();

                if(_lightNum_Select > 0)
                {
                    foreach (var btn in Buttons)
                    {
                        if (btn.Key.Contains($"전등{lightName}"))
                        {
                            deleteList.Add(btn);
                        }
                    }
                }

                for (int i = 0; i < _lightNum_Select; i++)
                {
                    for (int j = 0; j < deleteList.Count; j++)
                    {
                        Buttons.Remove(deleteList[j]);
                    }
                }

                for (int i = 1; i <= _lightNum_Select; i++)
                {
                    
                    Buttons.Add(new ButtonItem($"[전등{lightName}] {i}번", i.ToString()));
                }
            }
        }

        public bool isMaster { get; set; } //전등 마스터 유무

        public bool isBath { get; set; } //화장실 사용 전등 여부

        public bool isGiga { get; set; } //기가지니 연동 유무

        public RCU_Setting(int index)
        {
            lightName = index;
        }
        

        public void RelayInit(int relayGroupCount)
        {
            Relay_List.Clear();
            for (int i = 0; i < relayGroupCount; i++)
            {
                this.Relay_List.Add(new Relay_Setting(i));
            }
        }
    }

}
