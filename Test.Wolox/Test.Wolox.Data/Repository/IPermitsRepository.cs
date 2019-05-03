using System;
using System.Collections.Generic;
using System.Text;
using Test.Wolox.Domain.Entities;
using Test.Wolox.Models;

namespace Test.Wolox.Data.Repository
{
    public interface IPermitsRepository
    {
        List<Permission> GetPermission(string valueAtribute1, string valueAtribute2, Enumerators.QueryScanOperator valueOperator);
        bool RegisterPermission(Permission permits);
        bool UpdatePermission(Permission permits);
        List<Permission> GetPermissionUser(string valueAtribute, Enumerators.QueryScanOperator valueOperator);
    }
}
