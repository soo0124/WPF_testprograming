using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Testprogram2.Models;

namespace WPF_Testprogram2.ViewModels
{
    public partial class MainViewModel : Notify
    {
        #region 액셀벌크 뷰바인딩
        private bool mIsBulkPage = false;
        private int mExcelTestTime = 1000;
        private bool mIsExcelTest = false;

        private string mSelectExcelCommand;

        private string mTxtSourceExcelFile;
        private string mTxtDestinationExcelFile;

        public bool IsBulkPage
        {
            get => mIsBulkPage;
            set => base.OnPropertyChanged(ref mIsBulkPage, value);
        }
        public int ExcelTestTime
        {
            get => mExcelTestTime;
            set => base.OnPropertyChanged(ref mExcelTestTime, value);
        }
        public bool IsExcelTest
        {
            get => mIsExcelTest;
            set => base.OnPropertyChanged(ref mIsExcelTest, value);
        }

        public List<string> ExcelCommandList { get; set; } = new List<string>()
        {
            "Online Check",
            "Read Card(No Card)",
            "Read Card(On Card)",
            "Write Card - Checkin",
            "Write Card - Pre-Checkin",
            "Write Card - Standby",
            "Write Card - OneTime",
            "Write Card - Emergency",
            "Write Card - Grand Master",
            "Write Card - Master",
            "Write Card - Maid",
            "Write Card - Minibar",
            "Write Card - Reset",
            "Write Card - Time",
            "Write Card - Init",
            "Write Card - Parameter",
            "Write Card - Set Address",
            "Write Card - HandHeld",
            "Door) A1_Set Parameter",
            "Door) A5_Set Initializing",
            "Door) A6_SpecialArea",
            "Door) A8_Set Guest Time Slot",
            "Door) AA_Set Group Room",
            "Door) AB_Set Group Security",
            "Door) AC_Extend Check-Out Date",
            "Door) B3_Set Current Time",
            "Door) C0_On-Line Check",
            "Door) C1_Reader Information",
            "Door) C3_ReaderEvent",
            "Door) C4_Request Current Time",
            "Door) C5_Request Parameter",
            "Door) C6_Set Security Number",
            "복합 시나리오",
        };
        public string SelectExcelCommand
        {
            get => mSelectExcelCommand;
            set => base.OnPropertyChanged(ref mSelectExcelCommand, value);
        }

        public string TxtSourceExcelFile
        {
            get => mTxtSourceExcelFile;
            set => base.OnPropertyChanged(ref mTxtSourceExcelFile, value);
        }
        public string TxtDestinationExcelFile
        {
            get => mTxtDestinationExcelFile;
            set => base.OnPropertyChanged(ref mTxtDestinationExcelFile, value);
        }
        #endregion

        
    }
}
