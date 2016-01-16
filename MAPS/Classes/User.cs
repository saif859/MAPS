using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.Objects;

namespace MAPS
{
    public class EmployeeWithTypeBranch
    {
        //public Employee employee { get; set; }
        //public string eType { get; set; }
        //public string BranchName { get; set; }
    }

    public class Users
    {
        public LoginMaster GetUser(string userid, string password)
        {
            using (var db = new DefaultCS())
            {
                db.LoginMasters.MergeOption = System.Data.Objects.MergeOption.NoTracking;

                var query = (from c in db.LoginMasters
                             where c.UserId == userid && c.Password == password
                             select c).ToList();

                if (query.Count > 0)
                    return query.ToList<LoginMaster>()[0];
                else
                    return null;
            }
        }

        //public void ChangePassord(string userid, string password, string newpassword)
        //{
        //    var Emp = GetUser(userid, password);

        //    if (Emp != null)
        //    {
        //        UpdateUser(userid, newpassword);
        //    }
        //}

        public void UpdateUser(string userId, string password)
        {
            using (var db = new DefaultCS())
            {
                var newLogin = db.LoginMasters.Where(s => s.UserId == userId).FirstOrDefault();
                if (newLogin != null)
                {
                    newLogin.UserId = userId;
                    newLogin.Password = password;
                    db.SaveChanges();
                }
            }
        }
        public void Create(LoginMaster loginMaster)
        {
            using (DefaultCS db = new DefaultCS())
            {
                db.LoginMasters.MergeOption = MergeOption.NoTracking;
                db.LoginMasters.AddObject(loginMaster);
                db.SaveChanges();
            }
        }
    }
}