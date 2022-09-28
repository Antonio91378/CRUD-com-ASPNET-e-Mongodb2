using API.Blog.BackEnd.Domain.Entities;
using API.Blog.BackEnd.Domain.Interfaces;
using API.Blog.BackEnd.Infra.Integrations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Blog.BackEnd.Service
{

    public class CommentService : ICommentService
    {
        private readonly IIntegrationApiImageUploader _imageUploader;
        private readonly IHttpClientFactory _httpClientFactory;

        public CommentService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _imageUploader =new IntegrationApiImageUploader(_httpClientFactory);
        }
        public async Task<string> FazerUploadDeImagem(IFormFile arquivo)
        {
            return await _imageUploader.FazerUpload(arquivo);
        }
    }
}
