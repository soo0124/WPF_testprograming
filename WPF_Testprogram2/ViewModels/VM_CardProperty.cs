using System;

namespace WPF_Testprogram2.ViewModels
{
    public partial class MainViewModel
    {

        private int mGuestCardSelectedIndex;
        /// <summary>
        /// 게스트 카드키 선택 인덱스
        /// </summary>
        public int GuestCardSelectedIndex
        {
            get => mGuestCardSelectedIndex; 
            set => base.OnPropertyChanged(ref mGuestCardSelectedIndex, value);
        }

        private int mStaffCardSelectedIndex = 0;
        /// <summary>
        /// 스태프 카드키 선택 인덱스
        /// </summary>
        public int StaffCardSelectedIndex
        {
            get => mStaffCardSelectedIndex;
            set => base.OnPropertyChanged(ref mStaffCardSelectedIndex, value);
        }

        private int mSystemCardSelectedIndex = 0;
        /// <summary>
        /// 시스템 카드키 선택 인덱스
        /// </summary>
        public int SystemCardSelectedIndex
        {
            get => mSystemCardSelectedIndex;
            set => base.OnPropertyChanged(ref mSystemCardSelectedIndex, value);
        }

        private int mTxtHotelCode = 1888;
        /// <summary>
        /// 호텔코드
        /// </summary>
        public int TxtHotelCode
        {
            get => mTxtHotelCode;
            set => base.OnPropertyChanged(ref mTxtHotelCode, value);
        }

        private int mTxtSecurityNo = 1;
        /// <summary>
        /// 시큐리티 넘버
        /// </summary>
        public int TxtSecurityNo
        {
            get => mTxtSecurityNo;
            set => base.OnPropertyChanged(ref mTxtSecurityNo, value);
        }

        #region 게스트키 
        private int mTxtReaderNo = 101;
        public int TxtReaderNo
        {
            get => mTxtReaderNo;
            set => base.OnPropertyChanged(ref mTxtReaderNo, value);
        }


        private int mTxtIndexNo = 1;
        public int TxtIndexNo
        {
            get => mTxtIndexNo;
            set => base.OnPropertyChanged(ref mTxtIndexNo, value);
        }

        private int mTxtCheckinDateYear = 22;
        public int TxtCheckinDateYear
        {
            get => mTxtCheckinDateYear;
            set => base.OnPropertyChanged(ref mTxtCheckinDateYear, value);
        }

        private int mTxtCheckinDateMonth = DateTime.Now.AddDays(+1).Month;
        public int TxtCheckinDateMonth
        {
            get => mTxtCheckinDateMonth;
            set => base.OnPropertyChanged(ref mTxtCheckinDateMonth, value);
        }

        private int mTxtCheckinDateDay = DateTime.Now.Day;
        public int TxtCheckinDateDay
        {
            get => mTxtCheckinDateDay;
            set => base.OnPropertyChanged(ref mTxtCheckinDateDay, value);
        }

        private int mTxtCheckoutDateYear = 22;
        public int TxtCheckoutDateYear
        {
            get => mTxtCheckoutDateYear;
            set => base.OnPropertyChanged(ref mTxtCheckoutDateYear, value);
        }

        private int mTxtCheckoutDateMonth = DateTime.Now.AddDays(+1).Month;
        public int TxtCheckoutDateMonth
        {
            get => mTxtCheckoutDateMonth;
            set => base.OnPropertyChanged(ref mTxtCheckoutDateMonth, value);
        }

        private int mTxtCheckoutDateDay = DateTime.Now.AddDays(+1).Day;
        public int TxtCheckoutDateDay
        {
            get => mTxtCheckoutDateDay;
            set => base.OnPropertyChanged(ref mTxtCheckoutDateDay, value);
        }

        private int mTxtCheckoutTime = 0;
        public int TxtCheckoutTime
        {
            get => mTxtCheckoutTime;
            set => base.OnPropertyChanged(ref mTxtCheckoutTime, value);
        }

        private int mTxtSuitArea = 0;
        public int TxtSuitArea
        {
            get => mTxtSuitArea;
            set => base.OnPropertyChanged(ref mTxtSuitArea, value);
        }

        private string mTxtSpecialArea = "1111111111111111111111111111111111111111";
        public string TxtSpecialArea
        { 
            get => mTxtSpecialArea;
            set => base.OnPropertyChanged(ref mTxtSpecialArea, value);
        }
        #endregion

        #region 스태프키
        private int mTxtStaffNo = 1;
        public int TxtStaffNo
        {
            get => mTxtStaffNo;
            set => base.OnPropertyChanged(ref mTxtStaffNo, value);
        }

        private int mTxtExpireDateYear = 99;
        public int TxtExpireDateYear
        {
            get => mTxtExpireDateYear;
            set => base.OnPropertyChanged(ref mTxtExpireDateYear, value);
        }

        private int mTxtExpireDateMonth = 12;
        public int TxtExpireDateMonth
        {
            get => mTxtExpireDateMonth;
            set => base.OnPropertyChanged(ref mTxtExpireDateMonth, value);
        }

