using System;
using Microsoft.AspNetCore.Mvc;
using Test.Wolox.Application.Services;

namespace Test.Wolox.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/testwolox")]

    public class TestWoloxController : Controller
    {
        private readonly ITestWoloxApplicationService WoloxApplication;

        public TestWoloxController(ITestWoloxApplicationService woloxApplication)
        {
            WoloxApplication = woloxApplication;
        }

        [Route("getuserslist")]
        public IActionResult GetUsersList()
        {
            try
            {
                return Ok(WoloxApplication.GetUsersList());
            }
            catch (Exception ex)
            {
                Console.Write($"Module:TestWolox, Class:TestWoloxController.cs, Method:GetUsersList,Error: {ex}");
                return StatusCode(400);
            }
        }
        [Route("getphotosuserslist")]
        public IActionResult GetPhotosUsersList()
        {
            try
            {
                return Ok(WoloxApplication.GetPhotosUsersList());
            }
            catch (Exception ex)
            {
                Console.Write($"Module:TestWolox, Class:TestWoloxController.cs, Method:GetPhotosUsersList,Error: {ex}");
                return StatusCode(400);
            }
        }

        [HttpGet("/api/testwolox/getalbumslist/{id?}", Name = "getalbumslist")]
        public IActionResult GetAlbumsList(string id)
        {
            try
            {
                return Ok(WoloxApplication.GetAlbumsList(id));
            }
            catch (Exception ex)
            {
                Console.Write($"Module:TestWolox, Class:TestWoloxController.cs, Method:getalbumslist,Error: {ex}");
                return StatusCode(400);
            }
        }

        [HttpGet("/api/testwolox/getalbumsphoto/{id?}", Name = "getalbumsphoto")]
        public IActionResult GetPhotosAlbumsByIdUser(string id)
        {
            try
            {
                return Ok(WoloxApplication.GetPhotosAlbumsByIdUser(id));
            }
            catch (Exception ex)
            {
                Console.Write($"Module:TestWolox, Class:TestWoloxController.cs, Method:GetPhotosAlbumsByIdUser,Error: {ex}");
                return StatusCode(400);
            }
        }
        [HttpGet("/api/testwolox/getpermission/{iduser}/{idalbum}", Name = "getpermission")]
        public IActionResult GetPermission(string iduser, string idalbum)
        {
            try
            {
                return Ok(WoloxApplication.GetPermission(iduser, idalbum));
            }
            catch (Exception ex)
            {
                Console.Write($"Module:TestWolox, Class:TestWoloxController.cs, Method:GetPermission,Error: {ex}");
                return StatusCode(400);
            }
        }
    }
}