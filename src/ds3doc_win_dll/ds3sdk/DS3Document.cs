using System.IO;
using RestSharp;
using System;
using Newtonsoft.Json;

namespace ds3sdk
{
    public class DS3Document
    {
        private DS3Server ApiServer;
        public string ErrorMessage { get; set; }

        public DS3Document()
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

        public string Create(string jsonString)
        {
            try
            {
                ApiServer.clientRequest = new RestRequest();
                ApiServer.clientRequest.AddHeader("Authorization", "Token token=" + ApiServer.Token);
                ApiServer.clientRequest.AddHeader("Content-Type", "application/json");
                ApiServer.clientRequest.AddHeader("cache-control", "no-cache");
                ApiServer.clientRequest.Timeout = -1;

                ApiServer.clientRequest.Method = Method.POST;
                ApiServer.clientRequest.Resource = "doc_types/documents/create";
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
                ApiServer.clientRequest.Resource = "doc_types/documents/search";
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

        public string Update(string jsonString)
        {
            try
            {
                ApiServer.clientRequest = new RestRequest();
                ApiServer.clientRequest.AddHeader("Authorization", "Token token=" + ApiServer.Token);
                ApiServer.clientRequest.AddHeader("Content-Type", "application/json");
                ApiServer.clientRequest.AddHeader("cache-control", "no-cache");
                ApiServer.clientRequest.Timeout = -1;

                ApiServer.clientRequest.Method = Method.POST;
                ApiServer.clientRequest.Resource = "doc_types/documents/update";
                ApiServer.clientRequest.AddParameter("application/json", jsonString, ParameterType.RequestBody);
                ApiServer.clientResponse = ApiServer.clientWS.Execute(ApiServer.clientRequest);

                //se nenhum erro aconteceu
                if (ApiServer.clientResponse.ResponseStatus == ResponseStatus.Completed 
                    && ApiServer.clientResponse.StatusCode != System.Net.HttpStatusCode.InternalServerError
                    && ApiServer.clientResponse.ErrorMessage == null)
                {
                    return ApiServer.clientResponse.Content;
                }
                else
                {
                    this.ErrorMessage = string.IsNullOrEmpty(ApiServer.clientResponse.ErrorMessage) ? ApiServer.clientResponse.StatusDescription : ApiServer.clientResponse.ErrorMessage;
                    return @"{status:'ERROR', message:'Api call error: " + this.ErrorMessage + "', data: {}}";
                }

            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
                return @"{status:'ERROR', message:'Api call error: " + ex.Message + " ' , data: {}}";
            }

        }
        
        public string Delete(string jsonString)
        {
            try
            {
                ApiServer.clientRequest = new RestRequest();
                ApiServer.clientRequest.AddHeader("Authorization", "Token token=" + ApiServer.Token);
                ApiServer.clientRequest.AddHeader("Content-Type", "application/json");
                ApiServer.clientRequest.AddHeader("cache-control", "no-cache");
                ApiServer.clientRequest.Timeout = -1;

                ApiServer.clientRequest.Method = Method.POST;
                ApiServer.clientRequest.Resource = "doc_types/documents/delete";
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