        private int mTxtExpireDateDay = 31;
        public int TxtExpireDateDay
        {
            get => mTxtExpireDateDay;
            set => base.OnPropertyChanged(ref mTxtExpireDateDay, value);
        }

        private int mTxtWorkTime = 0;
        public int TxtWorkTime
        {
            get => mTxtWorkTime;
            set => base.OnPropertyChanged(ref mTxtWorkTime, value);
        }

        private int mTxtStaffArea = 0;
        public int TxtStaffArea
        {
            get => mTxtStaffArea;
            set => base.OnPropertyChanged(ref mTxtStaffArea, value);
        }

        #endregion

        #region 시스템키
        private int mTxtSetDateTimeYear = DateTime.Now.Year;
        public int TxtSetDateTimeYear
        {
            get => mTxtSetDateTimeYear;
            set => base.OnPropertyChanged(ref mTxtSetDateTimeYear, value);
        }

        private int mTxtSetDateTimeMonth = DateTime.Now.Month;
        public int TxtSetDateTimeMonth
        {
            get => mTxtSetDateTimeMonth;
            set => base.OnPropertyChanged(ref mTxtSetDateTimeMonth, value);
        }

        private int mTxtSetDateTimeDay = DateTime.Now.Day;
        public int TxtSetDateTimeDay
        {
            get => mTxtSetDateTimeDay;
            set => base.OnPropertyChanged(ref mTxtSetDateTimeDay, value);
        }

        private int mTxtSetDateTimeHour = DateTime.Now.Hour;
        public int TxtSetDateTimeHour
        {
            get => mTxtSetDateTimeHour;
            set => base.OnPropertyChanged(ref mTxtSetDateTimeHour, value);
        }

        private int mTxtSetDateTimeMinute = DateTime.Now.Minute;
        public int TxtSetDateTimeMinute
        {
            get => mTxtSetDateTimeMinute;
            set => base.OnPropertyChanged(ref mTxtSetDateTimeMinute, value);
        }

        private int mTxtSetDateTimeSecond = DateTime.Now.Second;
        public int TxtSetDateTimeSecond
        {
            get => mTxtSetDateTimeSecond;
            set => base.OnPropertyChanged(ref mTxtSetDateTimeSecond, value);
        }

        private int mTxtSetReaderType = 0;
        public int TxtSetReaderType
        {
            get => mTxtSetReaderType;
            set => base.OnPropertyChanged(ref mTxtSetReaderType, value);
        }

        private int mTxtSetSuitArea = 0;
        public int TxtSetSuitArea
        {
            get => mTxtSetSuitArea;
            set => base.OnPropertyChanged(ref mTxtSetSuitArea, value);
        }

        private int mTxtSetMasterArea = 0;
        public int TxtSetMasterArea
        {
            get => mTxtSetMasterArea;
            set => base.OnPropertyChanged(ref mTxtSetMasterArea, value);
        }

        private int mTxtSetMaidArea = 0;
        public int TxtSetMaidArea
        {
            get => mTxtSetMaidArea;
            set => base.OnPropertyChanged(ref mTxtSetMaidArea, value);
        }

        private int mTxtSetMinibarArea = 0;
        public int TxtSetMinibarArea
        {
            get => mTxtSetMinibarArea;
            set => base.OnPropertyChanged(ref mTxtSetMinibarArea, value);
        }

        private int mTxtSetSpecialArea = 0;
        public int TxtSetSpecialArea
        {
            get => mTxtSetSpecialArea;
            set => base.OnPropertyChanged(ref mTxtSetSpecialArea, value);
        }

        private int mTxtSetReaderAddress = 1;
        public int TxtSetReaderAddress
        {
            get => mTxtSetReaderAddress;
            set => base.OnPropertyChanged(ref mTxtSetReaderAddress, value);
        }

        private int mTxtSetGLED = 12;
        public int TxtSetGLED
        {
            get => mTxtSetGLED;
            set => base.OnPropertyChanged(ref mTxtSetGLED, value);
        }

        private int mTxtSetRLED = 8;
        public int TxtSetRLED
        {
            get => mTxtSetRLED;
            set => base.OnPropertyChanged(ref mTxtSetRLED, value);
        }

        private int mTxtSetStaffDND = 1;
        public int TxtSetStaffDND
        {
            get => mTxtSetStaffDND;
            set => base.OnPropertyChanged(ref mTxtSetStaffDND, value);
        }

        private int mTxtSetOfficeMode = 1;
        public int TxtSetOfficeMode
        {
            get => mTxtSetOfficeMode;
            set => base.OnPropertyChanged(ref mTxtSetOfficeMode, value);
        }

        private int mTxtSetLockType = 0;
        public int TxtSetLockType
        {
            get => mTxtSetLockType;
            set => base.OnPropertyChanged(ref mTxtSetLockType, value);
        }

        private int mTxtConnectTime = 15;
        public int TxtConnectTime
        {
            get => mTxtConnectTime;
            set => base.OnPropertyChanged(ref mTxtConnectTime, value);
        }
        #endregion
    }
}
