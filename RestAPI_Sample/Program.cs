using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RestAPI_Sample
{
    public class Program
    {
        static string apiURL = "http://data.ex.co.kr/openapi/safeDriving/forecast?key=test&type=json";

        static void Main(string[] args)
        {
            string webClientResult = callWebClient();

            var r = JObject.Parse(webClientResult);

            var list = r["list"];

            //Console.WriteLine(r);

            foreach(var o in list)
            {
                Console.WriteLine(string.Format("{0} : {1}", "날짜", o["sdate"]));
                Console.WriteLine(string.Format("{0} : {1}", "전국교통량", o["cjunkook"]));
                Console.WriteLine(string.Format("{0} : {1}", "지방교통량", o["cjibangDir"]));
                Console.WriteLine(string.Format("{0} : {1}", "서울->대전 소요시간", o["csudj"]));
                Console.WriteLine(string.Format("{0} : {1}", "서울->대구 소요시간", o["csudg"]));
                Console.WriteLine(string.Format("{0} : {1}", "서울->울산 소요시간", o["csuus"]));
            }

            Console.ReadKey();
        }

        public static string callWebClient() //웹페이지 접속 및 크롤링 #1 
        {
            string result = string.Empty;

            try
            {
                WebClient client = new WebClient();
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

                using (Stream data = client.OpenRead(apiURL))
                {
                    using (StreamReader reader = new StreamReader(data))
                    {
                        result = reader.ReadToEnd();

                        reader.Close();
                        data.Close();
                    }
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }

            return result;
        }

        public static string callWebRequest() //웹페이지 접속 및 크롤링 #2 
        {
            string responseFromServer = string.Empty;

            try
            {
                WebRequest request = WebRequest.Create(apiURL);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Headers["user-agent"] = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";

                using (WebResponse response = request.GetResponse())
                using (Stream dataStream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(dataStream))
                {
                    responseFromServer = reader.ReadToEnd();
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }

            return responseFromServer;
        }
    }
}
