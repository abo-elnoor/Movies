using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Searching
{
    public interface ISearchManager
    {
        public void CreateIndex<T>(string indexName) where T : class;
        public void AddDocument<T>(T indexDocument) where T : class;
        public void UpdateDocument<T>(string indexName, T indexDocument);
        public void DeleteDocument<T>(T indexDocument);

        public void Import();
        public IList<T> Search<T>(string keyword) where T : class;
    }
}
