using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects.DataClasses;

namespace MAPS
{
    public class ForestAreaMethods
    {
        public void Delete(int id)
        {
            using (DefaultCS db = new DefaultCS())
            {
                var d = db.ForestAreas.Where(i => i.Id == id).First();

                var c = db.ForestCoordinates.Where(i => i.ForestAreaId == id).ToList();
                c.ForEach(i =>
                {
                    db.ForestCoordinates.DeleteObject(i);
                });
                var b = db.GazetteDetails.Where(i => i.ForestAreaId == id).ToList();
                b.ForEach(i =>
                {
                    db.GazetteDetails.DeleteObject(i);
                });

                db.ForestAreas.DeleteObject(d);
                db.SaveChanges();
            }
        }

        public void Update(ForestArea forestArea, EntityCollection<GazetteDetail> gd)
        {
            IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);

            using (var db = new DefaultCS())
            {
                try
                {
                    var fUpdate = db.ForestAreas.Where(i => i.Id == forestArea.Id).First();

                    var arrGD = db.GazetteDetails.Where(i => i.ForestAreaId == forestArea.Id).ToList();

                    if (arrGD.Count > 0)
                    {
                        arrGD.ForEach(i => { db.GazetteDetails.DeleteObject(i); });
                    }

                    foreach (var fcc in gd)
                    {
                        db.GazetteDetails.AddObject(fcc);
                    }
                    fUpdate.NotificationNo = forestArea.NotificationNo;
                    fUpdate.NotificationType = forestArea.NotificationType;
                    fUpdate.GazetteAuthority = forestArea.GazetteAuthority;
                    fUpdate.GazetteNo = forestArea.GazetteNo;

                    fUpdate.GazetteTitle = forestArea.GazetteTitle;
                    fUpdate.PagesInEnglish = forestArea.PagesInEnglish;
                    fUpdate.PagesInHindi = forestArea.PagesInHindi;

                    fUpdate.GazetteDate = forestArea.GazetteDate;

                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                }
            }
        }

    }
}