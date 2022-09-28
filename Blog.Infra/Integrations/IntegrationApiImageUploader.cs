using API.Blog.BackEnd.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Blog.BackEnd.Domain.Entities;
using Blog.Utils;

namespace API.Blog.BackEnd.Infra.Integrations
{
    public class IntegrationApiImageUploader : IIntegrationApiImageUploader
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public IntegrationApiImageUploader(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> FazerUpload(IFormFile arquivo)
        {
            var integrationApiImageUploaderSettings = new IntegrationApiImageUploaderSettings();
            integrationApiImageUploaderSettings.UriBase = ApplicationSettings.GetForeingApi();
            try
            {
                HttpClient httpClient = _httpClientFactory.CreateClient();
                httpClient.BaseAddress = new Uri(integrationApiImageUploaderSettings.UriBase);
                string endpoint = $"Image/upload";

                if(arquivo is not null)
                {
                    endpoint += $"?arquivo={arquivo}";
                }

                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, endpoint);
                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    string contentStream = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    return contentStream;
                }
            }
            catch (Exception)
            {

                throw;
            }
            throw new Exception();
        }
    }
}
