using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Test.Wolox.Models;

namespace Test.Wolox.Data
{
    public class UserClient : IUserClient
    {
        private readonly IConfiguration Configuration;
        public UserClient(IConfiguration configuration) {
            Configuration = configuration;
        }
        public async Task<Response> GetUsers()
        {
            Response Response = new Response();
            try
            {
                var request = WebRequest.Create(Configuration["Users"]);
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";
                request.Timeout = 3000000;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    return BuildResponse(response);
                }
            }
            catch (Exception ex)
            {
                Console.Write($"Module:TestWolox, Class:UserClient.cs, Method:GetUsers, Error: {ex}");
            }
            return Response;
        }
        public async Task<Response> GetPhotos()
        {
            Response Response = new Response();
            try
            {
                var request = WebRequest.Create(Configuration["Photos"]);
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";
                request.Timeout = 3000000;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    return BuildResponse(response);
                }
            }
            catch (Exception ex)
            {
                Console.Write($"Module:TestWolox, Class:UserClient.cs, Method:GetPhotos, Error: {ex}");
            }
            return Response;
        }
        public async Task<Response> GetAlbumsList(string id)
        {
            Response Response = new Response();
            try
            {
                string url = id != null ? Configuration["albums"] + "/albums?userId=" + id  : Configuration["albums"];
                var request = WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";
                request.Timeout = 3000000;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    return BuildResponse(response);
                }
            }
            catch (Exception ex)
            {
                Console.Write($"Module:TestWolox, Class:UserClient.cs, Method:GetPhotos, Error: {ex}");
            }
            return Response;
        }

        public async Task<Response> GetCommentsByIdUserName(string name, string userId)
        {
            Response Response = new Response();
            try
            {
                string url = userId != null ? Configuration["Post"] + "?userId=" + userId : Configuration["Post"];
                var request = WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";
                request.Timeout = 3000000;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    return BuildResponse(response);
                }
            }
            catch (Exception ex)
            {
                Console.Write($"Module:TestWolox, Class:UserClient.cs, Method:GetCommentsByIdUserName, Error: {ex}");
            }
            return Response;
        }

        public async Task<Response> GetPhotosByAlbum(string url)
        {
            Response Response = new Response();
            try
            {
                var request = WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";
                request.Timeout = 3000000;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    return BuildResponse(response);
                }
            }
            catch (Exception ex)
            {
                Console.Write($"Module:TestWolox, Class:UserClient.cs, Method:GetPhotos, Error: {ex}");
            }
            return Response;
        }

        public async Task<Response> GetComment(string url)
        {
            Response Response = new Response();
            try
            {
                var request = WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";
                request.Timeout = 3000000;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    return BuildResponse(response);
                }
            }
            catch (Exception ex)
            {
                Console.Write($"Module:TestWolox, Class:UserClient.cs, Method:GetPhotos, Error: {ex}");
            }
            return Response;
        }
        private static Response BuildResponse(HttpWebResponse httpResponse)
        {
            try
            {
                using (StreamReader reader = new StreamReader(
                    httpResponse.GetResponseStream(), Encoding.UTF8, true))
                {
                    var content = reader.ReadToEnd();
                    var response = new Response()
                    {
                        Data = content,
                    };
                    return response;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }
    }
}
