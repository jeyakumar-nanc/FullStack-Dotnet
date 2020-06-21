using ProjManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ProjManager.BusinessService
{
    public class UserService
    {        
        public List<USER> GetUsers()
        {
            using (ProjectManagerEntities pmEntities = new ProjectManagerEntities())
            {
                return pmEntities.USERS.ToList();                
            }
        }

        public USER GetUserbyId(int userId)
        {
            using (ProjectManagerEntities pmEntities = new ProjectManagerEntities())
            {
                var usr = pmEntities.USERS.Find(userId);
                if (usr != null)
                {
                    return usr;
                }
                else
                {
                    throw new Exception("User not found");
                }                    
            }
        }

        public void AddUser(USER userData)
        {
            using (ProjectManagerEntities pmEntities = new ProjectManagerEntities())
            {
                pmEntities.Entry(userData).State = System.Data.Entity.EntityState.Added;
                pmEntities.SaveChanges();
            }
        }

        public void UpdateUser(USER userData)
        {
            using (ProjectManagerEntities pmEntities = new ProjectManagerEntities())
            {
                USER user = pmEntities.USERS.Find(userData.UserId);
                if (user != null)
                {
                    user.FirstName = userData.FirstName;
                    user.LastName = userData.LastName;
                    user.EmployeeId = userData.EmployeeId;
                    pmEntities.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    pmEntities.SaveChanges();
                }
                else
                {
                    throw new Exception("User not found");
                }
            }
        }

        public List<USER> DeleteUser(int userId)
        {
            using (ProjectManagerEntities pmEntities = new ProjectManagerEntities()) 
            {
                USER usr = pmEntities.USERS.Find(userId);
                if (usr != null)
                {
                    pmEntities.USERS.Remove(usr);
                    pmEntities.SaveChanges();
                    return pmEntities.USERS.ToList();
                }
                else
                {
                    throw new Exception("User not found");
                }
            }
        }
    }
}
