using NBench;
using ProjManager.BusinessService;
using ProjManager.Data;

namespace ProjManager.LoadTest
{
    public class ProjectLoadTest : PerformanceTestSuite<ProjectLoadTest>
    {
        ProjectService prjSvc = new ProjectService();

         //Load test to measure throughput of add project method
         [PerfBenchmark(NumberOfIterations = 1,
           RunMode = RunMode.Throughput,
           TestMode = TestMode.Test,
           SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]

        public void AddProject_Benchmark_Performance()
        {
            var item = new PROJECT
            {
                ProjectName = "Load test",
                Priority = 5,
                StartDate = new System.DateTime(2020, 06, 16),
                EndDate = new System.DateTime(2020, 12, 31)

            };


            for (var i = 0; i < 100; i++)
            {
                prjSvc.AddProj(item);
            }
        }

        //Load test to measure throughput of GetProjectById project method
        [PerfBenchmark(NumberOfIterations = 1,
           RunMode = RunMode.Throughput,
           TestMode = TestMode.Test,
           SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]

        public void GetProjectbyID_Benchmark_Performance()
        {

            for (var i = 0; i < 100; i++)
            {
                prjSvc.GetProjbyId(1);
            }
        }

        //Load test to measure throughput of GetAll Project method
        [PerfBenchmark(NumberOfIterations = 1,
           RunMode = RunMode.Throughput,
           TestMode = TestMode.Test,
           SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]

        public void GetAllProject_Benchmark_Performance()
        {

            for (var i = 0; i < 100; i++)
            {
                prjSvc.GetAllProjects();
            }
        }


        //Load test to measure throughput of Update Project method
        [PerfBenchmark(NumberOfIterations = 1,
           RunMode = RunMode.Throughput,
           TestMode = TestMode.Test,
           SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]

        public void UpdateProject_Benchmark_Performance()
        {
            var item = new PROJECT
            {
                ProjectId = 2,
                ProjectName = "FSE-Testing",
                Priority = 1,
                StartDate = new System.DateTime(2020, 06, 16),
                EndDate = new System.DateTime(2020, 12, 31)

            };

            for (var i = 0; i < 100; i++)
            {
                prjSvc.UpdateProj(item);
            }
        }


        //Load test to measure throughput of suspend Project method
        [PerfBenchmark(NumberOfIterations = 1,
           RunMode = RunMode.Throughput,
           TestMode = TestMode.Test,
           SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]

        public void SuspendProject_Benchmark_Performance()
        {
            var item = new PROJECT
            {
                ProjectId = 2,
                ProjectName = "FSE-Testing",
                Priority = 1,
                StartDate = new System.DateTime(2020, 06, 16),
                EndDate = new System.DateTime(2020, 12, 31)
            };

            for (var i = 0; i < 100; i++)
            {
                prjSvc.SuspendProj(item);
            }
        }
    }
}
