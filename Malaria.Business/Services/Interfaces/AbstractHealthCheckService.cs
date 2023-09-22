using Common.ViewModels;

namespace QueryServices.Interfaces
{
    public abstract class AbstractHealthCheckService : IHealthCheckInterface
    {
        public dynamic PerformBasicHeatlthCheck()
        {
            HealthCheckMessage testData = new HealthCheckMessage()
            {
                Message = $"OK. {GetType().Name} - This is a basic health test, no Db access attempted.",
                Timestamp = DateTime.Now.ToString()
            };
            return testData;
        }

        public abstract HealthCheckMessage PerformDbHealthCheck();

    }

}