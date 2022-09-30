using Client.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Repository.Data
{
    public class GeneralRepository<entity> : IGeneralRepository<entity>
        where entity : class
    {
        private readonly string request;
        private readonly string address;
        private readonly IHttpContextAccessor _httpContextAccesor;
        private readonly HttpClient httpClient;
        public GeneralRepository(string request)
        {
            this.address = "https://localhost:44335/api/";
            this.request = request;
            _httpContextAccesor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address)
            };
        }
        public HttpStatusCode Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<entity> Get()
        {
            throw new NotImplementedException();
        }
        public List<entity> GetAll()
        {
            List<entity> entities = new List<entity>();
            var responTask = httpClient.GetAsync(request);
            var result = responTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var resultJsonString = result.Content.ReadAsStringAsync();
                resultJsonString.Wait();
                JObject rss = JObject.Parse(resultJsonString.Result);
                JArray data = (JArray)rss["data"];
                entities = JsonConvert.DeserializeObject<List<entity>>((JsonConvert.SerializeObject(data)));
            }

            return entities;
        }
        public HttpStatusCode Post(entity entity)
        {
            throw new NotImplementedException();
        }

        public HttpStatusCode Put(int id, entity entity)
        {
            throw new NotImplementedException();
        }
    }
}
