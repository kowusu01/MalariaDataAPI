using Common.ViewModels;
using QueryServices.HealthTest;

namespace Common.Services
{
    public abstract class AbstractHealthTestService: IHealthTestInterface
    {
        public dynamic GetBasicHeatlthTestString()
        {
            HealthTestMessage testData = new HealthTestMessage()
            {
                Message = "OK. This is a basic health test, no Db access attempted.",
                Timestamp = DateTime.Now.ToString()
            };
            return testData;
        }

        public abstract HealthTestMessage GetDbTestString();

    }

}