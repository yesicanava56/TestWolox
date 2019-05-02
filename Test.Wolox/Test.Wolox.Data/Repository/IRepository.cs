using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.Wolox.Domain.ValueObjects;

namespace Test.Wolox.Data.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        bool Add(TEntity obj);
        void AddMasive(List<TEntity> lstObj);

        void RemoveMasive(List<TEntity> keys);

        List<TEntity> GetMasive(List<string> keys);

        TEntity GetById(long id, int range);

        List<TEntity> GetAll();

        Task<List<TEntity>> GetAllByIndex(string AtributeIndex, string IndexName, string ValueAtribute);

        Task<List<TEntity>> GetAllByFilters(string indexName, List<FilterQuery> valueAtribute);


        Task<List<TEntity>> GetByList(List<FilterQueryWithScanOperator> valueAtributeScanOperator);

        bool Update(TEntity obj);

        Task<List<TEntity>> GetData(FilterQueryWithScanOperator valueAtributeScanOperator);
        Task<List<TEntity>> GetDataListPara(List<FilterQueryWithScanOperator> valueAtributeScanOperator);
    }
}
