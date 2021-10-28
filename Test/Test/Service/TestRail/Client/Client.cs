using Gurock.TestRail;
using TestFrameworkHomeTask.Service.TestRail.Entities;

namespace TestFrameworkHomeTask.Service.TestRail.Client
{
    public class Client
    {
        private APIClient client;

        public Client(string url, string user, string password)
        {
            client = new APIClient(url);
            client.User = user;
            client.Password = password;
        }

        public void AddResultToTestById(string testId, AddResultEntity testResult)
        {
            client.SendPost("add_result/" + testId, testResult);
        }

    }
}
