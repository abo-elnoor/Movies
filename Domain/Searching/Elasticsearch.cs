using Microsoft.Extensions.Caching.Distributed;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Searching
{
    public class Elastic_Search : ISearchManager
    {
        private readonly IElasticClient _client;
        public Elastic_Search(IElasticClient client)
        {
            _client = client;
        }

        /// <summary>
        /// creating a mapping between the model class T and the index from Elasticsearch instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="indexName"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public void CreateIndex<T>(string indexName) where T : class
        {
            _client.Indices.Create(indexName, index => index.Map<T>(x => x.AutoMap()));
        }

        public void AddDocument<T>(T indexDocument) where T : class
        {
            var v = _client.IndexDocument<T>(indexDocument);
            decimal d = 0;
        }

        public void UpdateDocument<T>(string indexName, T indexDocument)
        {
            //throw new NotImplementedException();
        }

        public void DeleteDocument<T>(T indexDocument)
        {
            throw new NotImplementedException();
        }

        public void Import()
        {
            throw new NotImplementedException();
        }

        public IList<T> Search<T>(string keyword) where T : class
        {
            var result = _client.Search<T>(s => s.Query(q => q.MatchAll()));
            return result.Documents.ToList();
        }


    }
}
