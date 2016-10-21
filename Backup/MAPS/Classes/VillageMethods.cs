using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects;

namespace MAPS
{
    public class VillageMethods
    {
        public List<Village> GetAll(int id)
        {
            using (DefaultCS db = new DefaultCS())
            {
                db.Villages.MergeOption = MergeOption.NoTracking;
                return db.Villages.Where(i => i.TehsilId == id).ToList();
            }
        }

        public void Add(Village village)
        {
            using (DefaultCS db = new DefaultCS())
            {
                db.Villages.MergeOption = MergeOption.NoTracking;
                db.Villages.AddObject(village);
                db.SaveChanges();
            }
        }
        public void Update(Village village)
        {
            using (DefaultCS db = new DefaultCS())
            {
                var d = db.Villages.Where(i => i.Id == village.Id).First();
                d.VillageName = village.VillageName;
                d.TehsilId = village.TehsilId;
                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (DefaultCS db = new DefaultCS())
            {
                var d = db.Villages.Where(i => i.Id == id).First();
                db.Villages.DeleteObject(d);
                db.SaveChanges();
            }
        }
    }
}