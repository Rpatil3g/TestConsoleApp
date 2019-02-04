using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConnectTFS
{
    public class ConnectTFS
    {
        private static readonly HttpClient _Client = new HttpClient();
        //  private static JavaScriptSerializer _Serializer = new JavaScriptSerializer();

       public  string GetBuildDependentRunId(string URL)
        {
            string retResponse = null;
            try
            {
                string url = URL;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    retResponse= reader.ReadToEnd();
                }

            }
            catch (Exception ex)
            {
                retResponse = ex.Message;
            }

            return retResponse;
        }

      
        /// <summary>
        /// Makes an async HTTP Request
        /// </summary>
        /// <param name="pMethod">Those methods you know: GET, POST, HEAD, etc...</param>
        /// <param name="pUrl">Very predictable...</param>
        /// <param name="pJsonContent">String data to POST on the server</param>
        /// <param name="pHeaders">If you use some kind of Authorization you should use this</param>
        /// <returns></returns>
        static async Task<HttpResponseMessage> Request(HttpMethod pMethod, string pUrl, string pJsonContent, Dictionary<string, string> pHeaders)
        {
            var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = pMethod;
            httpRequestMessage.RequestUri = new Uri(pUrl);
            foreach (var head in pHeaders)
            {
                httpRequestMessage.Headers.Add(head.Key, head.Value);
            }
            switch (pMethod.Method)
            {
                case "GET":
                    HttpContent httpContent = new StringContent(pJsonContent, Encoding.UTF8, "application/json");
                   // httpRequestMessage.Content = httpContent;
                    break;

            }

            return await _Client.SendAsync(httpRequestMessage);
        }
    }
}
