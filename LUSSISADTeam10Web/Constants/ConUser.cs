using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Constants
{
    public class ConUser
    {
        public static class Role
        {
            public const int CLERK = 1;
            public const int SUPERVISOR = 2;
            public const int MANAGER = 3;
            public const int HOD = 4;
            public const int EMPLOYEE = 5;
            public const int DEPARTMENTREP = 6;
            public const int TEMPHOD = 7;
        }

        public static class RoleString
        {
            public const string CLERK = "CLERK";
            public const string SUPERVISOR = "SUPERVISOR";
            public const string MANAGER = "MANAGER";
            public const string HOD = "HOD";
            public const string EMPLOYEE = "EMPLOYEE";
            public const string DEPARTMENTREP = "DEPARTMENTREP";
            public const string TEMPHOD = "TEMPHOD";
        }

        public static string CovertRoletoRoleString(int role)
        {
            switch (role)
            {
                case Role.CLERK:
                    return RoleString.CLERK;
                case Role.SUPERVISOR:
                    return RoleString.SUPERVISOR;
                case Role.MANAGER:
                    return RoleString.MANAGER;
                case Role.HOD:
                    return RoleString.HOD;
                case Role.EMPLOYEE:
                    return RoleString.EMPLOYEE;
                case Role.DEPARTMENTREP:
                    return RoleString.DEPARTMENTREP;
                case Role.TEMPHOD:
                    return RoleString.TEMPHOD;
            }
            return "";
        }
    }
}