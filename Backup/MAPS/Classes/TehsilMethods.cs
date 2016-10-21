using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects;

namespace MAPS
{
    public class TehsilMethods
    {
        public List<Tehsil> GetAll(int id)
        {
            using (DefaultCS db = new DefaultCS())
            {
                db.Tehsils.MergeOption = MergeOption.NoTracking;
                return db.Tehsils.Where(i => i.DistrictId == id).ToList();
            }
        }
        public void Add(Tehsil tehsil)
        {
            using (DefaultCS db = new DefaultCS())
            {
                db.Tehsils.MergeOption = MergeOption.NoTracking;
                db.Tehsils.AddObject(tehsil);
                db.SaveChanges();
            }
        }
        public void Update(Tehsil tehsil)
        {
            using (DefaultCS db = new DefaultCS())
            {
                var d = db.Tehsils.Where(i => i.Id == tehsil.Id).First();
                d.TehsilName = tehsil.TehsilName;
                d.DistrictId = tehsil.DistrictId;
                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (DefaultCS db = new DefaultCS())
            {
                var d = db.Tehsils.Where(i => i.Id == id).First();
                db.Tehsils.DeleteObject(d);
                db.SaveChanges();
            }
        }
    }
}