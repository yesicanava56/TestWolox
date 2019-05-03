using System;
using System.Collections.Generic;
using System.Text;
using Test.Wolox.Domain.Entities;
using Test.Wolox.Domain.Services;
using Test.Wolox.Models;

namespace Test.Wolox.Application.Services
{
    public class TestWoloxApplicationService: ITestWoloxApplicationService
    {
        private readonly ITestWoloxDomainService TestWoloxDomainService;

        public TestWoloxApplicationService(ITestWoloxDomainService testWoloxDomainService)
        {
            TestWoloxDomainService = testWoloxDomainService;
        }

        public ResponseViewModel GetUsersList()
        {
            return new ResponseViewModel()
            {
                Message = "Operación realizada con éxito.",
                Data = TestWoloxDomainService.GetUsersList()
            };
        }
        public ResponseViewModel GetPhotosUsersList()
        {
            return new ResponseViewModel()
            {
                Message = "Operación realizada con éxito.",
                Data = TestWoloxDomainService.GetPhotosUsersList()
            };
        }
        public ResponseViewModel GetAlbumsList(string id)
        {
            return new ResponseViewModel()
            {
                Message = "Operación realizada con éxito.",
                Data = TestWoloxDomainService.GetAlbumsList(id)
            };
        }
        public ResponseViewModel GetPhotosAlbumsByIdUser(string idUser)
        {
            return new ResponseViewModel()
            {
                Message = "Operación realizada con éxito.",
                Data = TestWoloxDomainService.GetPhotosAlbumsByIdUser(idUser)
            };
        }
        public ResponseViewModel GetPermission(string idUser, string idalbum)
        {
            return new ResponseViewModel()
            {
                Message = "Operación realizada con éxito.",
                Data = TestWoloxDomainService.GetPermission(idUser, idalbum)
            };
        }
        public ResponseViewModel GetPermissionUser(string idalbum)
        {
            return new ResponseViewModel()
            {
                Message = "Operación realizada con éxito.",
                Data = TestWoloxDomainService.GetPermissionUser(idalbum)
            };
        }
        

        public ResponseViewModel RegisterPermission(Permission Permission)
        {
            return new ResponseViewModel()
            {
                Message = "Operación realizada con éxito.",
                Data = TestWoloxDomainService.RegisterPermission(Permission)
            };
        }
        public ResponseViewModel UpdatePermission(Permission Permission)
        {
            return new ResponseViewModel()
            {
                Message = "Operación realizada con éxito.",
                Data = TestWoloxDomainService.UpdatePermission(Permission)
            };
        }
        public ResponseViewModel GetCommentsByIdUserName(string name, string userId)
        {
            return new ResponseViewModel()
            {
                Message = "Operación realizada con éxito.",
                Data = TestWoloxDomainService.GetCommentsByIdUserName(name, userId)
            };
        }
        

    }
}
