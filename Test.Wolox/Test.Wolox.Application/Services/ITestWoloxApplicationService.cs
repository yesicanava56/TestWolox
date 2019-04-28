using System;
using System.Collections.Generic;
using System.Text;
using Test.Wolox.Models;

namespace Test.Wolox.Application.Services
{
    public interface ITestWoloxApplicationService
    {
        ResponseViewModel GetUsersList();
    }
}
