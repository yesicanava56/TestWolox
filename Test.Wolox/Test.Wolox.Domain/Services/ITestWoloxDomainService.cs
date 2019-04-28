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
    }
}
