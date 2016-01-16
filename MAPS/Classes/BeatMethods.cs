using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects;

namespace MAPS
{
    public class BeatMethods
    {
        public mBEAT Get(long id)
        {
            using (DefaultCS db = new DefaultCS())
            {
                db.mBEATs.MergeOption = MergeOption.NoTracking;
                db.mRAs.MergeOption = MergeOption.NoTracking;
                db.mRANGEs.MergeOption = MergeOption.NoTracking;
                db.mDIVISIONs.MergeOption = MergeOption.NoTracking;
                db.mCIRCLEs.MergeOption = MergeOption.NoTracking;
                return db.mBEATs.Include("mRA").Include("mRA.mRANGE").Include("mRA.mRANGE.mSUBDIV").Include("mRA.mRANGE.mSUBDIV.mDIVISION").Include("mRA.mRANGE.mSUBDIV.mDIVISION.mCIRCLE").Where(i => i.BEAT_ID == id).First();
            }
        }

        public List<mBEAT> GetAll(long id)
        {
            using (DefaultCS db = new DefaultCS())
            {
                db.mBEATs.MergeOption = MergeOption.NoTracking;
                return db.mBEATs.Where(i => i.RASST_ID == id).ToList();
            }
        }

        public void Add(mBEAT section)
        {
            using (DefaultCS db = new DefaultCS())
            {
                db.mBEATs.MergeOption = MergeOption.NoTracking;
                db.mBEATs.AddObject(section);
                db.SaveChanges();
            }
        }
        public void Update(mBEAT section)
        {
            using (DefaultCS db = new DefaultCS())
            {
                var d = db.mBEATs.Where(i => i.BEAT_ID == section.BEAT_ID).First();
                d.BEAT_ENAME = section.BEAT_ENAME;
                d.RASST_ID = section.RASST_ID;
                //d.OfficerName = section.OfficerName;
                d.Std = section.Std;
                d.Phoneno = section.Phoneno;
                d.faxno = section.faxno;
                d.Mobileno = section.Mobileno;
                d.UpdateOn = section.UpdateOn;

                db.SaveChanges();
            }
        }
        public void Delete(long id)
        {
            using (DefaultCS db = new DefaultCS())
            {
                var d = db.mBEATs.Where(i => i.BEAT_ID == id).First();
                db.mBEATs.DeleteObject(d);
                db.SaveChanges();
            }
        }
    }
}