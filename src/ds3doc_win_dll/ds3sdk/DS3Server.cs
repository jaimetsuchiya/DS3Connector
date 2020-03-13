using System;
using RestSharp;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Configuration;
//using System.Text.Json;

namespace ds3sdk
{
    class DS3Server
    {
        public RestClient clientWS;
        public RestRequest clientRequest;
        public IRestResponse clientResponse;

        public string Token { get; set; }
        public string ApiServerUrl { get; set; }

        public string AppDir { get; set; }

        public DS3Server()
        {

            //this.AppDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
            //string inputFileName = this.AppDir + @"\ds3doc.json";

            //string jsonString = File.ReadAllText(inputFileName);
            ApiConfig mConfig = new ApiConfig()
            {
                token = ConfigurationManager.AppSettings["DS3Doc.Token"],
                apiserver = ConfigurationManager.AppSettings["DS3Doc.ServiceURL"]
            }; /*JsonConvert.DeserializeObject<ApiConfig>(jsonString);*/

            this.Token = mConfig.token;
            this.ApiServerUrl = mConfig.apiserver;
            this.clientWS = new RestClient(this.ApiServerUrl);

        }


    }
    public class ApiConfig
    {
        public string token { get; set; }
        public string apiserver { get; set; }
    }
}
