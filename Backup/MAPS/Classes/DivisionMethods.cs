using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects;

namespace MAPS
{
    public class DivisionMethods
    {
        public mDIVISION Get(int id)
        {
            using (DefaultCS db = new DefaultCS())
            {
                db.mDIVISIONs.MergeOption = MergeOption.NoTracking;
                db.mCIRCLEs.MergeOption = MergeOption.NoTracking;
                return db.mDIVISIONs.Include("mCIRCLE").Where(i => i.DIV_ID == id).First();
            }
        }

        public List<mDIVISION> GetAll(int id)
        {
            using (DefaultCS db = new DefaultCS())
            {
                db.mDIVISIONs.MergeOption = MergeOption.NoTracking;
                return db.mDIVISIONs.Where(i => i.CIRCLE_ID == id).ToList();
            }
        }

        public void Add(mDIVISION division)
        {
            using (DefaultCS db = new DefaultCS())
            {
                db.mDIVISIONs.MergeOption = MergeOption.NoTracking;
                db.mDIVISIONs.AddObject(division);
                db.SaveChanges();
            }
        }
        public void Update(mDIVISION division)
        {
            using (DefaultCS db = new DefaultCS())
            {
                var d = db.mDIVISIONs.Where(i => i.DIV_ID == division.DIV_ID).First();
                d.DIV_ENAME = division.DIV_ENAME;
                d.CIRCLE_ID = division.CIRCLE_ID;
                d.officername = division.officername;
                d.Std = division.Std;
                d.Phoneno = division.Phoneno;
                d.faxno = division.faxno;
                d.Mobileno = division.Mobileno;
                d.Lastupdatedon = division.Lastupdatedon;

                d.InstrumentModel = division.InstrumentModel;
                d.NoOfInstrument = division.NoOfInstrument;

                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (DefaultCS db = new DefaultCS())
            {
                var d = db.mDIVISIONs.Where(i => i.DIV_ID == id).First();
                db.mDIVISIONs.DeleteObject(d);
                db.SaveChanges();
            }
        }
    }
}