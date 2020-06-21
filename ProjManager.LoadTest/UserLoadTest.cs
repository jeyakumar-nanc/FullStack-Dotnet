using NBench;
using ProjManager.BusinessService;
using ProjManager.Data;

namespace ProjManager.LoadTest
{
    public class UserLoadTest: PerformanceTestSuite<UserLoadTest>
    {
        UserService usr = new UserService();


        //Load test to measure throughput of GetUserById method
        [PerfBenchmark(NumberOfIterations = 1,
           RunMode = RunMode.Throughput,
           TestMode = TestMode.Test,
           SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]

        public void GetUserbyID_Benchmark_Performance()
        {

            for (var i = 0; i < 100; i++)
            {
                usr.GetUserbyId(1);
            }
        }


        //Load test to measure throughput of Get All users method
        [PerfBenchmark(NumberOfIterations = 1,
           RunMode = RunMode.Throughput,
           TestMode = TestMode.Test,
           SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]

        public void GetAllUsers_Benchmark_Performance()
        {

            for (var i = 0; i < 100; i++)
            {
                usr.GetUsers();
            }
        }

        //Load test to measure throughput of Add users method
        [PerfBenchmark(NumberOfIterations = 1,
           RunMode = RunMode.Throughput,
           TestMode = TestMode.Test,
           SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]

        public void AddUsers_Benchmark_Performance()
        {
            USER data = new USER
            {
                FirstName = "Nancy",
                LastName = "DJ",
                UserId = 1,
                EmployeeId = 395423,
                ProjectId = 1
            };

            for (var i = 0; i < 100; i++)
            {
                usr.AddUser(data);
            }
        }

        //Load test to measure throughput of update users method
        [PerfBenchmark(NumberOfIterations = 1,
           RunMode = RunMode.Throughput,
           TestMode = TestMode.Test,
           SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]

        public void UpdateUsers_Benchmark_Performance()
        {
            USER item = new USER
            {
                FirstName = "Ryan",
                LastName = "RN",
                UserId = 4,
                EmployeeId = 357844,
                ProjectId = 2
            };

            for (var i = 0; i < 100; i++)
            {
                usr.UpdateUser(item);
            }
        }
    }
}
