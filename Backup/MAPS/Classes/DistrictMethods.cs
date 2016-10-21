using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects;

namespace MAPS
{
    public class DistrictMethods
    {
        public List<District> GetAll()
        {
            using (DefaultCS db = new DefaultCS())
            {
                db.Districts.MergeOption = MergeOption.NoTracking;
                return db.Districts.ToList();
            }
        }
        public void Add(District district)
        {
            using (DefaultCS db = new DefaultCS())
            {
                db.Districts.MergeOption = MergeOption.NoTracking;
                db.Districts.AddObject(district);
                db.SaveChanges();
            }
        }
        public void Update(District district)
        {
            using (DefaultCS db = new DefaultCS())
            {
                var d = db.Districts.Where(i => i.Id == district.Id).First();
                d.DistrictName = district.DistrictName;
                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (DefaultCS db = new DefaultCS())
            {
                var d = db.Districts.Where(i => i.Id == id).First();
                db.Districts.DeleteObject(d);
                db.SaveChanges();
            }
        }
    }
}