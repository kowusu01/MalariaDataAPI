using Business.QueryTaskRunners;
using Common.Contants;
using Common.DataAccessParameters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Services.Queries
{
    public interface IGenericServiceInterface
    {
        Task<dynamic> List(int? page, int? pageSize, int defaultPageSize=10);
        Task<dynamic> GetById(int id);
    }

    public interface IDataLoadServiceInterface
    {
        Task<dynamic> GetByLoadId(int loadId);
        Task<dynamic> GetByRecordNumber(int recordNumber);
        Task<dynamic> GetByLoadDate(DateTime date);
        Task<dynamic> GetByFileName(string fileName);
    }

    public interface ICountriesAndRegionsServiceInterface
    {
        Task<dynamic> GetByCountryName(string countryName, int? page, int? pageSize, int defaultPageSize = 10);
        Task<dynamic> GetByRegionName(string regionName, int? page, int? pageSize, int defaultPageSize = 10);
        Task<dynamic> GetByRegionCode(string regionCode, int? page, int? pageSize, int defaultPageSize = 10);
        Task<dynamic> GetByISO2(string iso2Digits);
        Task<dynamic> GetByISO3(string iso3Digits);
        Task<dynamic> GetByISONumber(string isoNumber);
    }

}
