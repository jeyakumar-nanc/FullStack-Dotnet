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
                return pmEntities.PROJECTs.Where(s=>s.Status.ToLower() != "suspended").ToList();
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

        public void SuspendProj(PROJECT proj)
        {
            using (ProjectManagerEntities pmEntities = new ProjectManagerEntities())
            {
                var tsk = pmEntities.PROJECTs.Find(proj.ProjectId);
                if (tsk != null)
                {
                    tsk.Status = "Suspended";
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
