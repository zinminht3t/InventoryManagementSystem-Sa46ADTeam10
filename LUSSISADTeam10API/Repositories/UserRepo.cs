using LUSSISADTeam10API.Models;
using LUSSISADTeam10API.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Repositories
{
    public static class UserRepo
    {

        private static LUSSISEntities entities = new LUSSISEntities();
        private static UserModel CovertDBUsertoAPIUser(user user)
        {
            UserModel um = new UserModel(user.userid, user.username, user.email, user.password, user.role, user.fullname, user.deptid, user.department.deptname);
            return um;
        }

        public static UserModel ValidateUser(string username, string password)
        {
            user user = entities.users.Where(e => e.username == username && e.password == password).FirstOrDefault<user>();
            return CovertDBUsertoAPIUser(user);
        }

        public static UserModel GetUserByUserID(int userid)
        {
            user user = entities.users.Where(p => p.userid == userid).FirstOrDefault<user>();
            return CovertDBUsertoAPIUser(user);
        }

        public static List<UserModel> GetAllUsers()
        {
            List<user> users = entities.users.ToList<user>();
            List<UserModel> ums = new List<UserModel>();
            foreach (user user in users)
            {
                ums.Add(CovertDBUsertoAPIUser(user));
            }
            return ums;
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


    }
}