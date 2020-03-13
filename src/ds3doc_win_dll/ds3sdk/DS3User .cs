using System.IO;
using RestSharp;
using System;
using Newtonsoft.Json;

namespace ds3sdk
{
    public class DS3User
    {
        private DS3Server ApiServer;
        public string ErrorMessage { get; set; }

        public DS3User()
        {
            try
            {
                ApiServer = new DS3Server();
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
            }
        }

        public string Search(string jsonString)
        {
            try
            {
                ApiServer.clientRequest = new RestRequest();
                ApiServer.clientRequest.AddHeader("Authorization", "Token token=" + ApiServer.Token);
                ApiServer.clientRequest.AddHeader("Content-Type", "application/json");
                ApiServer.clientRequest.AddHeader("cache-control", "no-cache");
                ApiServer.clientRequest.Timeout = -1;


                ApiServer.clientRequest.Method = Method.POST;
                ApiServer.clientRequest.Resource = "users/search";
                ApiServer.clientRequest.AddParameter("application/json", jsonString, ParameterType.RequestBody);
                ApiServer.clientResponse = ApiServer.clientWS.Execute(ApiServer.clientRequest);

                //se nenhum erro aconteceu
                if (ApiServer.clientResponse.ErrorMessage == null)
                {
                    return ApiServer.clientResponse.Content;
                }
                else
                {
                    this.ErrorMessage = ApiServer.clientResponse.ErrorMessage;
                    return @"{status:'ERROR', message:'Api call error: " + ApiServer.clientResponse.ErrorMessage + "', data: {}}";
                }

            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
                return @"{status:'ERROR', message:'Api call error: " + ex.Message + " ' , data: {}}";
            }

        }
    }
}
