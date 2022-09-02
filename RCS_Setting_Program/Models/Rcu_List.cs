using RCS_Setting_Program.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCS_Setting_Program.Models
{
    public class Rcu_List : Notify
    {
        private int _lightIndex = 0;
        public int lightIndex
        {
            get => _lightIndex;
            set => base.OnPropertyChanged(ref _lightIndex, value);
        }

        private int[] _lightNum = { 1, 2, 3, 4, 5, 6};
        public int[] lightNum
        {
            get => _lightNum;
            set => base.OnPropertyChanged(ref _lightNum, value);
        }

        private int _selectNum;
        public int selectNum
        {
            get => _selectNum;
            set
            {
                if(base.OnPropertyChanged(ref _selectNum, value))
                {
                    foreach (var item in relayLists)
                    {
                        List<MatchItem> backupAB = item.circuitNo.Where(x => x.Division == "A" || x.Division == "B").ToList();

                        item.circuitNo.Clear();

                        for (int j = 1; j <= value; j++)
                        {
                            item.circuitNo.Add(new MatchItem() { Value = j, Division = "L", Display = $"{j}번 회로" }); //선택한 회로수만큼 추가
                        }

                        foreach (var AB in backupAB)
                        {
                            item.circuitNo.Add(AB);
                        }
                    }
                }
            }
        }

        private bool _masterUse = false;
        public bool masterUse
        {
            get => _masterUse;
            set => base.OnPropertyChanged(ref _masterUse, value);
        }

        private bool _bathUse = false;
        public bool bathUse
        {
            get => _bathUse;
            set => base.OnPropertyChanged(ref _bathUse, value);
        }

        public ObservableCollection<Relay> _relayLists = new ObservableCollection<Relay>();
        public ObservableCollection<Relay> relayLists
        {
            get => _relayLists;
            set => base.OnPropertyChanged(ref _relayLists, value);
        }

        public Rcu_List(int Index)
        {
            this.lightIndex = Index;

            for (int i = 1; i < 33; i++)
            {
                Relay relay = new Relay();

                relay.relayNo = i;

                for (int k = 1; k < selectNum+1; k++)
                {
                    relay.circuitNo.Add(new MatchItem() { Value = k, Division = "L", Display = $"{k}번 회로"});
                }


                relayLists.Add(relay);
            }

        }

    }
}
