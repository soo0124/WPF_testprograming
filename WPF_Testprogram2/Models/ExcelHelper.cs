using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WPF_Testprogram2.Models
{
    public class ExcelHelper
    {
        private Application _Application;
        private Workbook _Workbook;
        private Worksheet _Worksheet;

        //엑셀파일 열기
        public bool OpenExcelFile(string filePath, string saveFilePath, string sheet)
        {
            bool result = false;

            try
            {
                if(!File.Exists(filePath))
                {
                    return result;
                }

                File.Copy(filePath, saveFilePath);

                _Application = new Application(); //Excel 프로그램 실행
                _Workbook = _Application.Workbooks.Open(saveFilePath); //Excel 파일 연다.
                _Worksheet = _Workbook.Worksheets.Item[sheet];//특정시트를 연다.

                result = true;
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }

            return result;
        }
    
        //엑셀시트의 정보 불러오기
        public List<BulkItem> GetExcelSheet()
        {
            List<BulkItem> bulkList = new List<BulkItem>();

            try
            {
                int rowCount = Convert.ToInt32((_Worksheet.Cells[2, 2] as Range).Value2.ToString());
                int iExecutionOrder = 1;

                //실행순서 컬럼 위치 찾기
                while((_Worksheet.Cells[1, iExecutionOrder] as Range).Value2.ToString() != "실행순서" || iExecutionOrder > 100)
                {
                    iExecutionOrder++;
                }

                for(int i = 2; (i<rowCount || i <300); i++)
                {
                    if (_Worksheet.Cells[i, iExecutionOrder] != null &&
                        _Worksheet.Cells[i, iExecutionOrder].Value2 != null)
                    {
                        bulkList.Add(new BulkItem()
                        {
                            //실행순서
                            sequence = Convert.ToInt32(_Worksheet.Cells[i, iExecutionOrder].Value2.ToString()),

                            Output_Column = iExecutionOrder + 1,
                            Output_Row = i,

                            Input_Value = _Worksheet.Cells[i, iExecutionOrder - 1].Value2.ToString(),
                        });
                    }
                }

                bulkList.OrderBy(x => x.sequence);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }

            return bulkList;
        }
    
        //엑셀 셀 편집하기
        public void SetExcelSheet(BulkItem bulkItem, string data)
        {
            try
            {
                _Worksheet.Cells[bulkItem.Output_Row, bulkItem.Output_Column].Value =  data;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        public bool SaveExcelFile()
        {
            bool result = false;

            try
            {
                _Workbook.Save();
                result = true;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool ExitExcelFile()
        {
            bool result = false;

            try
            {
                _Application.Quit();
                result = true;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}
