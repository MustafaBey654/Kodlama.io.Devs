using Core.ElesticSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ElesticSearch
{
    public interface IElasticSearch
    {
        Task<IElasticSearchResult> CreateNewIndexAsync(IndexModel indexModel);
        Task<IElasticSearchResult> InsertAsync(ElasticSearchInsertUpdateModel model);
        Task<IElasticSearchResult> InsertManyAsync(string indexName, object[] items);

        Task<List<ElasticSearchGetModel<T>>> GetAllSearch<T>(SearchParameters parameters)
            where T : class;
        Task<List<ElasticSearchGetModel<T>>> GetSearchByField<T>(SearchByFieldParameters fieldParameters)
            where T : class;
        Task<List<ElasticSearchGetModel<T>>> GetSearchBySimpleQueryString<T>(SearchByQueryParameters queryParameters)
            where T : class;

        Task<IElasticSearchResult> UpdateByElasticIdAsync(ElasticSearchInsertUpdateModel model);
        Task<IElasticSearchResult> DeleteByElasticIdAsync(ElasticSearchModel model);
    }
}
