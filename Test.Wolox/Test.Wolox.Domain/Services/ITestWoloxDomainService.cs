using System;
using System.Collections.Generic;
using System.Text;
using Test.Wolox.Domain.Entities;
using Test.Wolox.Models;

namespace Test.Wolox.Domain.Services
{
    public interface ITestWoloxDomainService
    {
        List<User> GetUsersList();
        List<Photos> GetPhotosUsersList();
        List<albums> GetAlbumsList(string id);
        List<albumsPhothos> GetPhotosAlbumsByIdUser(string idUser);
        List<User> GetUsersListDynamo();
        List<Permits> GetPermission(string idUser, string idalbum);
    }
}
