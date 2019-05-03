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
        List<Permission> GetPermission(string idUser, string idalbum);
        bool RegisterPermission(Permission permits);
        bool UpdatePermission(Permission permits);
        List<Permission> GetPermissionUser(string idalbum);
        List<PostComments> GetCommentsByIdUserName(string name, string userId);
    }
}
