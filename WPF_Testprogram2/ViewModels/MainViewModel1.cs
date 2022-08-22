using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Testprogram2.ViewModels
{
    public partial class MainViewModel 
    {
        /*
        //GuestCard Property
        private int _GuestCardSelectedIndex;
        public int GuestCardSelectedIndex
        {
            get => _GuestCardSelectedIndex;
            set => base.OnPropertyChanged(ref _GuestCardSelectedIndex, value);
        }

        private int _TxtHotelCode;
        public int TxtHotelCode
        {
            get => _TxtHotelCode;
            set => base.OnPropertyChanged(ref _TxtHotelCode, value);
        }

        private int _TxtSecurityNo;
        public int TxtSecurityNo
        {
            get => _TxtSecurityNo;
            set => base.OnPropertyChanged(ref _TxtSecurityNo, value);
        }

        private int _TxtCheckoutDateYear;
        public int TxtCheckoutDateYear
        {
            get => _TxtCheckoutDateYear;
            set => base.OnPropertyChanged(ref _TxtCheckoutDateYear, value);
        }

        private int _TxtCheckoutDateMonth;
        public int TxtCheckoutDateMonth
        {
            get => _TxtCheckoutDateMonth;
            set => base.OnPropertyChanged(ref _TxtCheckoutDateMonth, value);
        }

        private int _TxtCheckoutDateDay;
        public int TxtCheckoutDateDay
        {
            get => _TxtCheckoutDateDay;
            set => base.OnPropertyChanged(ref _TxtCheckoutDateDay, value);
        }

        private int _TxtCheckoutTime;
        public int TxtCheckoutTime
        {
            get => _TxtCheckoutTime;
            set => base.OnPropertyChanged(ref _TxtCheckoutTime, value);
        }

        private string _TxtSpecialArea;
        public string TxtSpecialArea
        {
            get => _TxtSpecialArea;
            set => base.OnPropertyChanged(ref _TxtSpecialArea, value);
        }

        private int _TxtReaderNo;
        public int TxtReaderNo
        {
            get => _TxtReaderNo;
            set => base.OnPropertyChanged(ref _TxtReaderNo, value);
        }

        private int _TxtIndexNo;
        public int TxtIndexNo
        {
            get => _TxtIndexNo;
            set => base.OnPropertyChanged(ref _TxtIndexNo, value);
        }

        private int _TxtSuitArea;
        public int TxtSuitArea
        {
            get => _TxtSuitArea;
            set => base.OnPropertyChanged(ref _TxtSuitArea, value);
        }

        //GuestCard Property
        private int _StaffCardSelectedIndex;
        public int StaffCardSelectedIndex
        {
            get => _StaffCardSelectedIndex;
            set => base.OnPropertyChanged(ref _StaffCardSelectedIndex, value);
        }

        private int _TxtStaffNo;
        public int TxtStaffNo
        {
            get => _TxtStaffNo;
            set => base.OnPropertyChanged(ref _TxtStaffNo, value);
        }

        private int _TxtExpireDateYear;
        public int TxtExpireDateYear
        {
            get => _TxtExpireDateYear;
            set => base.OnPropertyChanged(ref _TxtExpireDateYear, value);
        }

        private int _TxtExpireDateMonth;
        public int TxtExpireDateMonth
        {
            get => _TxtExpireDateMonth;
            set => base.OnPropertyChanged(ref _TxtExpireDateMonth, value);
        }

        private int _TxtExpireDateDay;
        public int TxtExpireDateDay
        {
            get => _TxtExpireDateDay;
            set => base.OnPropertyChanged(ref _TxtExpireDateDay, value);
        }

        private int _TxtWorkTime;
        public int TxtWorkTime
        {
            get => _TxtWorkTime;
            set => base.OnPropertyChanged(ref _TxtWorkTime, value);
        }

        private int _TxtStaffArea;
        public int TxtStaffArea
        {
            get => _TxtStaffArea;
            set => base.OnPropertyChanged(ref _TxtStaffArea, value);
        }

        //SystemCard Property
        private string _SystemCardSelectedIndex;
        public string SystemCardSelectedIndex
        {
            get => _SystemCardSelectedIndex;
            set => base.OnPropertyChanged(ref _SystemCardSelectedIndex, value);
        }

        private int _TxtSetDateTimeYear;
        public int TxtSetDateTimeYear
        {
            get => _TxtSetDateTimeYear;
            set => base.OnPropertyChanged(ref _TxtSetDateTimeYear, value);
        }

        private int _TxtSetDateTimeMonth;
        public int TxtSetDateTimeMonth
        {
            get => _TxtSetDateTimeMonth;
            set => base.OnPropertyChanged(ref _TxtSetDateTimeMonth, value);
        }

        private int _TxtSetDateTimeDay;
        public int TxtSetDateTimeDay
        {
            get => _TxtSetDateTimeDay;
            set => base.OnPropertyChanged(ref _TxtSetDateTimeDay, value);
        }

        private int _TxtSetDateTimeHour;
        public int TxtSetDateTimeHour
        {
            get => _TxtSetDateTimeHour;
            set => base.OnPropertyChanged(ref _TxtSetDateTimeHour, value);
        }

        private int _TxtSetDateTimeMinute;
        public int TxtSetDateTimeMinute
        {
            get => _TxtSetDateTimeMinute;
            set => base.OnPropertyChanged(ref _TxtSetDateTimeMinute, value);
        }

        private int _TxtSetDateTimeSecond;
        public int TxtSetDateTimeSecond
        {
            get => _TxtSetDateTimeSecond;
            set => base.OnPropertyChanged(ref _TxtSetDateTimeSecond, value);
        }

        private int _TxtSetReaderType;
        public int TxtSetReaderType
        {
            get => _TxtSetReaderType;
            set => base.OnPropertyChanged(ref _TxtSetReaderType, value);
        }

        private int _TxtSetMasterArea;
        public int TxtSetMasterArea
        {
            get => _TxtSetMasterArea;
            set => base.OnPropertyChanged(ref _TxtSetMasterArea, value);
        }

        private int _TxtSetMinibarArea;
        public int TxtSetMinibarArea
        {
            get => _TxtSetMinibarArea;
            set => base.OnPropertyChanged(ref _TxtSetMinibarArea, value);
        }

        private int _TxtSetReaderAddress;
        public int TxtSetReaderAddress
        {
            get => _TxtSetReaderAddress;
            set => base.OnPropertyChanged(ref _TxtSetReaderAddress, value);
        }

        private int _TxtSetSuitArea;
        public int TxtSetSuitArea
        {
            get => _TxtSetSuitArea;
            set => base.OnPropertyChanged(ref _TxtSetSuitArea, value);
        }

        private int _TxtSetMaidArea;
        public int TxtSetMaidArea
        {
            get => _TxtSetMaidArea;
            set => base.OnPropertyChanged(ref _TxtSetMaidArea, value);
        }

        private int _TxtSetSpecialArea;
        public int TxtSetSpecialArea
        {
            get => _TxtSetSpecialArea;
            set => base.OnPropertyChanged(ref _TxtSetSpecialArea, value);
        }

        private int _TxtSetGLED;
        public int TxtSetGLED
        {
            get => _TxtSetGLED;
            set => base.OnPropertyChanged(ref _TxtSetGLED, value);
        }

        private int _TxtSetStaffDND;
        public int TxtSetStaffDND
        {
            get => _TxtSetStaffDND;
            set => base.OnPropertyChanged(ref _TxtSetStaffDND, value);
        }

        private int _TxtSetLockType;
        public int TxtSetLockType
        {
            get => _TxtSetLockType;
            set => base.OnPropertyChanged(ref _TxtSetLockType, value);
        }

        private int _TxtSetOfficeMode;
        public int TxtSetOfficeMode
        {
            get => _TxtSetOfficeMode;
            set => base.OnPropertyChanged(ref _TxtSetOfficeMode, value);
        }

        private int _TxtConnectTime;
        public int TxtConnectTime
        {
            get => _TxtConnectTime;
            set => base.OnPropertyChanged(ref _TxtConnectTime, value);
        }*/
    }
}
