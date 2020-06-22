using NBench;
using ProjManager.BusinessService;
using ProjManager.Data;
using System;

namespace ProjManager.LoadTest
{
    public class TaskLoadTest : PerformanceTestSuite<TaskLoadTest>
    {
        TaskService tskSvc = new TaskService();

        //Load test to measure throughput of GetTaskById project method
        [PerfBenchmark(NumberOfIterations = 1,
           RunMode = RunMode.Throughput,
           TestMode = TestMode.Test,
           SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]

        public void GetTasktbyID_Benchmark_Performance()
        {

            for (var i = 0; i < 100; i++)
            {
                tskSvc.GetTaskbyId(1);
            }
        }

        //Load test to measure throughput of GetAllTask project method
        [PerfBenchmark(NumberOfIterations = 1,
           RunMode = RunMode.Throughput,
           TestMode = TestMode.Test,
           SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]

        public void GetAllTask_Benchmark_Performance()
        {

            for (var i = 0; i < 100; i++)
            {
                tskSvc.GetAllTasks();
            }
        }

        //Load test to measure throughput of Get All Parent tasks project method
        [PerfBenchmark(NumberOfIterations = 1,
           RunMode = RunMode.Throughput,
           TestMode = TestMode.Test,
           SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]

        public void GetAllParentTask_Benchmark_Performance()
        {

            for (var i = 0; i < 100; i++)
            {
                tskSvc.GetAllParentTasks();
            }
        }



        //Load test to measure throughput of Add task  method 
        [PerfBenchmark(NumberOfIterations = 1,
           RunMode = RunMode.Throughput,
           TestMode = TestMode.Test,
           SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]

        public void AddTask_Benchmark_Performance()
        {
            var item = new TASK
            {
                TaskName = "Load testing",
                ProjectId = 1,
                StartDate = new DateTime(2020, 08, 17),
                EndDate = new DateTime(2020, 08, 22),
                TaskId = 1,
                Status = "Not Started",
                Priority = 1,
                ParentId = 1,
                UserId = 9
            };

            for (var i = 0; i < 100; i++)
            {
                tskSvc.AddTask(item);
            }
        }


        //Load test to measure throughput of Update task  method 
        [PerfBenchmark(NumberOfIterations = 1,
           RunMode = RunMode.Throughput,
           TestMode = TestMode.Test,
           SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]

        public void UpdateTask_Benchmark_Performance()
        {
            var item = new TASK
            {
                TaskName = "FSE-Env Setup",
                ProjectId = 1,
                StartDate = new DateTime(2020, 05, 17),
                EndDate = new DateTime(2020, 05, 22),
                TaskId = 1,
                Status = "In Progress",
                Priority = 1,
                ParentId = 1,
                UserId = 9
            };

            for (var i = 0; i < 100; i++)
            {
                tskSvc.UpdateTask(item);
            }
        }


        //Load test to measure throughput of end task  method 
        [PerfBenchmark(NumberOfIterations = 1,
           RunMode = RunMode.Throughput,
           TestMode = TestMode.Test,
           SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]

        public void EndTask_Benchmark_Performance()
        {
            var item = new TASK
            {
                TaskName = "Implementation - Tech",
                ProjectId = 4,
                StartDate = new DateTime(2020, 11, 13),
                EndDate = new DateTime(2020, 11, 13),
                TaskId = 19
            };

            for (var i = 0; i < 100; i++)
            {
                tskSvc.EndTask(item);
            }
        }

        //Load test to measure throughput of Add parent task  method 
        [PerfBenchmark(NumberOfIterations = 1,
           RunMode = RunMode.Throughput,
           TestMode = TestMode.Test,
           SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]

        public void AddParentTask_Benchmark_Performance()
        {
            var item = new TASK
            {
                TaskName = "DR-Env Setup"
            };

            for (var i = 0; i < 100; i++)
            {
                tskSvc.AddParentTask(item);
            }
        }
    }
}
