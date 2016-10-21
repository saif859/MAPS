using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects;

namespace MAPS
{
    public class CircleMethods
    {
        public mCIRCLE Get(int id)
        {
            using (DefaultCS db = new DefaultCS())
            {
                db.mCIRCLEs.MergeOption = MergeOption.NoTracking;
                return db.mCIRCLEs.Where(i => i.CIRCLE_ID == id).First();
            }
        }

        public List<mCIRCLE> GetAll(int id)
        {
            using (DefaultCS db = new DefaultCS())
            {
                List<mCIRCLE> mc = new List<mCIRCLE>();
                db.mCIRCLEs.MergeOption = MergeOption.NoTracking;
                mc = db.mCIRCLEs.Where(i => i.WING_ID == id).ToList();

                return mc;
            }
        }

        public void Add(mCIRCLE circle)
        {
            using (DefaultCS db = new DefaultCS())
            {
                db.mCIRCLEs.MergeOption = MergeOption.NoTracking;
                db.mCIRCLEs.AddObject(circle);
                db.SaveChanges();
            }
        }
        public void Update(mCIRCLE circle)
        {
            using (DefaultCS db = new DefaultCS())
            {
                var d = db.mCIRCLEs.Where(i => i.CIRCLE_ID == circle.CIRCLE_ID).First();
                d.CIRCLE_ENAME = circle.CIRCLE_ENAME;
                d.WING_ID = circle.WING_ID;
                d.officername = circle.officername;
                d.Std = circle.Std;
                d.Phoneno = circle.Phoneno;
                d.faxno = circle.faxno;
                d.Mobileno = circle.Mobileno;
                d.Lastupdatedon = circle.Lastupdatedon;

                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (DefaultCS db = new DefaultCS())
            {
                var d = db.mCIRCLEs.Where(i => i.CIRCLE_ID == id).First();
                db.mCIRCLEs.DeleteObject(d);
                db.SaveChanges();
            }
        }
    }
}