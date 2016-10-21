using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data.Objects.DataClasses;
using System.Data.Objects;
using System.IO;

namespace MAPS
{
    /// <summary>
    /// Summary description for AddArea
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AddArea : System.Web.Services.WebService
    {
        [WebMethod]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = false, ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public Int64? InsertArea(ForestArea forestArea, ForestCoordinate[] forestCoordinates)
        {
            using (var db = new DefaultCS())
            {
                try
                {
                    EntityCollection<ForestCoordinate> fc = new EntityCollection<ForestCoordinate>();
                    foreach (var fcc in forestCoordinates)
                    {
                        fc.Add(fcc);
                    }
                    forestArea.ForestCoordinates = fc;
                    forestArea.CreatedDate = DateTime.Now;
                    db.ForestAreas.AddObject(forestArea);
                    db.SaveChanges();
                    return forestArea.Id;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        [WebMethod]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = false, ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public Int64? InsertArea1(ForestArea forestArea, CadastralPoint[] cadastralPoints)
        {
            using (var db = new DefaultCS())
            {
                try
                {
                    if (cadastralPoints != null)
                    {
                        EntityCollection<CadastralPoint> cp = new EntityCollection<CadastralPoint>();
                        foreach (var cpp in cadastralPoints)
                        {
                            cp.Add(cpp);
                        }
                        forestArea.CadastralPoints1 = cp;
                    }
                    forestArea.CreatedDate = DateTime.Now;
                    db.ForestAreas.AddObject(forestArea);
                    db.SaveChanges();
                    return forestArea.Id;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }


        [WebMethod]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = false, ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public Int64? UpdateArea(ForestArea forestArea, ForestCoordinate[] forestCoordinates)
        {
            IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);

            using (var db = new DefaultCS())
            {
                try
                {
                    var fUpdate = db.ForestAreas.Where(i => i.Id == forestArea.Id).First();

                    foreach (var fcc in forestCoordinates)
                    {
                        var forestC = db.ForestCoordinates.Where(i => i.Id == fcc.Id).First();
                        forestC.BackBearings = fcc.BackBearings;
                        forestC.BackDistanceInChain = fcc.BackDistanceInChain;
                        forestC.BackDistanceInMeter = fcc.BackDistanceInMeter;
                        forestC.BearingDifference = fcc.BearingDifference;
                        forestC.ForwardBearings = fcc.ForwardBearings;
                        forestC.Latitude = fcc.Latitude;
                        forestC.Longitude = fcc.Longitude;
                        forestC.PillarNo = fcc.PillarNo;
                        forestC.LatitudeField = fcc.LatitudeField;
                        forestC.LongitudeField = fcc.LongitudeField;
                    }
                    fUpdate.AreaInField = forestArea.AreaInField;
                    fUpdate.AreaCalculated = forestArea.AreaCalculated;
                    fUpdate.AreaInGazette = forestArea.AreaInGazette;
                    fUpdate.BlockId = forestArea.BlockId;
                    fUpdate.ForestName = forestArea.ForestName;
                    fUpdate.ForestType = forestArea.ForestType;
                    fUpdate.GazetteNo = forestArea.GazetteNo;
                    fUpdate.isReferencePoint = forestArea.isReferencePoint;
                    fUpdate.NumberOfPillars = forestArea.NumberOfPillars;
                    fUpdate.VillageId = forestArea.VillageId;

                    //fUpdate.GazetteDate = DateTime.Parse(forestArea.GazetteDate.ToString(), provider);
                    fUpdate.GazetteDate = forestArea.GazetteDate;
                    fUpdate.UpdatedDate = DateTime.Now;
                    fUpdate.UpdatedBy = forestArea.UpdatedBy;

                    db.SaveChanges();
                    return forestArea.Id;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        [WebMethod]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = false, ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public Int64? UpdateArea1(ForestArea forestArea, CadastralPoint[] cadastralPoints)
        {
            IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);

            using (var db = new DefaultCS())
            {
                try
                {
                    var fUpdate = db.ForestAreas.Where(i => i.Id == forestArea.Id).First();

                    if (cadastralPoints != null)
                    {
                        foreach (var cpp in cadastralPoints)
                        {
                            try
                            {
                                var CC = db.CadastralPoints.Where(i => i.ForestAreaId == fUpdate.Id);
                                foreach (CadastralPoint ccc in CC)
                                {
                                    db.CadastralPoints.DeleteObject(ccc);
                                }
                            }
                            catch (Exception) { }
                            cpp.ForestAreaId = fUpdate.Id;
                            db.CadastralPoints.AddObject(cpp);
                        }
                    }

                    fUpdate.AreaInGazette = forestArea.AreaInGazette;
                    fUpdate.BlockId = forestArea.BlockId;
                    fUpdate.ForestName = forestArea.ForestName;
                    fUpdate.ForestType = forestArea.ForestType;
                    fUpdate.GazetteNo = forestArea.GazetteNo;
                    fUpdate.CadastralPoints = forestArea.CadastralPoints;
                    fUpdate.VillageId = forestArea.VillageId;

                    //fUpdate.GazetteDate = DateTime.Parse(forestArea.GazetteDate.ToString(), provider);
                    fUpdate.GazetteDate = forestArea.GazetteDate;
                    fUpdate.UpdatedDate = DateTime.Now;
                    fUpdate.UpdatedBy = forestArea.UpdatedBy;

                    db.SaveChanges();
                    return forestArea.Id;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        [WebMethod]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = false, ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public dynamic GetCoordinates(int id)
        {
            var db = new DefaultCS();
            {
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = false;

                    return db.ForestCoordinates.Where(i => i.ForestAreaId == id).Select(i => new { i.Id, i.BackBearings, i.BackDistanceInChain, i.BackDistanceInMeter, i.BearingDifference, i.ForestAreaId, i.ForwardBearings, i.Latitude, i.Longitude, i.PillarNo, i.LatitudeField, i.LongitudeField }).ToList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        [WebMethod]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = false, ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public dynamic GetCadastral(int id)
        {
            var db = new DefaultCS();
            {
                try
                {
                    db.ContextOptions.ProxyCreationEnabled = false;

                    return db.CadastralPoints.Where(i => i.ForestAreaId == id).Select(i => new { i.Id, i.ForestAreaId, i.Latitude, i.Longitude, i.PillarNo }).ToList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        [WebMethod]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = false, ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public int InsertBlock(Block block)
        {
            using (DefaultCS db = new DefaultCS())
            {
                db.Blocks.MergeOption = MergeOption.NoTracking;
                db.Blocks.AddObject(block);
                db.SaveChanges();
                return block.Id;
            }
        }

        [WebMethod]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = false, ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public int InsertVillage(Village village)
        {
            using (DefaultCS db = new DefaultCS())
            {
                db.Villages.MergeOption = MergeOption.NoTracking;
                db.Villages.AddObject(village);
                db.SaveChanges();
                return village.Id;
            }
        }

        [WebMethod]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = false, ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public void RenameImage(string name, string strCode)
        {
            string fromFile = "";
            string toFile = "";
            string photoPath = Server.MapPath("~/MAP");
            string[] files = Directory.GetFiles(photoPath, strCode + "_*");
            if (files.Length > 0)
            {
                foreach (string photo in files)
                {
                    fromFile = Server.MapPath("~/MAP/") + Path.GetFileName(photo);
                    toFile = Server.MapPath("~/MAP/") + Path.GetFileName(photo).Replace(strCode, name);
                    File.Move(fromFile, toFile);
                }
            }
        }

    }
}
