using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects;

namespace MAPS
{
    public class SubDivisionMethods
    {
        public mSUBDIV Get(int id)
        {
            using (DefaultCS db = new DefaultCS())
            {
                db.mSUBDIVs.MergeOption = MergeOption.NoTracking;
                db.mDIVISIONs.MergeOption = MergeOption.NoTracking;
                return db.mSUBDIVs.Include("mDIVISION").Include("mDIVISION.mCIRCLE").Where(i => i.DIV_ID == id).First();
            }
        }

        public List<mSUBDIV> GetAll(int id)
        {
            using (DefaultCS db = new DefaultCS())
            {
                db.mSUBDIVs.MergeOption = MergeOption.NoTracking;
                return db.mSUBDIVs.Where(i => i.DIV_ID == id).ToList();
            }
        }

        public void Add(mSUBDIV division)
        {
            using (DefaultCS db = new DefaultCS())
            {
                db.mSUBDIVs.MergeOption = MergeOption.NoTracking;
                db.mSUBDIVs.AddObject(division);
                db.SaveChanges();
            }
        }
        public void Update(mSUBDIV subDivision)
        {
            using (DefaultCS db = new DefaultCS())
            {
                var d = db.mSUBDIVs.Where(i => i.SUBDIV_ID == subDivision.SUBDIV_ID).First();
                d.SUBDIV_ENAME = subDivision.SUBDIV_ENAME;
                d.DIV_ID = subDivision.DIV_ID;
                d.officername = subDivision.officername;
                d.Std = subDivision.Std;
                d.Phoneno = subDivision.Phoneno;
                d.faxno = subDivision.faxno;
                d.Mobileno = subDivision.Mobileno;
                d.UpdateOn = subDivision.UpdateOn;
                d.Lastupdatedon = subDivision.Lastupdatedon;

                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (DefaultCS db = new DefaultCS())
            {
                var d = db.mSUBDIVs.Where(i => i.SUBDIV_ID == id).First();
                db.mSUBDIVs.DeleteObject(d);
                db.SaveChanges();
            }
        }
    }
}