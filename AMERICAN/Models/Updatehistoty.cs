using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AMERICAN.Models;
namespace AMERICAN.Models
{
    public class Updatehistoty
    {
        public AMERICANContext db = new AMERICANContext();
        public static void UpdateHistory(string task,string FullName,string UserID)
        {

            AMERICANContext db = new AMERICANContext();
            tblHistoryLogin tblhistorylogin = new tblHistoryLogin();
            tblhistorylogin.FullName = FullName;
            tblhistorylogin.Task = task;
            tblhistorylogin.idUser = int.Parse(UserID);
            tblhistorylogin.DateCreate = DateTime.Now;
            tblhistorylogin.Active = true;
            
            db.tblHistoryLogins.Add(tblhistorylogin);
            db.SaveChanges();
           
        }
    }
}