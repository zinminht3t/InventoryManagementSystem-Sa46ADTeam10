using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models;
using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Repositories
{
    public static class UserRepo
    {

        private static UserModel CovertDBUsertoAPIUser(user user)
        {
            UserModel um = new UserModel(user.userid, user.username, user.email, user.password, user.role, user.fullname, user.deptid, user.department.deptname);
            return um;
        }

        public static UserModel ValidateUser(string username, string password)
        {
            LUSSISEntities entities = new LUSSISEntities();

            user user = entities.users.Where(e => e.username == username && e.password == password).FirstOrDefault<user>();
            return CovertDBUsertoAPIUser(user);
        }

        internal static List<UserModel> GetAllUser(out string error)
        {
            throw new NotImplementedException();
        }

        public static UserModel GetUserByUserID(int userid)
        {
            LUSSISEntities entities = new LUSSISEntities();

            user user = entities.users.Where(p => p.userid == userid).FirstOrDefault<user>();
            return CovertDBUsertoAPIUser(user);
        }


        public static List<UserModel> GetAllUser()
        {
            LUSSISEntities entities = new LUSSISEntities();

            List<user> users = entities.users.ToList<user>();
            List<UserModel> ums = new List<UserModel>();
            foreach (user user in users)
            {
                ums.Add(CovertDBUsertoAPIUser(user));
            }
            return ums;
        }

        internal static UserModel GetUserByUserid(int userid, out string error)
        {
            throw new NotImplementedException();
        }

        internal static UserModel GetUserByUserID(int userid, out string error)
        {
            throw new NotImplementedException();
        }

        public static UserModel UpdateUser(UserModel um)
        {

            LUSSISEntities entities = new LUSSISEntities();
            user u = entities.users.Where(p => p.userid == um.Userid).First<user>();
            u.userid = um.Userid;
            u.username = um.Username;
            u.email = um.Email;
            u.password = um.Password;
            u.role = um.Role;
            u.deptid = um.Deptid;
            entities.SaveChanges();
            return CovertDBUsertoAPIUser(u);
        }



        // Start Phyo2
        public static List<UserModel> GetUserByRoleandDeptid(int role,int deptid, out string error)
        {
            error = "";
            List<user> user = new List<user>();
            List<UserModel> usm = new List<UserModel>();
            LUSSISEntities entities = new LUSSISEntities();
            try
            {
                user = entities.users.Where(p => p.role == role && p.deptid == deptid).ToList<user>();
                foreach (user u in user)
                {
                    usm.Add(CovertDBUsertoAPIUser(u));
                }
            }
            catch (NullReferenceException)
            {

                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return usm;

            
        }


      
        // End Phyo2


        // Start TAZ
        public static List<UserModel> GetUserByDeptid(int deptid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";

            List<department> dept = new List<department>();
            List<user> ums = new List<user>();
            List<UserModel> urm = new List<UserModel>();
            try
            {
                ums = entities.users.Where(p => p.deptid == deptid).ToList<user>();
                foreach (user u in ums)
                {
                    urm.Add(CovertDBUsertoAPIUser(u));
                }
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return urm;

        }


      
        // End TAZ


    }
}