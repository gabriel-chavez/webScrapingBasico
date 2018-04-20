using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net;
using HAP = HtmlAgilityPack;

namespace webscraping
{
    class Program
    {
        static void Main(string[] args)
        {
            ///*******Proxy defecto windows********/
            IWebProxy defaultWebProxy = WebRequest.DefaultWebProxy;
            defaultWebProxy.Credentials = CredentialCache.DefaultCredentials;
            ///***************************************/
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://www.yellowpages.com/search?search_terms=software&geo_location_terms=4+La+Paz%2C+Big+Bear%2C+CA");
            var headerNames = doc.DocumentNode
                .SelectNodes("//a[@class='business-name']").ToList();
            foreach(var item in headerNames)
            {
                Console.WriteLine(item.InnerText);
            }
            


            /****************************/
            /*        IMPORTANTE        */
            /****************************/

            ///******proxy configuracion****/
            //  WebProxy p = new WebProxy("10.9.0.182:8080", true);
            //  p.Credentials = new NetworkCredential("bsol\\lchavez", "Abril123456");
            //  WebRequest.DefaultWebProxy = p;
            ///****************************/
            ///*******Proxy defecto windows********/
            //IWebProxy defaultWebProxy = WebRequest.DefaultWebProxy;
            //defaultWebProxy.Credentials = CredentialCache.DefaultCredentials;
            ///***************************************/
            ////La Siguiente linea resuelve el error para: “No se puede crear un canal seguro SSL/ TLS”            
            //System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            //using (var client = new System.Net.WebClient())
            //{
            //    /*******Proxy*****/
            //    client.Proxy = defaultWebProxy;
            //    /***************/
            //    var filename = System.IO.Path.GetTempFileName();

            //    client.DownloadFile("http://python.org", filename);

            //    var doc = new HAP.HtmlDocument();
            //    doc.Load(filename);

            //    var root = doc.DocumentNode;

            //    var a_nodes = root.Descendants("a").ToList();

            //    foreach (var a_node in a_nodes)
            //    {
            //        Console.WriteLine();
            //        Console.WriteLine("LINK: {0}", a_node.GetAttributeValue("href", ""));
            //        Console.WriteLine("TEXT: {0}", a_node.InnerText.Trim());
            //    }
            //}

            Console.ReadKey();
        }
       
    }
}
