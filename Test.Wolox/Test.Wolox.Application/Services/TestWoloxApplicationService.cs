using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
