using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects;

namespace MAPS
{
    public class KhasaraMethods
    {
        public KhasaraMethods()
        {
        }

        public void Add(KhasaraDetail khasaraDetail)
        {
            DefaultCS defaultC = new DefaultCS();
            try
            {
                defaultC.KhasaraDetails.MergeOption = MergeOption.NoTracking;
                defaultC.KhasaraDetails.AddObject(khasaraDetail);
                defaultC.SaveChanges();
            }
            finally
            {
                if (defaultC != null)
                {
                    ((IDisposable)defaultC).Dispose();
                }
            }
        }

        public void Delete(int id)
        {
            DefaultCS defaultC = new DefaultCS();
            try
            {
                KhasaraDetail khasaraDetail = (
                    from i in defaultC.KhasaraDetails
                    where i.Id == id
                    select i).First<KhasaraDetail>();
                defaultC.KhasaraDetails.DeleteObject(khasaraDetail);
                defaultC.SaveChanges();
            }
            finally
            {
                if (defaultC != null)
                {
                    ((IDisposable)defaultC).Dispose();
                }
            }
        }

        public List<KhasaraDetail> GetAll(int id)
        {
            List<KhasaraDetail> list;
            DefaultCS defaultC = new DefaultCS();
            try
            {
                defaultC.KhasaraDetails.MergeOption = MergeOption.NoTracking;
                list = (
                    from i in defaultC.KhasaraDetails
                    where i.Id == id
                    select i).ToList<KhasaraDetail>();
            }
            finally
            {
                if (defaultC != null)
                {
                    ((IDisposable)defaultC).Dispose();
                }
            }
            return list;
        }

        public void Update(KhasaraDetail khasaraDetail)
        {
            DefaultCS defaultC = new DefaultCS();
            try
            {
                KhasaraDetail khasaraNo = (
                    from i in defaultC.KhasaraDetails
                    where i.Id == khasaraDetail.Id
                    select i).First<KhasaraDetail>();
                khasaraNo.KhasaraNo = khasaraDetail.KhasaraNo;
                khasaraNo.KhatauniNo = khasaraDetail.KhatauniNo;
                khasaraNo.OwnerName = khasaraDetail.OwnerName;
                khasaraNo.AreainAcres = khasaraDetail.AreainAcres;
                khasaraNo.BlockId = khasaraDetail.BlockId;
                khasaraNo.VillageId = khasaraDetail.VillageId;
                khasaraNo.AmalDaramadDate = khasaraDetail.AmalDaramadDate;
                khasaraNo.AmalDaramadNo = khasaraDetail.AmalDaramadNo;
                defaultC.SaveChanges();
            }
            finally
            {
                if (defaultC != null)
                {
                    ((IDisposable)defaultC).Dispose();
                }
            }
        }
    }
}