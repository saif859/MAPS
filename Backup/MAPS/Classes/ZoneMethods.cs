using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects;

namespace MAPS
{
    public class ZoneMethods
    {
        public List<mWING> GetAll()
        {
            using (DefaultCS db = new DefaultCS())
            {
                db.mWINGs.MergeOption = MergeOption.NoTracking;
                return db.mWINGs.ToList();
            }
        }

        public mWING Get(int id)
        {
            using (DefaultCS db = new DefaultCS())
            {
                db.mWINGs.MergeOption = MergeOption.NoTracking;
                return db.mWINGs.Where(i => i.WING_ID == id).First();
            }
        }
        public void Add(mWING zone)
        {
            using (DefaultCS db = new DefaultCS())
            {
                db.mWINGs.MergeOption = MergeOption.NoTracking;
                db.mWINGs.AddObject(zone);
                db.SaveChanges();
            }
        }
        public void Update(mWING zone)
        {
            using (DefaultCS db = new DefaultCS())
            {
                var d = db.mWINGs.Where(i => i.WING_ID == zone.WING_ID).First();
                d.DESCRIPTION = zone.DESCRIPTION;

                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (DefaultCS db = new DefaultCS())
            {
                var d = db.mWINGs.Where(i => i.WING_ID == id).First();
                db.mWINGs.DeleteObject(d);
                db.SaveChanges();
            }
        }
    }
}