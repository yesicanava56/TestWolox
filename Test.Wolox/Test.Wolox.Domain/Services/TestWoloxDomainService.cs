using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Wolox.Data;
using Test.Wolox.Data.Repository;
using Test.Wolox.Domain.Entities;
using Test.Wolox.Models;

namespace Test.Wolox.Domain.Services
{
    public class TestWoloxDomainService : ITestWoloxDomainService
    {
        private readonly IUserClient UserClient;
        private readonly IUserRepository UserRepository;
        private readonly IPermitsRepository PermitsRepository;
        private readonly IConfiguration Configuration;
        public TestWoloxDomainService(IUserClient userClient, IUserRepository userRepository, 
            IPermitsRepository permitsRepository, IConfiguration configuration)
        {
            UserClient = userClient;
            UserRepository = userRepository;
            PermitsRepository = permitsRepository;
            Configuration = configuration;
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
        public List<User> GetUsersListDynamo()
        {
            List<User> productsExistent = new List<User>();
            try
            {
                Enumerators.QueryScanOperator Operator = 0;
                productsExistent = UserRepository.GetUser("prueba", Operator);
            }
            catch (Exception ex)
            {
                Console.Write($"Module:TestWolox, Class:TestWoloxDomainService.cs, Method:GetUsersListDynamo,Error: {ex}");
            }
            return productsExistent;
        }

        public List<Permission> GetPermission(string idUser, string idalbum)
        {
            List<Permission> productsExistent = new List<Permission>();
            try
            {
                Enumerators.QueryScanOperator Operator = 0;
                productsExistent = PermitsRepository.GetPermission(idUser, idalbum, Operator);
            }
            catch (Exception ex)
            {
                Console.Write($"Module:TestWolox, Class:TestWoloxDomainService.cs, Method:GetPermission,Error: {ex}");
                throw;
            }
            return productsExistent;
        }
        public List<Permission> GetPermissionUser(string idalbum)
        {
            List<Permission> productsExistent = new List<Permission>();
            try
            {
                Enumerators.QueryScanOperator Operator = 0;
                productsExistent = PermitsRepository.GetPermissionUser(idalbum, Operator);
            }
            catch (Exception ex)
            {
                Console.Write($"Module:TestWolox, Class:TestWoloxDomainService.cs, Method:GetPermissionUser,Error: {ex}");
                throw;
            }
            return productsExistent;
        }

        public bool RegisterPermission(Permission permits)
        {
            bool registesPermits = false;
            try
            {
                registesPermits = PermitsRepository.RegisterPermission(permits);
            }
            catch (Exception ex)
            {
                Console.Write($"Module:TestWolox, Class:TestWoloxDomainService.cs, Method:RegisterPermission,Error: {ex}");
                throw;
            }
            return registesPermits;
        }
        public bool UpdatePermission(Permission permits)
        {
            bool registesPermits = false;
            try
            {
                registesPermits = PermitsRepository.UpdatePermission(permits);
            }
            catch (Exception ex)
            {
                Console.Write($"Module:TestWolox, Class:TestWoloxDomainService.cs, Method:UpdatePermission,Error: {ex}");
                throw;
            }
            return registesPermits;
        }
        public List<Photos> GetPhotosUsersList()
        {
            List<Photos> response = new List<Photos>();
            Task<Response> responseGetPhotos = UserClient.GetPhotos();
            responseGetPhotos.Wait();
            if (responseGetPhotos.Result != null)
            {
                if (responseGetPhotos.Result.Errors.Count == 0)
                {
                    try
                    {
                        return JsonConvert.DeserializeObject<List<Photos>>(responseGetPhotos.Result.Data.ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.Write($"Module:TestWolox, Class:TestWoloxDomainService.cs, Method:GetPhotosUsersList,Error: {ex}");
                        throw new Exception(ex.Message);
                    }
                }
            }
            return response;
        }
        public List<albums> GetAlbumsList(string id)
        {
            List<albums> response = new List<albums>();
            Task<Response> responseGetAlbums = UserClient.GetAlbumsList(id);
            responseGetAlbums.Wait();
            if (responseGetAlbums.Result != null)
            {
                if (responseGetAlbums.Result.Errors.Count == 0)
                {
                    try
                    {
                        return JsonConvert.DeserializeObject<List<albums>>(responseGetAlbums.Result.Data.ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.Write($"Module:TestWolox, Class:TestWoloxDomainService.cs, Method:GetAlbumsList,Error: {ex}");
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
            string url = Configuration["Photos"] + "?";
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

        public List<PostComments> GetCommentsByIdUserName(string name, string userId)
        {
            List<Comment> comment = new List<Comment>();
            List<PostComments> postComments = new List<PostComments>();

            Task<Response> responsepostComments = UserClient.GetCommentsByIdUserName(name, userId);
            responsepostComments.Wait();
            if (responsepostComments.Result != null)
            {
                if (responsepostComments.Result.Errors.Count == 0)
                {
                    postComments = JsonConvert.DeserializeObject<List<PostComments>>(responsepostComments.Result.Data.ToString());
                }
            }
            string url = Configuration["Comment"];
            foreach (var postId in postComments)
            {
                url += "postId=" + postId.id + "&";
            }
            Task<Response> responseComments = UserClient.GetComment(url);
            responseComments.Wait();
            if (responseComments.Result != null)
            {
                if (responseComments.Result.Errors.Count == 0)
                {
                    comment = JsonConvert.DeserializeObject<List<Comment>>(responseComments.Result.Data.ToString());
                }
            }
            foreach (var item in postComments)
            {
                item.comment = new List<Comment>();
                item.comment = comment.Where(x => x.postId == item.id).ToList();
            }
            return postComments;
        }
    }
}
