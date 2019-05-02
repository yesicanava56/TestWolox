using System;
using System.Collections.Generic;
using System.Text;
using Test.Wolox.Domain.Entities;
using Test.Wolox.Models;

namespace Test.Wolox.Data.Repository
{
    public interface IPermitsRepository
    {
        List<Permits> GetPermission(string valueAtribute1, string valueAtribute2, Enumerators.QueryScanOperator valueOperator);
    }
}
