﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConnectTFS
{
    public class ConnectTFS
    {
        private static readonly HttpClient _Client = new HttpClient();
        private string jsonResponce = string.Empty;
        //  private static JavaScriptSerializer _Serializer = new JavaScriptSerializer();

        public string GetRunIdUsingBuildNum(string URL)
        {
            try
            {
                getResponce(URL);
                dynamic deseriliesJson = JsonConvert.DeserializeObject(this.jsonResponce);
                Console.WriteLine(deseriliesJson);
                string aa = deseriliesJson.value[0].id;

                return aa;
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }


        /// <summary>
        /// Makes an async HTTP Request
        /// </summary>
        /// <param name="pMethod">Those methods you know: GET, POST, HEAD, etc...</param>
        /// <param name="pUrl">Very predictable...</param>
        /// <param name="pJsonContent">String data to POST on the server</param>
        /// <param name="pHeaders">If you use some kind of Authorization you should use this</param>
        /// <returns></returns>
        public   void getResponce(string uri)
        {
            string responseBody = ""; 
            try
            {
                //this token for my localhost
                //var personalaccesstoken = "rchud3hpendkhjjl7ylesg7a3n3ixyyucyzdfgtmcb37mpjxznqa";

                //this for nikhil tfs 2018
                var personalaccesstoken = "yfl3srrgettcxigddcmkdjsz5cgzx4onxd2wlrvzvk6ri34rrwcq";

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                        Convert.ToBase64String(
                            System.Text.ASCIIEncoding.ASCII.GetBytes(
                                string.Format("{0}:{1}", "", personalaccesstoken))));

                    using (HttpResponseMessage response = client.GetAsync(
                                uri).Result)
                    {
                        response.EnsureSuccessStatusCode();
                         responseBody =  response.Content.ReadAsStringAsync().Result;
                        
                        Console.WriteLine(responseBody);
                    }
                }

                this.jsonResponce = responseBody;
            }
            catch (Exception ex)
            {
                this.jsonResponce = ex.Message;
                Console.WriteLine(ex.ToString());
            }

          
        }
    }
}
