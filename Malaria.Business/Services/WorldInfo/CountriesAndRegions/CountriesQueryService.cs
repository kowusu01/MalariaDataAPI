

using Microsoft.Extensions.Logging;

using Common.Models.Malaria;
using Common.Contants;
using Common.QueryParameters;
using Common.ViewModels;
using BusinessQueries.TaskRunners.WorldInfo;

namespace Services.Queries
{

    public interface ICountriesQueryService : IGenericServiceInterface, ICountriesAndRegionsServiceInterface
    {
    }


    public class CountriesQueryService : ICountriesQueryService
    {
        private readonly ILogger<CountriesQueryService> _logger;
        
        //private readonly AppDbContext _dbContext;

        // this service has only one task runner, DataLoadStatsTaskRUnner
        private readonly  ICountriesQueryTaskRunner _taskRunner;

        public CountriesQueryService(ILogger<CountriesQueryService> logger, ICountriesQueryTaskRunner runnerObj)
        {
            _logger = logger;
        //    _dbContext = dbContext;
            _taskRunner = runnerObj;
        }

        public async Task<dynamic> List(int? page, int? pageSize, int defaultPageSize=10)
        {
            // select a runner 
            // convert params to querypParams
            // execute
            // convert reult to view model and return

            var data = await _taskRunner.RunTasks(new QueryParameters()
            {
                PaginationInfo = new ListPagination() { Page = (page == null ? 1 : page.Value), PageSize = (pageSize == null ? defaultPageSize : pageSize.Value) }
            }) ;
            return ServicesHelper.MapListDataToViewModel(data, (page == null ? 1 : page.Value), (pageSize == null ? defaultPageSize : pageSize.Value));
        }
        public async Task<dynamic> GetById(int id)
        {
            var data = await _taskRunner.RunTasks(new QueryParameters() { FilterByColumn = FilterByColumnEnum.Id, FilterByColumnValue = id.ToString() });
            return ServicesHelper.MapDataToViewModel(data);
        }
        public async Task<dynamic> GetByLoadId(int loadId)
        {
            var data = await _taskRunner.RunTasks(new QueryParameters() { FilterByColumn = FilterByColumnEnum.LoadId, FilterByColumnValue = loadId.ToString() });
            return ServicesHelper.MapDataToViewModel(data);
        }
       

        public async Task<dynamic> GetByCountryCode(string countryCode, int? page, int? pageSize, int defaultPageSize = 10)
        {
            var data = await _taskRunner.RunTasks(new QueryParameters() 
            {
                FilterByColumn = FilterByColumnEnum.CountryCode, 
                FilterByColumnValue = countryCode,
                PaginationInfo = new ListPagination() { Page = (page == null ? 1 : page.Value), PageSize = (pageSize == null ? defaultPageSize : pageSize.Value) }
            });
            return ServicesHelper.MapListDataToViewModel(data, page.Value, pageSize.Value);
        }

        public async Task<dynamic> GetByRegionCode(string regionCode, int? page, int? pageSize, int defaultPageSize = 10)
        {
            var data = await _taskRunner.RunTasks(new QueryParameters() 
            { 
                FilterByColumn = FilterByColumnEnum.RegionCode,
                FilterByColumnValue = regionCode,
                PaginationInfo = new ListPagination() { Page = (page == null ? 1 : page.Value), PageSize = (pageSize == null ? defaultPageSize : pageSize.Value) }
            }
            );
            return ServicesHelper.MapListDataToViewModel(data, (page == null ? 1 : page.Value), (pageSize == null ? defaultPageSize : pageSize.Value));
        }

        public async Task<dynamic> GetByISONumber(string isoNumber)
        {
            var data = await _taskRunner.RunTasks(new QueryParameters() { FilterByColumn = FilterByColumnEnum.ISONum, FilterByColumnValue = isoNumber });
            return ServicesHelper.MapDataToViewModel(data);
        }
    }
}