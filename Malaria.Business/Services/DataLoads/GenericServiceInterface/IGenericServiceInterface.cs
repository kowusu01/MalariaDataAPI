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
        Task<dynamic> GetByCountryCode(string countryName, int? page, int? pageSize, int defaultPageSize = 10);
        Task<dynamic> GetByRegionCode(string regionCode, int? page, int? pageSize, int defaultPageSize = 10);
        Task<dynamic> GetByISONumber(string isoNumber);
    }

}
