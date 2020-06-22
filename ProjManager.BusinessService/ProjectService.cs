using ProjManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjManager.BusinessService
{
    public class ProjectService
    {
        public List<PROJECT> GetAllProjects()
        {
            using (ProjectManagerEntities pmEntities = new ProjectManagerEntities())
            {

                var result = from task in pmEntities.TASKs
                             join project in pmEntities.PROJECTs on task.ProjectId equals project.ProjectId
                             join user in pmEntities.USERS on task.UserId equals user.UserId
                             join parentTask in pmEntities.PARENT_TASK on task.ParentId equals parentTask.ParentId
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

                return pmEntities.PROJECTs.ToList();
            }
        }

        public PROJECT GetProjbyId(int id)
        {
            using (ProjectManagerEntities pmEntities = new ProjectManagerEntities())
            {
                var proj = pmEntities.PROJECTs.Find(id);
                if (proj != null)
                {
                    return proj;
                }
                else
                {
                    throw new Exception("Project not found");
                }

            }
        }

        public void AddProj(PROJECT proj)
        {
            using (ProjectManagerEntities pmEntities = new ProjectManagerEntities())
            {
                pmEntities.Entry(proj).State = System.Data.Entity.EntityState.Added;
                pmEntities.SaveChanges();
            }
        }

        public void UpdateProj(PROJECT proj)
        {
            using (ProjectManagerEntities pmEntities = new ProjectManagerEntities())
            {
                var prjct = pmEntities.PROJECTs.Find(proj.ProjectId);
                if (prjct != null)
                {
                    prjct.ProjectName = proj.ProjectName;
                    prjct.StartDate = proj.StartDate;
                    prjct.EndDate = proj.EndDate;
                    prjct.Priority = proj.Priority;
                    pmEntities.Entry(prjct).State = System.Data.Entity.EntityState.Modified;
                    pmEntities.SaveChanges();
                }
                else
                {
                    throw new Exception("Project not found");
                }
            }
        }

        public List<PROJECT> DeleteProj(int projId)
        {
            using (ProjectManagerEntities pmEntities = new ProjectManagerEntities())
            {
                PROJECT prjct = pmEntities.PROJECTs.Find(projId);
                if (prjct != null)
                {
                    pmEntities.PROJECTs.Remove(prjct);
                    pmEntities.SaveChanges();
                    return pmEntities.PROJECTs.ToList();
                }
                else
                {
                    throw new Exception("Project not found");
                }
            }
        }
    }
}
