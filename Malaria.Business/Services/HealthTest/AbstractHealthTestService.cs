using Common.ViewModels;

namespace Common.Services
{
    public abstract class AbstractHealthTestService
    {
        public static dynamic GetBasicHeatlthTestString()
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