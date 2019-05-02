using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Wolox.Domain.ValueObjects;

namespace Test.Wolox.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly RegionEndpoint regionEndpoint = RegionEndpoint.USEast2;
        public IConfiguration Configuration { get; }

        public Repository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public virtual bool Add(TEntity obj)
        {
            using (DynamoDBContext context = GetContext())
            {
                context.SaveAsync<TEntity>(obj).Wait();
                return true;
            }
        }

        public virtual TEntity GetById(long id, int range)
        {
            TEntity entity;

            using (DynamoDBContext context = GetContext())
            {
                entity = context.LoadAsync<TEntity>(id, range).Result;
            }

            return entity;
        }

        public async Task<List<TEntity>> GetAllByIndex(string AtributeIndex, string IndexName, string ValueAtribute)
        {
            List<TEntity> listEntity;

            using (DynamoDBContext context = GetContext())
            {
                QueryFilter queryFilter = new QueryFilter();
                queryFilter.AddCondition(AtributeIndex, QueryOperator.Equal, ValueAtribute);

                QueryOperationConfig queryConfig = new QueryOperationConfig
                {
                    Filter = queryFilter,
                    IndexName = IndexName,
                };
                AsyncSearch<TEntity> query = context.FromQueryAsync<TEntity>(queryConfig, null);
                listEntity = query.GetRemainingAsync().Result.ToList();
            }

            return listEntity;
        }

        public async Task<List<TEntity>> GetAllByFilters(string indexName, List<FilterQuery> listFilter)
        {
            List<TEntity> listEntity = null;

            using (DynamoDBContext context = GetContext())
            {
                QueryFilter queryFilter = new QueryFilter();

                foreach (FilterQuery item in listFilter)
                {
                    Type attributeClass = item.ValueAtribute.GetType();

                    if (attributeClass.Equals(typeof(sbyte)))
                        queryFilter.AddCondition(item.AtributeName, (QueryOperator)item.Operator, (byte)item.ValueAtribute);
                    else if (attributeClass.Equals(typeof(int)))
                        queryFilter.AddCondition(item.AtributeName, (QueryOperator)item.Operator, (int)item.ValueAtribute);
                    else if (attributeClass.Equals(typeof(long)))
                        queryFilter.AddCondition(item.AtributeName, (QueryOperator)item.Operator, (long)item.ValueAtribute);
                    else if (attributeClass.Equals(typeof(double)))
                        queryFilter.AddCondition(item.AtributeName, (QueryOperator)item.Operator, (double)item.ValueAtribute);
                    else if (attributeClass.Equals(typeof(DateTime)))
                        queryFilter.AddCondition(item.AtributeName, (QueryOperator)item.Operator, (DateTime)item.ValueAtribute);
                    else if (attributeClass.Equals(typeof(string)))
                        queryFilter.AddCondition(item.AtributeName, (QueryOperator)item.Operator, (string)item.ValueAtribute);
                    else if (attributeClass.Equals(typeof(bool)))
                        queryFilter.AddCondition(item.AtributeName, (QueryOperator)item.Operator, (bool)item.ValueAtribute);
                }

                QueryOperationConfig queryConfig = new QueryOperationConfig
                {
                    Filter = queryFilter,
                    IndexName = indexName

                };

                AsyncSearch<TEntity> query = context.FromQueryAsync<TEntity>(queryConfig);
                listEntity = query.GetRemainingAsync().Result.ToList();
            }

            return listEntity;
        }

        public async Task<List<TEntity>> GetByList(List<FilterQueryWithScanOperator> valueAtributeScanOperator)
        {
            List<TEntity> listEntity = new List<TEntity>();

            using (DynamoDBContext context = GetContext())
            {
                List<ScanCondition> scanFilter = GetScanCondition(valueAtributeScanOperator);
                AsyncSearch<TEntity> query = context.ScanAsync<TEntity>(scanFilter);
                listEntity = query.GetNextSetAsync().Result.ToList();
            }

            return listEntity;
        }

        public async Task<List<TEntity>> GetData(FilterQueryWithScanOperator valueAtributeScanOperator)
        {
            List<TEntity> listEntity = new List<TEntity>();

            using (DynamoDBContext context = GetContext())
            {
                ScanFilter scanFilter2 = new ScanFilter();
                scanFilter2.AddCondition(valueAtributeScanOperator.AtributeName, ScanOperator.Equal, valueAtributeScanOperator.ValueAtribute.ToString());

                listEntity = context.FromScanAsync<TEntity>(new ScanOperationConfig()
                {
                    Filter = scanFilter2
                }).GetRemainingAsync().Result.ToList();
            }

            return listEntity;
        }
        public async Task<List<TEntity>> GetDataListPara(List<FilterQueryWithScanOperator> valueAtributeScanOperator)
        {
            List<TEntity> listEntity = new List<TEntity>();
            using (DynamoDBContext context = GetContext())
            {
                List<ScanCondition> scanFilter = GetScanCondition(valueAtributeScanOperator);
                AsyncSearch<TEntity> query = context.ScanAsync<TEntity>(scanFilter);
                listEntity = query.GetNextSetAsync().Result.ToList();
            }
            return listEntity;
        }
        public List<ScanCondition> GetScanCondition(List<FilterQueryWithScanOperator> valuesAtributeScanOperator)
        {
            List<ScanCondition> scanCondition = new List<ScanCondition>();

            foreach (FilterQueryWithScanOperator valueAtributeScanOperator in valuesAtributeScanOperator)
            {
                Type attributeClass = valueAtributeScanOperator.ValueAtribute.GetType();
                if ((ScanOperator)valueAtributeScanOperator.Operator == ScanOperator.Between)
                {
                    if (attributeClass.Equals(typeof(sbyte)))
                        scanCondition.Add(new ScanCondition(valueAtributeScanOperator.AtributeName, (ScanOperator)valueAtributeScanOperator.Operator, (byte)valueAtributeScanOperator.ValueAtribute, (byte)valueAtributeScanOperator.ValueAtributeFinal));
                    else if (attributeClass.Equals(typeof(int)))
                        scanCondition.Add(new ScanCondition(valueAtributeScanOperator.AtributeName, (ScanOperator)valueAtributeScanOperator.Operator, (int)valueAtributeScanOperator.ValueAtribute, (int)valueAtributeScanOperator.ValueAtributeFinal));
                    else if (attributeClass.Equals(typeof(long)))
                        scanCondition.Add(new ScanCondition(valueAtributeScanOperator.AtributeName, (ScanOperator)valueAtributeScanOperator.Operator, (long)valueAtributeScanOperator.ValueAtribute, (long)valueAtributeScanOperator.ValueAtributeFinal));
                    else if (attributeClass.Equals(typeof(double)))
                        scanCondition.Add(new ScanCondition(valueAtributeScanOperator.AtributeName, (ScanOperator)valueAtributeScanOperator.Operator, (double)valueAtributeScanOperator.ValueAtribute, (double)valueAtributeScanOperator.ValueAtributeFinal));
                    else if (attributeClass.Equals(typeof(DateTime)))
                        scanCondition.Add(new ScanCondition(valueAtributeScanOperator.AtributeName, (ScanOperator)valueAtributeScanOperator.Operator, (DateTime)valueAtributeScanOperator.ValueAtribute, (DateTime)valueAtributeScanOperator.ValueAtributeFinal));
                    else if (attributeClass.Equals(typeof(string)))
                        scanCondition.Add(new ScanCondition(valueAtributeScanOperator.AtributeName, (ScanOperator)valueAtributeScanOperator.Operator, (string)valueAtributeScanOperator.ValueAtribute, (string)valueAtributeScanOperator.ValueAtributeFinal));
                }
                else if ((ScanOperator)valueAtributeScanOperator.Operator == ScanOperator.In)
                {
                    if (attributeClass.Equals(typeof(List<string>)))
                        scanCondition.Add(new ScanCondition(valueAtributeScanOperator.AtributeName, (ScanOperator)valueAtributeScanOperator.Operator, ((List<string>)valueAtributeScanOperator.ValueAtribute).ToArray()));
                    else if (attributeClass.Equals(typeof(List<long>)))
                        scanCondition.Add(new ScanCondition(valueAtributeScanOperator.AtributeName, (ScanOperator)valueAtributeScanOperator.Operator, (List<long>)valueAtributeScanOperator.ValueAtribute));
                }
                else
                {
                    if (attributeClass.Equals(typeof(sbyte)))
                        scanCondition.Add(new ScanCondition(valueAtributeScanOperator.AtributeName, (ScanOperator)valueAtributeScanOperator.Operator, (byte)valueAtributeScanOperator.ValueAtribute));
                    else if (attributeClass.Equals(typeof(int)))
                        scanCondition.Add(new ScanCondition(valueAtributeScanOperator.AtributeName, (ScanOperator)valueAtributeScanOperator.Operator, (int)valueAtributeScanOperator.ValueAtribute));
                    else if (attributeClass.Equals(typeof(long)))
                        scanCondition.Add(new ScanCondition(valueAtributeScanOperator.AtributeName, (ScanOperator)valueAtributeScanOperator.Operator, (long)valueAtributeScanOperator.ValueAtribute));
                    else if (attributeClass.Equals(typeof(double)))
                        scanCondition.Add(new ScanCondition(valueAtributeScanOperator.AtributeName, (ScanOperator)valueAtributeScanOperator.Operator, (double)valueAtributeScanOperator.ValueAtribute));
                    else if (attributeClass.Equals(typeof(DateTime)))
                        scanCondition.Add(new ScanCondition(valueAtributeScanOperator.AtributeName, (ScanOperator)valueAtributeScanOperator.Operator, (DateTime)valueAtributeScanOperator.ValueAtribute));
                    else if (attributeClass.Equals(typeof(string)))
                        scanCondition.Add(new ScanCondition(valueAtributeScanOperator.AtributeName, (ScanOperator)valueAtributeScanOperator.Operator, (string)valueAtributeScanOperator.ValueAtribute));
                }
            }

            return scanCondition;
        }

        // Metodo en el cual podemos filtral las consultas. 
        // existen dos tipo de filtro los individuales y los  que tiene un rango ejemplo rango de fecha estos van en 
        // la lista llamada lista por between.
   

        public List<TEntity> GetAll()
        {
            List<TEntity> list;
            using (DynamoDBContext context = GetContext())
            {
                list = context.FromScanAsync<TEntity>(new ScanOperationConfig()
                {
                    ConsistentRead = true
                }).GetRemainingAsync().Result.ToList();
            }
            return list;

        }
        public virtual bool Update(TEntity obj)
        {
            using (DynamoDBContext context = GetContext())
            {
                context.SaveAsync<TEntity>(obj).Wait();
                return true;
            }
        }

        public void AddMasive(List<TEntity> lstObj)
        {
            using (DynamoDBContext context = GetContext())
            {
                var batch = context.CreateBatchWrite<TEntity>();
                batch.AddPutItems(lstObj);
                batch.ExecuteAsync().Wait();
            }
        }

        public bool Delete(TEntity obj)
        {
            using (DynamoDBContext context = GetContext())
            {
                context.DeleteAsync<TEntity>(obj).Wait();
                return true;
            }
        }
        public void AddMasiveUnitProduct(List<TEntity> lstObj)
        {
            using (DynamoDBContext context = GetContext())
            {
                var batch = context.CreateBatchWrite<TEntity>();
                batch.AddPutItems(lstObj);
                batch.ExecuteAsync().Wait();
            }
        }


        public List<TEntity> GetMasive(List<string> keys)
        {
            using (DynamoDBContext context = GetContext())
            {
                var batch = context.CreateBatchGet<TEntity>();
                foreach (var item in keys)
                {
                    batch.AddKey(item);
                }

                batch.ExecuteAsync().Wait();

                return batch.Results;
            }
        }

        public void RemoveMasive(List<TEntity> keys)
        {
            using (DynamoDBContext context = GetContext())
            {
                foreach (var item in keys)
                {
                    context.DeleteAsync(item);
                }
            }
        }


        public void Dispose()
        {
        }

        private DynamoDBContext GetContext()
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient(Configuration["accessKey"], Configuration["secretAccessKey"], regionEndpoint);

            AWSConfigsDynamoDB.Context.TableNamePrefix = Configuration["TableNamePrefix"];
            DynamoDBContext context = new DynamoDBContext(client);
            return context;
        }
    }
}
