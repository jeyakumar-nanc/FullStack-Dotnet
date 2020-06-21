using System;

namespace ProjManager.Data
{
    public class TaskData
    {
        public int TaskId { get; set; }
        public int ParentId { get; set; }
        public string ParentTask { get; set; }
        public int ProjectId { get; set; }
        public string TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Priority { get; set; }
        public string Status { get; set; }
        public string ProjectName { get; set; }
        public string User { get; set; }
    }
}
