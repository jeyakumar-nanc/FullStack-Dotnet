using ProjManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjManager.BusinessService
{
    public class TaskService
    {
        public List<TaskData> GetAllTasks()
        {
            using (ProjectManagerEntities pmEntities = new ProjectManagerEntities())
            {
                var result = from task in pmEntities.TASKs
                              join project in pmEntities.PROJECTs on task.ProjectId equals project.ProjectId
                              join user in pmEntities.USERS on task.UserId equals user.UserId
                              join parentTask in pmEntities.PARENT_TASK on task.ParentId equals parentTask.ParentId
                              where task.Status.ToLower()!="complete" && project.Status.ToLower() != "suspended"
                              select new TaskData
                              {
                                  TaskName = task.TaskName,
                                  ProjectId = project.ProjectId,
                                  ProjectName = project.ProjectName,
                                  StartDate = task.StartDate,
                                  EndDate = task.EndDate,
                                  ParentTask = parentTask.ParentTask,
                                  TaskId = task.TaskId,
                                  Status = task.Status,
                                  Priority = task.Priority,
                                  User = user.FirstName + " " + user.LastName
                              };

                return result.ToList();
            }
        }

        public List<PARENT_TASK> GetAllParentTasks()
        {
            using (ProjectManagerEntities pmEntities = new ProjectManagerEntities())
            {
                return pmEntities.PARENT_TASK.ToList();
            }
        }

        public TaskData GetTaskbyId(int id)
        {
            using (ProjectManagerEntities pmEntities = new ProjectManagerEntities())
            {
                var tsk = pmEntities.TASKs.Find(id);
                if (tsk != null)
                { 

                    var result = from task in pmEntities.TASKs
                             join project in pmEntities.PROJECTs on task.ProjectId equals project.ProjectId
                             join user in pmEntities.USERS on task.ProjectId equals user.ProjectId
                             join parentTask in pmEntities.PARENT_TASK on task.ParentId equals parentTask.ParentId
                             where task.TaskId == id
                             select new TaskData
                             {
                                 TaskName = task.TaskName,
                                 ProjectId = project.ProjectId,
                                 ProjectName = project.ProjectName,
                                 StartDate = task.StartDate,
                                 EndDate = task.EndDate,
                                 ParentTask = parentTask.ParentTask,
                                 TaskId = task.TaskId,
                                 Status = task.Status,
                                 Priority = task.Priority,
                                 User = user.FirstName + " " + user.LastName,
                                 ParentId = parentTask.ParentId
                             };

                    return result.FirstOrDefault();
                }
                else
                {
                    throw new Exception("Task not found");
                }
            }
        }

        public void AddTask(TASK task)
        {
            using (ProjectManagerEntities pmEntities = new ProjectManagerEntities())
            {
                pmEntities.Entry(task).State = System.Data.Entity.EntityState.Added;
                pmEntities.SaveChanges();
            }
        }

        public void AddParentTask(TASK task)
        {
            using (ProjectManagerEntities pmEntities = new ProjectManagerEntities())
            {
                var parenttask = new PARENT_TASK
                {
                    ParentTask = task.TaskName
                };
                pmEntities.Entry(parenttask).State = System.Data.Entity.EntityState.Added;
                pmEntities.SaveChanges();
            }
        }

        public void UpdateTask(TASK task)
        {
            using (ProjectManagerEntities pmEntities = new ProjectManagerEntities())
            {
                var tsk = pmEntities.TASKs.Find(task.TaskId);
                if (tsk != null)
                {
                    tsk.TaskName = task.TaskName;
                    tsk.StartDate = task.StartDate;
                    tsk.EndDate = task.EndDate;
                    tsk.Priority = task.Priority;
                    tsk.ProjectId = task.ProjectId;
                    tsk.Status = task.Status;
                    pmEntities.Entry(tsk).State = System.Data.Entity.EntityState.Modified;
                    pmEntities.SaveChanges();
                }
                else
                {
                    throw new Exception("Task not found");
                }
            }
        }

        //public List<TASK> DeleteTask(int id)
        //{
        //    using (ProjectManagerEntities pmEntities = new ProjectManagerEntities())
        //    {
        //        var tsk = pmEntities.TASKs.Find(id);
        //        if (tsk != null)
        //        {
        //            pmEntities.TASKs.Remove(tsk);
        //            pmEntities.SaveChanges();
        //            return pmEntities.TASKs.ToList();
        //        }
        //        else
        //        {
        //            throw new Exception("Task not found");
        //        }

        //    }
        //}

        public void EndTask(TASK task)
        {
            using (ProjectManagerEntities pmEntities = new ProjectManagerEntities())
            {
                var tsk = pmEntities.TASKs.Find(task.TaskId);
                if (tsk != null)
                {
                    tsk.Status = "Complete";
                    pmEntities.Entry(tsk).State = System.Data.Entity.EntityState.Modified;
                    pmEntities.SaveChanges();                    

                }
                else
                {
                    throw new Exception("Task not found");
                }

            }
        }
    }
}
