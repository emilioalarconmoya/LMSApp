namespace LMSApp.Services
{
    using LMSApp.Common.Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    public class ApiService
    {
        public async Task<Response> GetList<T>(string urlBase, string prefix, string controller)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var url = $"{prefix}{controller}"; //concateno la url
                var response = await client.GetAsync(url);
                var answer = await response.Content.ReadAsStringAsync();
                if(!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSucces = false,
                        Message = answer,
                    };
                }

                var list = JsonConvert.DeserializeObject<List<T>>(answer);
                return new Response
                {
                    IsSucces = true,
                    Result = list,
                };

            }
            catch(Exception ex)
            {
                return new Response
                {
                    IsSucces = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
