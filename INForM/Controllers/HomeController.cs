﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using INForM.Models;
using IN4MDatabase;
using System.Web.Security;

namespace INForM.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        iN4MEntities _entities = new iN4MEntities();
        // GET: Home
        public ActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login", new { area = "" });
        }

        [HttpGet]
        public ActionResult GetDashBordData()
        {
            var jsondata = _entities.SpGetDashBordData().ToList();
            return Json(new {data=jsondata}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Assets()
        {
            return View();
        }

        

       [HttpPost]
        public ActionResult GetAssetsTypeAgainstLocation(String loc)
        {
            var jsondata = _entities.SpGetAssetsTypeAgainstLocation(loc).ToList();
            return Json(new { data = jsondata });
        }

        [HttpGet]
        public ActionResult GetAssest(String values)
        {
            var jsondata = _entities.SpGetAssets(values).ToList();
            return Json(new { data = jsondata }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Components()
        {
            return View();
        }


        [HttpGet]
        public ActionResult GetBeforeFilterationData()
        {
            var jsondata = _entities.SpGetBeforeFilterationData().ToList();
            return Json(new { data = jsondata }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetAfterFilter(String query)
        {
            var jsondata = _entities.SpGetAfterFilter(query).ToList();
            return Json(new { data = jsondata });
        }

        [HttpGet]
        public ActionResult Inceptions()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var list = _entities.SpGetLookUpInspectionStatus().ToList();
            foreach (var lookupWorkOrderStatu in list)
            {
                items.Add(new SelectListItem()
                {
                    Text = lookupWorkOrderStatu.InspectionStatus,
                    Value = lookupWorkOrderStatu.InspectionStatusID.ToString()
                });
            }
            ViewData["Istatus"] = items;
            List<SelectListItem> items2 = new List<SelectListItem>();
            var list2 = _entities.SpGetWorkOrderEssentialInfo().ToList();
            foreach (var lookupWorkOrderStatu in list2)
            {
                items2.Add(new SelectListItem()
                {
                    Text = lookupWorkOrderStatu.WorkOrderName,
                    Value = lookupWorkOrderStatu.WorkOrdersID.ToString()
                });
            }
            ViewData["ExisitngWON"] = items;
            return View();
        }

        [HttpGet]
        public ActionResult WorkOrder()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var list = _entities.SpGetLookUpWorkOrder().ToList();
            foreach (var lookupWorkOrderStatu in list)
            {
                items.Add(new SelectListItem()
                {
                    Text = lookupWorkOrderStatu.WorkOrderStatus,
                    Value = lookupWorkOrderStatu.WorkOrderStatusID.ToString()
                });
            }
            ViewData["status"] = items;
            List<SelectListItem> items2 = new List<SelectListItem>();
            var list2 = _entities.SpgetLookupworkOrderPerioerty().ToList();
            foreach (var lookupWorkOrderperio in list2)
            {
                items2.Add(new SelectListItem()
                {
                    Text = lookupWorkOrderperio.WorkOrderPriority,
                    Value = lookupWorkOrderperio.WorkOrderPriorityID.ToString()
                });
            }
            ViewData["Periorities"] = items2;
            return View();
        }

        [HttpGet]
        public ActionResult PeoplePlaces()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Treatments()
        {
            return View();
        }


        [HttpPost]
        public ActionResult TreatmentsPost(string searchterm)
        {
            var result = _entities.Treatments.Select(x => x.TreatmentsName).Where(y => y.StartsWith(searchterm));
            return Json(new {d=result});
        }


        [HttpGet]
        public ActionResult GetBeforeFilterationTreamtmentData()
        {
            var jsondata = _entities.spGetTreamtneInfo().ToList();
            return Json(new { data = jsondata }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Material(String query)
        {
            var jsondata = _entities.SpGetMaterialOfTreatment(query).ToList();
            return Json(new { data = jsondata });
        }

        [HttpPost]
        public ActionResult SupplierInformation(String query)
        {
            var jsondata = _entities.SpGetSupplierInfo(query).ToList();
            return Json(new { data = jsondata });
        }



        [HttpPost]
        public ActionResult AllAssestsName(string searchterm)
        {
            var result = _entities.Treatments.Select(x => x.TreatmentsName).Where(y => y.StartsWith(searchterm));
            return Json(new { d = result });
        }


        [HttpPost]
        public ActionResult AdDComponent(String CName, String CDsic, String Assets, String IDate, String DDate, String Material, String Util,String EExpo,String CompCat,String CompF)
        {
            var result =
                _entities.SpAddComponent(CName, CDsic, Assets, IDate, DDate, Material, Util, EExpo, CompCat, CompF)
                    .FirstOrDefault();
            if (result!=null)
            {
                return Json(new {d = result.Value});
            }
            return Json(new {d=0});
        }


        [HttpGet]
        public ActionResult GetLocation()
        {
            var jsondata = _entities.spGetLocation().ToList();
            return Json(new { data = jsondata }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetStaff()
        {
            var jsondata = _entities.SpGetStaff().ToList();
            return Json(new { data = jsondata }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult DelLoc()
        {
            return null;
        }

        [HttpPost]
        public ActionResult CreateLocation(String campName,String building,String floor,String rom)
        {
            var result = _entities.SpCreateLocation(campName, building, floor, rom).FirstOrDefault();
            if (result != null)
            {
                return Json(new { d = result.Value });
            }
            return Json(new { d = 0 });
        }

        [HttpPost]
        public ActionResult CreateStaff(String staffName, String staffDis, String department, String roll,String contact)
        {
            var result = _entities.spCreateStaff(staffName,staffDis,department, roll,contact).FirstOrDefault();
            if (result != null)
            {
                return Json(new { d = result.Value });
            }
            return Json(new { d = 0 });
        }

        [HttpPost]
        public ActionResult CreateTreatment(String tName, String tDis, String supplirName, String billqty, String unitRate,String tType)
        {
            var result = _entities.SpCreateTreatment(tName, tDis, supplirName, billqty, unitRate,tType).FirstOrDefault();
            if (result != null)
            {
                return Json( new{ k = result.Value });
            }
            return Json(new { k = 0 });
        }

        [HttpGet]
        public ActionResult EditTreatments(String id)
        {
            var result = _entities.SpGetEditTreatmentData(id).FirstOrDefault();
            TreatmentEidtModel models = null;
            if (result != null)
            {
                 models = new TreatmentEidtModel()
                {
                    TreatmentName = result.TreatmentsName,
                    TreatmentDiscription = result.TreatmentsDescription,
                    SupplierName = result.SupplierName,
                    BillofQty = result.BillOfQuantityName,
                    TreatType = result.TreatType,
                    TotalUnit = result.TotalUnitRate.ToString(),
                    TreatID = id
                };
            }
            return View("EditTreatments",models);
        }

        [HttpPost]
        [ActionName("EditTreatments")]
        [ValidateAntiForgeryToken]
        public ActionResult EditTreatments_Post(TreatmentEidtModel eidtModel)
        {
            var result = _entities.SpUpdateTreatment(eidtModel.TreatID,eidtModel.TreatmentName,eidtModel.TreatmentDiscription,
                eidtModel.SupplierName,eidtModel.BillofQty,eidtModel.TotalUnit,eidtModel.TreatType).FirstOrDefault();
           
            if (result != null & result.Value==1)
            {
                return RedirectToAction("Treatments");
            }
            return View("EditTreatments", eidtModel);
        }

        [HttpPost]
        public ActionResult DeleteTreatment(String uid)
        {

            var entity = _entities.Treatments.First(x => x.TreatmentsID.ToString() == uid);
            _entities.Treatments.Remove(entity);
            _entities.SaveChanges();
            return RedirectToAction("Treatments");
        }

        [HttpPost]
        public ActionResult DeleteStff(String uid)
        {

            var entity = _entities.Staffs.First(x => x.StaffID.ToString() == uid);
            _entities.Staffs.Remove(entity);
            _entities.SaveChanges();
            return RedirectToAction("PeoplePlaces");
        }

        [HttpPost]
        public ActionResult DeleteLocation(String uid)
        {

            //var entity = _entities.Locations.First(x => x.LocationID.ToString() == uid);
            //var entity2 = _entities.Assets.First(x => x.LocationID.ToString() == uid);
            //var entity3 = _entities.Components.First(x => x.AssetID == entity2.AssetID);
            //_entities.Components.Remove(entity3);
            //_entities.Assets.Remove(entity2);
            //_entities.Locations.Remove(entity);
            //_entities.SaveChanges();
            return RedirectToAction("PeoplePlaces");
        }

        [HttpGet]
        public ActionResult GetWorkOrderFilterData(string status,String perioerties)
        {

            var jsondata = _entities.spGetWorkOrderFilters(status,perioerties).ToList();
            return Json(new { data = jsondata }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetWorkOrderData(string uid)
        {

            var jsondata = _entities.SpGetWorkOrderInfo(uid).FirstOrDefault();
            return Json(new { d1 = jsondata.WorkOrderName, d2 = jsondata.WorkOrderStatus, d3 = jsondata.WorkOrderPriorityStatus, d4 = jsondata.CommencementDate.ToString(), d5 = jsondata.CompletionDate.ToString() }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult GetInceptionData()
        {
            var jsondata = _entities.spGetInceptionData().ToList();
            return Json(new { data = jsondata }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetInceptionDetailsData(string uid)
        {
            var jsondata = _entities.SpGetInceptionDetails(uid).ToList();
            return Json(new { data = jsondata }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteInception(String uid)
        {

            var entity = _entities.ComponentInspections.First(x => x.ComponentInspectionsID.ToString() == uid);
            _entities.ComponentInspections.Remove(entity);
            _entities.SaveChanges();
            return RedirectToAction("WorkOrder");
        }

        [HttpPost]
        public ActionResult CreateInception(String IName, String IDsic, String INote,
            String ICreD, String ICloD, String tName, String CName, String SName, String IPeriority, String IStaus,
            String WOrder)
        {
            var result = _entities.SpCreateInception(IName,IDsic,INote,ICreD,ICloD,tName,CName,SName,IPeriority,IStaus,WOrder).FirstOrDefault();
            if (result != null)
            {
                return Json(new { k = result.Value });
            }
            return Json(new { k = 0 });
        }


        [HttpGet]
        public ActionResult GetInspectionFilterData(string status,string loc)
        {
            var jsondata = _entities.SpFilterInspection(status,loc).ToList();
            return Json(new { data = jsondata }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddtoNewWorkOrder(String values,List<String> workordervalues,
            String WOName, String WDsic, String wStatus, String IComD, String ICloD,
            String WOEstCost, String WOActCost, String DecP, String TWOEstCost, String WOPer)
        {
            
                var jsondata= _entities.SpCreateInception(values.First().ToString(), WOName, WDsic, wStatus, IComD, ICloD, WOEstCost,
                    WOActCost, DecP, TWOEstCost, WOPer).First();
                return Json(new { data = jsondata }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddtoExisting(List<String> values,String WOID)
        {
            foreach (var item in values)
            {
                _entities.spUpdateInspection(item,WOID);
            }
            return Json(new { data = 1 }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult ComboInspecStatus(string uid)
        {

            var jsondata = _entities.ComboInspecStatus(uid).ToList();
            return Json(new { data = jsondata }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ComboInspecPeriority(string uid)
        {

            var jsondata = _entities.ComboInspecPeriority(uid).ToList();
            return Json(new { data = jsondata }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult ComboInspectionComponentName(string uid)
        {

            var jsondata = _entities.ComboInspectionComponentName(uid).ToList();
            return Json(new { data = jsondata }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult ComboInspectionCampus(string uid)
        {

            var jsondata = _entities.ComboInspectionCampus(uid).ToList();
            return Json(new { data = jsondata }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ComboInspectionBuilding(string uid)
        {

            var jsondata = _entities.ComboInspectionBuilding(uid).ToList();
            return Json(new { data = jsondata }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult ComboInspectionFloor(string uid)
        {

            var jsondata = _entities.ComboInspectionFloor(uid).ToList();
            return Json(new { data = jsondata }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult ComboInspectionRoom(string uid)
        {

            var jsondata = _entities.ComboInspectionRoom(uid).ToList();
            return Json(new { data = jsondata }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GeneralWorker(string uid)
        {

            var jsondata = _entities.SpWorkerGenral(uid).FirstOrDefault();
            return Json(new { componentID = jsondata.ComponentID.ToString(), LocationID= jsondata.LocationID.ToString() }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AttributeData(string uid)
        {
            var jsondata = _entities.AttributeGeneral(uid).FirstOrDefault();

            if (jsondata != null)
                return Json(new
                    {
                        creationDate = jsondata.InspectionCreationDate.ToString(),
                        ClosedDate = jsondata.InspectionCloseDate.ToString(),
                        inspectionNote=jsondata.ComponentInspectionNotes.ToString(),
                        workOrderName=jsondata.WorkOrderName
                    },
                    JsonRequestBehavior.AllowGet);
            return null;
        }


        [HttpGet]
        public ActionResult TreatmentCombo(string uid)
        {

            var jsondata = _entities.SpAttribTreat(uid).ToList();
            return Json(new { data = jsondata }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ConditionCombo(string uid)
        {

            var jsondata = _entities.PerforConditionScore(uid).ToList();
            return Json(new { data = jsondata }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ApperenceCombo(string uid)
        {

            var jsondata = _entities.PerforAppearenceScore(uid).ToList();
            return Json(new { data = jsondata }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult PerformaceData(string uid)
        {
            var jsondata = _entities.AttributeGeneral(uid).FirstOrDefault();

            if (jsondata != null)
                return Json(new
                {
                    creationDate = jsondata.InspectionCreationDate.ToString(),
                    ChangeDate = jsondata.InspectionCloseDate.ToString(),
                    inspectionNote = jsondata.ComponentInspectionNotes.ToString(),
                    workOrderName = jsondata.WorkOrderName
                },
                    JsonRequestBehavior.AllowGet);
            return null;
        }

        [HttpGet]
        public ActionResult FinanceData(string uid)
        {
            var jsondata = _entities.SpInspectionTreatment(uid).FirstOrDefault();


            if (jsondata != null)
                return Json(new
                    {
                        treatement = jsondata.TreatmentsName.ToString(),
                        Dim = jsondata.Dimension.ToString(),
                        EstMatCost = jsondata.UnitRate.Value.ToString(),
                        estLabourCost = jsondata.UnitRatePH.Value.ToString(),
                        estTotalCost=jsondata.EstCost.Value.ToString()
                    },
                    JsonRequestBehavior.AllowGet);
            return null;
        }

        [HttpGet]
        public ActionResult LoadOverDueInspection()
        {
            var jsondata = _entities.spOverDueInspection().FirstOrDefault();
            return Json(new { ODI=jsondata }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult LoadOverDueWorkOrder()
        {
            var jsondata = _entities.SpOverDueWorkOrder().FirstOrDefault();
            return Json(new { ODW = jsondata }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ActiveInspections()
        {
            var jsondata = _entities.SpActiveInspections().FirstOrDefault();
            return Json(new { ACI = jsondata }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ActiveWorkOrders()
        {
            var jsondata = _entities.spActiveWorkOrders().FirstOrDefault();
            return Json(new { ACWO = jsondata }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetOnlyAssestAndLoc()
        {
            var jsondata = _entities.spGetOnlyAssestInfo().ToList();
            return Json(new { data = jsondata }, JsonRequestBehavior.AllowGet);
        }
        

        [HttpGet]
        public ActionResult OrgName()
        {
            var jsondata = _entities.SpGetCompanyInfo().FirstOrDefault();
            return Json(new { Name = jsondata }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetComponent(String query)
        {
            var jsondata = _entities.SpGetComponent(query).ToList();
            return Json(new { data = jsondata });
        }

        [HttpPost]
        public ActionResult AttributeInfo(String uid)
        {
            var jsondata = _entities.SpgetAssCompoAttrib(uid).FirstOrDefault();
            return Json(new {CN=jsondata.ComponentName,CD=jsondata.ComponentDescription,
            CM=jsondata.Material,CU=jsondata.Utilisation,CX=jsondata.EnvironmentalExposure,CC=jsondata.CompCat,CF=jsondata.CompCoF});
        }

        [HttpPost]
        public ActionResult FinanceInfo(String uid)
        {
            var jsondata = _entities.SpGetAssCompoFinance(uid).FirstOrDefault();
            return Json(new
            {
                UR = jsondata.UnitRate,
                QT = jsondata.Quantity,
                DI = jsondata.Dimension,
                RC = jsondata.ReplacementCost
            });
        }

        [HttpPost]
        public ActionResult PerfoInfo(String uid)
        {
            var jsondata = _entities.SpGetAssCompoPerfor(uid).FirstOrDefault();
            return Json(new
            {
                CS = jsondata.ConditionScore,
                AS = jsondata.AppearanceScore,
                LC = jsondata.LifecycleCurve,
                DI = jsondata.DateInspected.ToString(),
                DIC = jsondata.DateConditionChange.ToString(),
                DA = jsondata.DataAccuracy

            });
        }
    }
}