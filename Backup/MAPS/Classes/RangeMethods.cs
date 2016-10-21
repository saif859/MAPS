using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects;

namespace MAPS
{
    public class RangeMethods
    {
        public mRANGE Get(int id)
        {
            using (DefaultCS db = new DefaultCS())
            {
                db.mRANGEs.MergeOption = MergeOption.NoTracking;
                db.mSUBDIVs.MergeOption = MergeOption.NoTracking;
                db.mDIVISIONs.MergeOption = MergeOption.NoTracking;
                db.mCIRCLEs.MergeOption = MergeOption.NoTracking;
                return db.mRANGEs.Include("mSUBDIV").Include("mSUBDIV.mDIVISION").Include("mSUBDIV.mDIVISION.mCIRCLE").Where(i => i.RANGE_ID == id).First();
            }
        }

        public List<mRANGE> GetAll(int id)
        {
            using (DefaultCS db = new DefaultCS())
            {
                db.mRANGEs.MergeOption = MergeOption.NoTracking;
                return db.mRANGEs.Where(i => i.SUBDIV_ID == id).ToList();
            }
        }

        public void Add(mRANGE range)
        {
            using (DefaultCS db = new DefaultCS())
            {
                db.mRANGEs.MergeOption = MergeOption.NoTracking;
                db.mRANGEs.AddObject(range);
                db.SaveChanges();
            }
        }
        public void Update(mRANGE range)
        {
            using (DefaultCS db = new DefaultCS())
            {
                var d = db.mRANGEs.Where(i => i.RANGE_ID == range.RANGE_ID).First();
                d.RANGE_ENAME = range.RANGE_ENAME;
                d.SUBDIV_ID = range.SUBDIV_ID;
                d.officername = range.officername;
                d.Std = range.Std;
                d.Phoneno = range.Phoneno;
                d.faxno = range.faxno;
                d.Mobileno = range.Mobileno;

                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (DefaultCS db = new DefaultCS())
            {
                var d = db.mRANGEs.Where(i => i.RANGE_ID == id).First();
                db.mRANGEs.DeleteObject(d);
                db.SaveChanges();
            }
        }
    }
}