using LUSSISADTeam10API.Models;
using LUSSISADTeam10API.Models.DBModels;
using LUSSISADTeam10API.Models.APIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSISADTeam10API.Constants;



namespace LUSSISADTeam10API.Repositories
{
    public class DelegationRepo
    {
        private static LUSSISEntities entities = new LUSSISEntities();
        private static DelegationModel CovertDBDelegationtoAPIUser(delegation delegation)
        {
            DelegationModel dgm = new DelegationModel(delegation.delid, delegation.startdate,
                delegation.enddate, delegation.userid, delegation.user.username, delegation.user.role,
                delegation.user.department.deptname,
                delegation.active, delegation.assignedby, delegation.user1.username, delegation.user1.role,
                delegation.user1.department.deptname);
            return dgm;
        }
        public static DelegationModel GetDelegationByDelegationID(int delid, out string error)
        {


            error = "";

            delegation dele = new delegation();
            DelegationModel dm = new DelegationModel();
            try
            {
                dele = entities.delegations.Where(p => p.delid == delid).FirstOrDefault<delegation>();
                dm = CovertDBDelegationtoAPIUser(dele);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return dm;
        }
        // to get the Disbursement by the UserId
        public static List<DelegationModel> GetDelegationByUserId(int uid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<DelegationModel> dism = new List<DelegationModel>();
            try
            {
                // get requisition list from database
                List<delegation> dele = entities.delegations.Where(p => p.userid == uid).ToList<delegation>();

                // convert the DB Model list to API Model list
                foreach (delegation dis in dele)
                {
                    dism.Add(CovertDBDelegationtoAPIUser(dis));
                }
            }

            // if requisition not found, will throw NOTFOUND exception
            catch (NullReferenceException)
            {
                // if there is NULL Exception error, error will be 404
                error = ConError.Status.NOTFOUND;
            }

            catch (Exception e)
            {
                // for other exceptions
                error = e.Message;
            }

            //returning the list
            return dism;
        }

        // to get the Disbursement by the Assignedby ID
        public static List<DelegationModel> GetDelegationByassignedby(int asid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<DelegationModel> dism = new List<DelegationModel>();
            try
            {
                // get requisition list from database
                List<delegation> dele = entities.delegations.Where(p => p.assignedby == asid).ToList<delegation>();

                // convert the DB Model list to API Model list
                foreach (delegation dis in dele)
                {
                    dism.Add(CovertDBDelegationtoAPIUser(dis));
                }
            }

            // if requisition not found, will throw NOTFOUND exception
            catch (NullReferenceException)
            {
                // if there is NULL Exception error, error will be 404
                error = ConError.Status.NOTFOUND;
            }

            catch (Exception e)
            {
                // for other exceptions
                error = e.Message;
            }

            //returning the list
            return dism;
        }

        public static List<DelegationModel> GetAllDelegations()
        {
            List<delegation> delegations = entities.delegations.ToList<delegation>();
            List<DelegationModel> dms = new List<DelegationModel>();
            foreach (delegation delegation in delegations)
            {
                dms.Add(CovertDBDelegationtoAPIUser(delegation));
            }
            return dms;
        }


        //update Delegation
        public static DelegationModel UpdateDelegation(DelegationModel dm, out String error)
        {
            error = "";
            // declare and initialize new LUSSISEntities to perform update
            LUSSISEntities entities = new LUSSISEntities();
            delegation d = new delegation();
            try
            {
                // finding the delegation object using delegation API model
                d = entities.delegations.Where(p => p.delid == dm.Delid).First<delegation>();

                // transfering data from API model to DB Model
                d.startdate = dm.Startdate;
                d.enddate = dm.Enddate;
                d.userid = dm.Userid;
                d.active = dm.Active;
                d.assignedby = dm.AssignedbyId;

                // saving the update
                entities.SaveChanges();

                // return the updated model 
                dm = CovertDBDelegationtoAPIUser(d);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return dm;
        }

        //create delegation
        public static DelegationModel CreateDelegation(DelegationModel dele, out string error)
        {
            error = "";
            LUSSISEntities entities = new LUSSISEntities();
            delegation d = new delegation();
            DelegationModel ndel = new DelegationModel();
            try
            {

                DepartmentModel dep = DepartmentRepo.GetDepartmentByUserid(dele.Userid, out error);
                List<UserModel> userlist = UserRepo.GetUserByDeptid(dep.Deptid, out error);
                foreach (UserModel u in userlist)
                {
                    List<DelegationModel> delelist = GetDelegationByUserId(u.Userid, out error);
                    foreach (DelegationModel deleg in delelist)
                    {
                        delegation del = entities.delegations.Where(p => p.delid == deleg.Delid).FirstOrDefault<delegation>();
                        del.active = ConDelegation.Active.INACTIVE;
                        entities.SaveChanges();
                    }


                }
                d.startdate = dele.Startdate;
                d.enddate = dele.Enddate;
                d.userid = dele.Userid;
                d.active = ConDelegation.Active.ACTIVE;
                d.assignedby = dele.AssignedbyId;
                d = entities.delegations.Add(d);
                entities.SaveChanges();
                UserRepo.delegateuser(dele.Userid);

                dele = GetDelegationByDelegationID(d.delid, out error);

                NotificationModel nom = new NotificationModel();
                nom.Deptid = d.user.deptid;
                nom.Role = ConUser.Role.EMPLOYEEREP;
                nom.Title = "New Authority";
                nom.NotiType = ConNotification.NotiType.DelegationAssigned;
                nom.ResID = dele.Userid;
                nom.Remark = "You has been assigned as a Temp Head of Department!";
                nom = NotificationRepo.CreatNotification(nom, out error);


            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return dele;
        }


        //cancel delegation

        public static DelegationModel CancelDelegation(DelegationModel dm, out String error)
        {
            error = "";
            // declare and initialize new LUSSISEntities to perform update
            LUSSISEntities entities = new LUSSISEntities();
            delegation d = new delegation();
            try
            {
                // finding the delegation object using delegation API model
                d = entities.delegations.Where(p => p.delid == dm.Delid).First<delegation>();


                d.active = ConDelegation.Active.INACTIVE;

                // saving the update
                entities.SaveChanges();

                UserRepo.canceldelegateuser(dm.Userid);

                // return the updated model 
                dm = GetDelegationByDelegationID(d.delid, out error);


                NotificationModel nom = new NotificationModel();
                nom.Deptid = d.user.deptid;
                nom.Role = ConUser.Role.EMPLOYEEREP;
                nom.Title = "Authority Cancellation";
                nom.NotiType = ConNotification.NotiType.DelegationCancelled;
                nom.ResID = dm.Userid;
                nom.Remark = "You has been removed as a Temp Head of Department!";
                nom = NotificationRepo.CreatNotification(nom, out error);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return dm;
        }





        //search the previous delegation with userlist
        public static DelegationModel SearchPreviousDelegation(int deptid, out string error)
        {

            error = "";
            LUSSISEntities entities = new LUSSISEntities();
            List<department> dept = new List<department>();
            List<user> ums = new List<user>();
            List<UserModel> urm = new List<UserModel>();
            try
            {
                ums = entities.users.Where(p => p.deptid == deptid && p.role != ConUser.Role.HOD).ToList<user>();
                foreach (user u in ums)
                {
                    urm.Add(UserRepo.CovertDBUsertoAPIUser(u));
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


            delegation d = new delegation();
            DelegationModel ndel = new DelegationModel();
            try
            {
                foreach (UserModel um in urm)
                {
                    List<DelegationModel> delee = GetDelegationByUserId(um.Userid, out error);

                    foreach (DelegationModel dm in delee)
                    {
                        if (dm.Active == ConDelegation.Active.ACTIVE)
                        {
                            ndel = dm;
                        }


                    }

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
            return ndel;
        }
    }
}