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
    }
}