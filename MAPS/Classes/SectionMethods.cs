using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects;

namespace MAPS
{
    public class SectionMethods
    {
        public mRA Get(int id)
        {
            using (DefaultCS db = new DefaultCS())
            {
                db.mRAs.MergeOption = MergeOption.NoTracking;
                db.mRANGEs.MergeOption = MergeOption.NoTracking;
                db.mDIVISIONs.MergeOption = MergeOption.NoTracking;
                db.mCIRCLEs.MergeOption = MergeOption.NoTracking;
                return db.mRAs.Include("mRANGE").Include("mRANGE.mSUBDIV").Include("mRANGE.mSUBDIV.mDIVISION").Include("mRANGE.mSUBDIV.mDIVISION.mCIRCLE").Where(i => i.RASST_ID == id).First();
            }
        }

        public List<mRA> GetAll(int id)
        {
            using (DefaultCS db = new DefaultCS())
            {
                db.mRAs.MergeOption = MergeOption.NoTracking;
                return db.mRAs.Where(i => i.RANGE_ID == id).ToList();
            }
        }

        public void Add(mRA section)
        {
            using (DefaultCS db = new DefaultCS())
            {
                db.mRAs.MergeOption = MergeOption.NoTracking;
                db.mRAs.AddObject(section);
                db.SaveChanges();
            }
        }
        public void Update(mRA section)
        {
            using (DefaultCS db = new DefaultCS())
            {
                var d = db.mRAs.Where(i => i.RASST_ID == section.RASST_ID).First();
                d.RANGEASST_ENAME = section.RANGEASST_ENAME;
                d.RANGE_ID = section.RANGE_ID;
                //d.OfficerName = section.OfficerName;
                d.Std = section.Std;
                d.Phoneno = section.Phoneno;
                d.faxno = section.faxno;
                d.Mobileno = section.Mobileno;
                d.UpdateOn = section.UpdateOn;

                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (DefaultCS db = new DefaultCS())
            {
                var d = db.mRAs.Where(i => i.RASST_ID == id).First();
                db.mRAs.DeleteObject(d);
                db.SaveChanges();
            }
        }
    }
}