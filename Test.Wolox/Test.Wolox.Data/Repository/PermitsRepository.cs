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
    public class PermitsRepository : Repository<Permission>, IPermitsRepository
    {
        private readonly IConfiguration Configuration;

        public PermitsRepository(IConfiguration configuration) : base(configuration)
        {
            Configuration = configuration;
        }
        public List<Permission> GetPermission(string valueAtribute1, string valueAtribute2, Enumerators.QueryScanOperator valueOperator)
        {
            List<FilterQueryWithScanOperator> filters = new List<FilterQueryWithScanOperator>
            {
                new FilterQueryWithScanOperator()
                {
                    AtributeName = "idUser",
                    Operator = (int)valueOperator,
                    ValueAtribute = valueAtribute1
                },             
                 new FilterQueryWithScanOperator()
                {
                    AtributeName = "idAlbum",
                    Operator = (int)valueOperator,
                    ValueAtribute = valueAtribute2
                }
            };
            try
            {
                Task<List<Permission>> list = GetByList(filters);
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

        public List<Permission> GetPermissionUser(string valueAtribute, Enumerators.QueryScanOperator valueOperator)
        {
            List<FilterQueryWithScanOperator> filters = new List<FilterQueryWithScanOperator>
            {
               new FilterQueryWithScanOperator()
                {
                    AtributeName = "idAlbum",
                    Operator = (int)valueOperator,
                    ValueAtribute = valueAtribute
                }
            };
            try
            {
                Task<List<Permission>> list = GetByList(filters);
                list.Wait();
                if (list.Result != null && list.Result.Count > 0)
                    return list.Result;
                return null;
            }
            catch (Exception ex)
            {
                Console.Write($"Module:Test, Class:PermitsRepository.cs, Method:GetPermissionUser, Error: {ex}");
                throw (new Exception("Ocurrió un error al obtener los permisos del album por usuario."));
            }
        }
        

        public bool RegisterPermission(Permission permits)
        {
            try
            {
                Add(permits);
                return true;
            }
            catch (Exception ex)
            {
                Console.Write($"Module:Test, Class:PermitsRepository.cs, Method:RegisterPermission, Error: {ex}");
            }
            return false;
        }
        public bool UpdatePermission(Permission permits)
        {
            try
            {
                Update(permits);
                return true;
            }
            catch (Exception ex)
            {
                Console.Write($"Module:Test, Class:PermitsRepository.cs, Method:UpdatePermission, Error: {ex}");
            }
            return false;
        }
    }
}
