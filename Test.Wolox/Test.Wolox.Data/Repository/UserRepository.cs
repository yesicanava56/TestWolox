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
    public class UserRepository: Repository<User>, IUserRepository
    {

        private readonly IConfiguration Configuration;

        public UserRepository(IConfiguration configuration) : base(configuration)
        {
            Configuration = configuration;
        }
        public List<User> GetUser(string valueAtribute, Enumerators.QueryScanOperator valueOperator)
        {
            FilterQueryWithScanOperator filters = new FilterQueryWithScanOperator
            {
                AtributeName = "name",
                Operator = (int)valueOperator,
                ValueAtribute = valueAtribute
            };
            try
            {
                Task<List<User>> list = GetData(filters);
                list.Wait();
                if (list.Result != null && list.Result.Count > 0)
                    return list.Result;

                return null;
            }
            catch (Exception ex)
            {
                Console.Write($"Module:Product, Class:ProductsWaitingRepository.cs, Method:GetProductsByResponse, Error: {ex}");
                throw (new Exception("Ocurrió un error al obtener los productos en espera."));
            }
        }
       
    }
}
