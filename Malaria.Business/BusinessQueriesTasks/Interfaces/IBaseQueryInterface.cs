using Common.QueryParameters;
using Common.Models.Malaria;



namespace Business.QueryTaskRunners
{

    public interface IBaseQueryInterface
    {
        int MaxPageSize { get; set; }
    }

}
