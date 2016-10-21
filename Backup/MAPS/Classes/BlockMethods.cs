using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects;

namespace MAPS
{
    public class BlockMethods
    {
        public Block Get(long id)
        {
            using (DefaultCS db = new DefaultCS())
            {
                db.Blocks.MergeOption = MergeOption.NoTracking;
                db.mRAs.MergeOption = MergeOption.NoTracking;
                db.mRANGEs.MergeOption = MergeOption.NoTracking;
                db.mDIVISIONs.MergeOption = MergeOption.NoTracking;
                db.mCIRCLEs.MergeOption = MergeOption.NoTracking;
                return db.Blocks.Include("mBEAT").Include("mBEAT.mRA").Include("mBEAT.mRA.mRANGE").Include("mBEAT.mRA.mRANGE.mSUBDIV").Include("mBEAT.mRA.mRANGE.mSUBDIV.mDIVISION").Include("mBEAT.mRA.mRANGE.mSUBDIV.mDIVISION.mCIRCLE").Where(i => i.Id == id).First();
            }
        }

        public List<Block> GetAll(long id)
        {
            using (DefaultCS db = new DefaultCS())
            {
                db.Blocks.MergeOption = MergeOption.NoTracking;
                return db.Blocks.Where(i => i.SectionId == id).ToList();
            }
        }
        public List<Block> GetAllByRange(long id)
        {
            using (DefaultCS db = new DefaultCS())
            {
                db.Blocks.MergeOption = MergeOption.NoTracking;
                return db.Blocks.Where(i => i.RangeId == id).ToList();
            }
        }

        public void Add(Block block)
        {
            using (DefaultCS db = new DefaultCS())
            {
                db.Blocks.MergeOption = MergeOption.NoTracking;
                db.Blocks.AddObject(block);
                db.SaveChanges();
            }
        }
        public void Update(Block block)
        {
            using (DefaultCS db = new DefaultCS())
            {
                var d = db.Blocks.Where(i => i.Id == block.Id).First();
                d.BlockName = block.BlockName;
                d.SectionId = block.SectionId;
                d.OfficerName = block.OfficerName;
                d.STD = block.STD;
                d.PhoneNo = block.PhoneNo;
                d.FaxNo = block.FaxNo;
                d.MobileNo = block.MobileNo;
                d.UpdatedBy = block.UpdatedBy;
                d.UpdatedDate = block.UpdatedDate;

                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (DefaultCS db = new DefaultCS())
            {
                var d = db.Blocks.Where(i => i.Id == id).First();
                db.Blocks.DeleteObject(d);
                db.SaveChanges();
            }
        }
    }
}