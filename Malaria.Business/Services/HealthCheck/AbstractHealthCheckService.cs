using Common.ViewModels;
using QueryServices.HealthTest;

namespace Common.Services
{
    public abstract class AbstractHealthCheckService: IHealthCheckInterface
    {
        public dynamic GetBasicHeatlthTestString()
        {
            HealthCheckMessage testData = new HealthCheckMessage()
            {
                Message = $"OK. {this.GetType().Name} - This is a basic health test, no Db access attempted.",
                Timestamp = DateTime.Now.ToString()
            };
            return testData;
        }

        public abstract HealthCheckMessage GetDbTestString();

    }

}