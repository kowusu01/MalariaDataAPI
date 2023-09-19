using Common.DataAccessParameters;
using Common.Models.MalariaData;



namespace Business.QueryTaskRunners
{

    public interface IBaseQueryInterface
    {
        int MaxPageSize { get; set; }
    }

}
