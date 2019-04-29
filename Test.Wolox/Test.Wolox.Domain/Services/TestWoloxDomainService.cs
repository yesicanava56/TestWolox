using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Wolox.Data;
using Test.Wolox.Domain.Entities;
using Test.Wolox.Models;

namespace Test.Wolox.Domain.Services
{
    public class TestWoloxDomainService : ITestWoloxDomainService
    {
        private readonly IUserClient UserClient;
        public TestWoloxDomainService(IUserClient userClient)
        {
            UserClient = userClient;
        }
        public List<User> GetUsersList()
        {
            List<User> response = new List<User>();
            Task<Response> responseGetUser = UserClient.GetUsers();
            responseGetUser.Wait();

            if (responseGetUser.Result != null)
            {
                if (responseGetUser.Result.Errors.Count == 0)
                {
                    try
                    {
                        return JsonConvert.DeserializeObject<List<User>>(responseGetUser.Result.Data.ToString());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }

            return response;
        }
        public List<Photos> GetPhotosUsersList()
        {
            List<Photos> response = new List<Photos>();
            Task<Response> responseGetUser = UserClient.GetPhotos();
            responseGetUser.Wait();

            if (responseGetUser.Result != null)
            {
                if (responseGetUser.Result.Errors.Count == 0)
                {
                    try
                    {
                        return JsonConvert.DeserializeObject<List<Photos>>(responseGetUser.Result.Data.ToString());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }

            return response;
        }
        public List<albums> GetAlbumsList(string id)
        {
            List<albums> response = new List<albums>();
            Task<Response> responseGetUser = UserClient.GetAlbumsList(id);
            responseGetUser.Wait();
            if (responseGetUser.Result != null)
            {
                if (responseGetUser.Result.Errors.Count == 0)
                {
                    try
                    {
                        return JsonConvert.DeserializeObject<List<albums>>(responseGetUser.Result.Data.ToString());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
            return response;
        }
        public List<albumsPhothos> GetPhotosAlbumsByIdUser(string idUser)
        {
            List<Photos> photos = new List<Photos>();
            List<albumsPhothos> albumphotos = new List<albumsPhothos>();

            Task<Response> responseAlbums = UserClient.GetAlbumsList(idUser);
            responseAlbums.Wait();
            if (responseAlbums.Result != null)
            {
                if (responseAlbums.Result.Errors.Count == 0)
                {
                    albumphotos =  JsonConvert.DeserializeObject<List<albumsPhothos>>(responseAlbums.Result.Data.ToString());
                }
            }
            string url = "https://jsonplaceholder.typicode.com/photos?";
            foreach (var idAlbum in albumphotos)
            {
                url+= "albumId=" + idAlbum.id + "&";
            }
            Task<Response> responsePhotos = UserClient.GetPhotosByAlbum(url);
            responsePhotos.Wait();
            if (responsePhotos.Result != null)
            {
                if (responsePhotos.Result.Errors.Count == 0)
                {
                    photos = JsonConvert.DeserializeObject<List<Photos>>(responsePhotos.Result.Data.ToString());
                }
            }
            foreach (var item in albumphotos)
            {
                item.photos = new List<Photos>();
                item.photos = photos.Where(x => x.albumId == item.id).ToList();
            }
            return albumphotos;
        }
        
    }
}
