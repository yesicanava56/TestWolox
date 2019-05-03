using System;
using System.Collections.Generic;
using System.Text;
using Test.Wolox.Domain.Entities;
using Test.Wolox.Models;

namespace Test.Wolox.Application.Services
{
    public interface ITestWoloxApplicationService
    {
        ResponseViewModel GetUsersList();
        ResponseViewModel GetPhotosUsersList();
        ResponseViewModel GetAlbumsList( string id);
        ResponseViewModel GetPhotosAlbumsByIdUser(string id);
        ResponseViewModel GetPermission(string idUser, string idalbum);
        ResponseViewModel RegisterPermission(Permission Permission);
        ResponseViewModel UpdatePermission(Permission Permission);
        ResponseViewModel GetPermissionUser(string idalbum);
        ResponseViewModel GetCommentsByIdUserName(string name, string userId);

    }
}
