using Common.ViewModels;

namespace QueryServices.Interfaces
{
    public interface IHealthCheckInterface
    {
        dynamic PerformBasicHeatlthCheck();
        HealthCheckMessage PerformDbHealthCheck();
    }
}
