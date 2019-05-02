using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.Wolox.Domain.Entities;
using Test.Wolox.Domain.ValueObjects;
using Test.Wolox.Models;

namespace Test.Wolox.Data.Repository
{
    public class PermitsRepository : Repository<Permits>, IPermitsRepository
    {
        private readonly IConfiguration Configuration;

        public PermitsRepository(IConfiguration configuration) : base(configuration)
        {
            Configuration = configuration;
        }
        public List<Permits> GetPermission(string valueAtribute1, string valueAtribute2, Enumerators.QueryScanOperator valueOperator)
        {
            List<FilterQueryWithScanOperator> filters = new List<FilterQueryWithScanOperator>
            {
                new FilterQueryWithScanOperator()
                {
                    AtributeName = "idUser",
                    Operator = (int)valueOperator,
                    ValueAtribute = valueAtribute1
                }
                ,
                 new FilterQueryWithScanOperator()
                {
                    AtributeName = "idAlbum",
                    Operator = (int)valueOperator,
                    ValueAtribute = valueAtribute2
                }
            };
            try
            {
                Task<List<Permits>> list = GetByList(filters);
                list.Wait();
                if (list.Result != null && list.Result.Count > 0)
                    return list.Result;
                return null;
            }
            catch (Exception ex)
            {
                Console.Write($"Module:Test, Class:PermitsRepository.cs, Method:GetProductsByResponse, Error: {ex}");
                throw (new Exception("Ocurrió un error al obtener los permisos del album por usuario."));
            }
        }
    }
}
