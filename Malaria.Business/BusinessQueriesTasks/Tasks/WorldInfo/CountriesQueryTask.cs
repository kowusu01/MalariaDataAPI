using BusinessQueries.Tasks.DataLoads;
using Common.DataAccessParameters;
using Common.Models;
using DataAccess;

namespace BusinessQueries.Tasks.WorldInfo
{
    public interface ICountriesQueryTask
    {
        Task<IEnumerable<Country>> ExecuteTask(DataAccessQueryParameters queryParams);
    }

    public class CountriesQueryTask : AbstractBusinessTaskErrors, ICountriesQueryTask
    {
        private readonly IDataAccessCountries _dataAccess;

        public CountriesQueryTask(IDataAccessCountries dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<IEnumerable<Country>> ExecuteTask(DataAccessQueryParameters queryParams)
        {
            return await _dataAccess.Get(queryParams);
        }
    }
}
