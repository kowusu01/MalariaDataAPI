using BusinessQueries.Tasks.DataLoads;
using Common.QueryParameters;
using Common.Models.WorldInfo;
using DataAccess;

namespace BusinessQueries.Tasks.WorldInfo
{
    public interface ICountriesQueryTask
    {
        Task<IEnumerable<Country>> ExecuteTask(QueryParameters queryParams);
    }

    public class CountriesQueryTask : AbstractBusinessTaskErrors, ICountriesQueryTask
    {
        private readonly IDataAccessCountries _dataAccess;

        public CountriesQueryTask(IDataAccessCountries dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<IEnumerable<Country>> ExecuteTask(QueryParameters queryParams)
        {
            return await _dataAccess.Get(queryParams);
        }
    }
}
