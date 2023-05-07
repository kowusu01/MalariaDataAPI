using Common.ViewModels;

namespace Common.Services
{
    public interface ITestService : IGenericInterface
    {
        public static dynamic GetBasicTestString()
        {
            HealthTestMessage testData = new HealthTestMessage()
            {
                Message = "Hello from Common.Services layer. No Db access attempted.",
                Timestamp = DateTime.Now.ToString()
            };
            return testData;
        }

        HealthTestMessage GetDbTestString();

    }

}