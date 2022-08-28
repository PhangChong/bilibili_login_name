using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace test
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //int i = 0;
            //int a = 0;
            int a = -1;
            int b = -1;


            string[] A = {"十百","十千","十万","十十万","十百万","十千万","十亿","十筒","十饼","十条","一百","一千","一万","一十万","一百万","一千万","一亿","一筒","一饼","一条","二百","二千","二万","二十万","二百万","二千万","二亿","二筒","二饼","二条","三百","三千","三万","三十万","三百万","三千万","三亿","三筒","三饼","三条","四百","四千","四万","四十万","四百万","四千万","四亿","四筒","四饼","四条","五百","五千","五万","五十万","五百万","五千万","五亿","五筒","五饼","五条","六百","六千","六万","六十万","六百万","六千万","六亿","六筒","六饼","六条","七百","七千","七万","七十万","七百万","七千万","七亿","七筒","七饼","七条","八百","八千","八万","八十万","八百万","八千万","八亿","八筒","八饼","八条","九百","九千","九万","九十万","九百万","九千万","九亿","九筒","九饼","九条"};
            ArrayList B = new ArrayList();
            Console.WriteLine(A.Length);
            for (int i = 0; i < A.Length; i++)
            {
                a++;


                //我们的接口
                string url = "http://passport.bilibili.com/web/generic/check/nickname?nickName=" +
                A[a];

                //将接口传入
                string getJson = HttpUitls.Get(url);

                Console.WriteLine("查询：" + A[a] + "         " + getJson);
                //Console.WriteLine("{\"code\":0}");
                if (getJson == "{\"code\":0}")
                {
                    B.Add(A[a]);
                }
            }
            Console.WriteLine(" ");
            for (int i = 0; i < B.Count; i++)
            {
                b++;

                Console.WriteLine("可使用"+B[b]);
            }
            B.Clear();
            Console.ReadLine();

        }



        public class HttpUitls
        {
            public static string Get(string Url)
            {
                //System.GC.Collect();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Proxy = null;
                request.KeepAlive = false;
                request.Method = "GET";
                request.ContentType = "application/json; charset=UTF-8";
                request.AutomaticDecompression = DecompressionMethods.GZip;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
                string retString = myStreamReader.ReadToEnd();

                myStreamReader.Close();
                myResponseStream.Close();

                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }

                return retString;
            }

            public static string Post(string Url, string Data, string Referer)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "POST";
                request.Referer = Referer;
                byte[] bytes = Encoding.UTF8.GetBytes(Data);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = bytes.Length;
                Stream myResponseStream = request.GetRequestStream();
                myResponseStream.Write(bytes, 0, bytes.Length);

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string retString = myStreamReader.ReadToEnd();

                myStreamReader.Close();
                myResponseStream.Close();

                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
                return retString;
            }


        }
    }



}
