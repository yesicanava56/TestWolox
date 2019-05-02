using System;
using System.Collections.Generic;
using System.Text;
using Test.Wolox.Domain.Entities;
using Test.Wolox.Models;

namespace Test.Wolox.Data.Repository
{
    public interface IUserRepository
    {
        List<User> GetUser(string valueAtribute, Enumerators.QueryScanOperator valueOperator);
    }
}
