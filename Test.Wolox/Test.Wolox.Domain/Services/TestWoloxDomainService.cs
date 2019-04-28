using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.Wolox.Data;
using Test.Wolox.Domain.Entities;
using Test.Wolox.Models;

namespace Test.Wolox.Domain.Services
{
    public class TestWoloxDomainService: ITestWoloxDomainService
    {
        private readonly IUserClient SellerClient;
        public TestWoloxDomainService(IUserClient sellerClient)
        {
            SellerClient = sellerClient;
        }
        public List<User> GetUsersList()
        {
            List<User> response = new List<User>();
            Task<Response> responseGetUser = SellerClient.GetUsers();
            responseGetUser.Wait();

            if (responseGetUser.Result != null)
            {
                if (responseGetUser.Result.Errors.Count == 0)
                {
                    try
                    {
                        return JsonConvert.DeserializeObject<List<User>>(responseGetUser.Result.Data.ToString());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }

            return response;
        }
    }
}
