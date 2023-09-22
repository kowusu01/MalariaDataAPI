using Common.ViewModels;

namespace Services.HealthCheck
{
    public interface IHealthCheckInterface
    {
        dynamic PerformBasicHeatlthCheck();
        HealthCheckMessage PerformDbHealthCheck();
    }
}
