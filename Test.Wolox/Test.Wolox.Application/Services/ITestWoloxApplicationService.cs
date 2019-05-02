using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
