using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.Wolox.Models;

namespace Test.Wolox.Data
{
    public interface IUserClient
    {
        Task<Response> GetUsers();
        Task<Response> GetPhotos();
        Task<Response> GetAlbumsList(string id);
        Task<Response> GetPhotosByAlbum(string id);
    }
}
