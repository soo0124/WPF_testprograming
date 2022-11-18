using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_PDF
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //PDF 파일 저장 경로
            string filePath = $@"C:\Users\swjang\Test_{DateTime.Now:yy-MM-dd_HHmmss}.pdf";

            const int colcount = 4;

            var list = MySqlHelper.ExecuteDataset(
                "Server=127.0.0.1;" +
                "Port=3306;" +
                "User=root;" +
                "Pwd=racos5117",
                "SELECT * FROM encoder.commlog WHERE 1=1;").Tables[0];

            // user's customizing
            DataTable dt = new DataTable();
            dt.Columns.Add("NUMBER");
            dt.Columns.Add("EVENT TIME");
            dt.Columns.Add("TX/RX");
            dt.Columns.Add("PACKET");

            foreach (DataRow item in list.Rows)
            {
                dt.Rows.Add(
                    item["No"],
                    item["EventDateTime"],
                    item["Division"],
                    item["Packet"]
                    );
            }

            PdfPTable pdf = new PdfPTable(colcount);
            pdf.DefaultCell.Padding = 7;
            pdf.WidthPercentage = 100;
            pdf.HorizontalAlignment = Element.ALIGN_CENTER;

            //
            for (int i = 0; i < colcount; i++)
            {
                PdfPCell cell = new PdfPCell(new Phrase(dt.Columns[i].ColumnName));

                pdf.AddCell(cell);
            }

            foreach (DataRow row in dt.Rows)
            {
                foreach (var rowCount in row.ItemArray)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(rowCount.ToString()));

                    pdf.AddCell(cell);
                }
            }

            //using? 여기 내에서만 사용하겠다.
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                Document document = new Document(new RectangleReadOnly(842F, 595F), 20f, 20f, 20f, 20f);

                // 문서 사이즈, 파일 정보
                PdfWriter.GetInstance(document, stream);
                document.Open();
                document.Add(pdf);
                document.Close();
            }
        }
    }
}
