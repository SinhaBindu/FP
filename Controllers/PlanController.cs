﻿using FP.Manager;
using FP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Web;
using System.Web.Mvc;
using static FP.Manager.Enums;

namespace FP.Controllers
{
    [Authorize]
    public class PlanController : Controller
    {
        FP_DBEntities db = new FP_DBEntities();
        JsonResponseData response = new JsonResponseData();
        int result = 0; bool CheckStatus = false;
        string MSG = string.Empty;
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreatePlan(Guid? Id)
        {
            PlanModel model = new PlanModel();
            if (Id != Guid.Empty)
            {
                var tbl = db.tbl_Plan.Find(Id);
                if (tbl != null)
                {
                    model.PlanID_pk = tbl.PlanID_pk;
                    model.DistrictId_fk = tbl.DistrictId_fk;
                    model.BlockId_fk = tbl.BlockId_fk;
                    model.CLFId_fk = tbl.CLFId_fk;
                    model.PanchayatId_fk = tbl.PanchayatId_fk;
                    model.VoId_fk = tbl.VoId_fk;
                    model.PlanMonth = tbl.PlanMonth;
                    model.PlanYear = tbl.PlanYear;
                    model.PlanDt = tbl.PlanDt;
                    model.HVDt = tbl.HVDt;
                    if (tbl.IsPlanAchv.Value)
                    {
                        model.IsPlanAchv = tbl.IsPlanAchv.Value;
                        model.IsBFY = tbl.IsBFY;
                        model.DOMDt = tbl.DOMDt;
                        model.DOMHVDt = tbl.DOMHVDt;
                    }
                    model.SubjectId = tbl.SubjectId;
                }
            }
            return View(model);
        }
        [HttpPost]
        public JsonResult CreatePlan(PlanModel model)
        {
            int res = 0;
            try
            {
                FP_DBEntities _db = new FP_DBEntities();
                JsonResponseData response = new JsonResponseData();
                if (!ModelState.IsValid)
                {
                    var d = Enums.GetEnumDescription(Enums.eReturnReg.AllFieldsRequired);
                    response = new JsonResponseData { StatusType = eAlertType.error.ToString(), Message = Enums.GetEnumDescription(Enums.eReturnReg.AllFieldsRequired), Data = null };
                    var resResponse3 = Json(response, JsonRequestBehavior.AllowGet);
                    resResponse3.MaxJsonLength = int.MaxValue;
                    return resResponse3;
                }
                if (model != null)
                {
                    if (_db.tbl_Plan.Any(x => x.PlanMonth == model.PlanMonth && x.PlanYear == model.PlanYear && (x.PlanID_pk != model.PlanID_pk && model.PlanID_pk == Guid.Empty)
                    && x.DistrictId_fk == model.DistrictId_fk && x.BlockId_fk == model.BlockId_fk && x.PanchayatId_fk == model.PanchayatId_fk && x.VoId_fk == model.VoId_fk))
                    {
                        response = new JsonResponseData { StatusType = eAlertType.error.ToString(), Message = Enums.GetEnumDescription(Enums.eReturnReg.Already), Data = null };
                        var resResponse3 = Json(response, JsonRequestBehavior.AllowGet);
                        resResponse3.MaxJsonLength = int.MaxValue;
                        return resResponse3;
                    }
                    if (_db.tbl_Plan.Any(x => x.PlanMonth == model.PlanMonth && x.PlanYear == model.PlanYear && (x.PlanID_pk != model.PlanID_pk)
                     && x.DistrictId_fk == model.DistrictId_fk && x.BlockId_fk == model.BlockId_fk && x.PanchayatId_fk == model.PanchayatId_fk && x.VoId_fk == model.VoId_fk))
                    {
                        response = new JsonResponseData { StatusType = eAlertType.error.ToString(), Message = Enums.GetEnumDescription(Enums.eReturnReg.Already), Data = null };
                        var resResponse3 = Json(response, JsonRequestBehavior.AllowGet);
                        resResponse3.MaxJsonLength = int.MaxValue;
                        return resResponse3;
                    }
                    var tbl = model.PlanID_pk != Guid.Empty ? _db.tbl_Plan.Find(model.PlanID_pk) : new tbl_Plan();
                    if (tbl != null)
                    {
                        tbl.PlanDt = model.PlanDt;
                        tbl.HVDt = model.HVDt;
                        if (model.IsPlanAchv)
                        {
                            tbl.IsPlanAchv = model.IsPlanAchv;
                            tbl.IsBFY = model.IsBFY;
                            tbl.DOMDt = ((model.IsBFY == 1 || model.IsBFY == 3) && model.DOMDt != null) ? model.DOMDt : null;
                            tbl.DOMHVDt = ((model.IsBFY == 2 || model.IsBFY == 3) && model.DOMHVDt != null) ? model.DOMHVDt : null;
                        }
                        else
                        {
                            tbl.IsPlanAchv = false;
                            tbl.IsBFY = null;
                            tbl.DOMDt = null;
                            tbl.DOMHVDt = null;
                        }
                        tbl.PlanMonth = model.PlanMonth;
                        tbl.PlanYear = model.PlanYear;
                        tbl.SubjectId = model.SubjectId;
                        tbl.IsActive = true;
                        if (model.PlanID_pk == Guid.Empty)
                        {
                            tbl.PlanID_pk = Guid.NewGuid();
                            tbl.DistrictId_fk = model.DistrictId_fk;
                            tbl.BlockId_fk = model.BlockId_fk;
                            tbl.CLFId_fk = model.CLFId_fk;
                            tbl.PanchayatId_fk = model.PanchayatId_fk;
                            tbl.VoId_fk = model.VoId_fk;
                            tbl.CreatedBy = User.Identity.Name;
                            tbl.CreatedOn = DateTime.Now;
                            tbl.ApprovalStatus = 0;
                            db.tbl_Plan.Add(tbl);
                            res = db.SaveChanges();
                        }
                        else
                        {
                            tbl.CLFId_fk = model.CLFId_fk;
                            tbl.PanchayatId_fk = model.PanchayatId_fk;
                            tbl.VoId_fk = model.VoId_fk;
                            tbl.UpdatedBy = User.Identity.Name;
                            tbl.UpdatedOn = DateTime.Now;
                            res += _db.SaveChanges();
                        }
                    }
                    if (res > 0)
                    {
                        response = new JsonResponseData { StatusType = eAlertType.success.ToString(), Message = Enums.GetEnumDescription(Enums.eReturnReg.Insert), Data = null };
                        var resResponse3 = Json(response, JsonRequestBehavior.AllowGet);
                        resResponse3.MaxJsonLength = int.MaxValue;
                        return resResponse3;
                    }
                }
                else
                {
                    response = new JsonResponseData { StatusType = eAlertType.error.ToString(), Message = Enums.GetEnumDescription(Enums.eReturnReg.AllFieldsRequired), Data = null };
                    var resResponse3 = Json(response, JsonRequestBehavior.AllowGet);
                    resResponse3.MaxJsonLength = int.MaxValue;
                    return resResponse3;
                }
            }
            catch (Exception)
            {
                response = new JsonResponseData { StatusType = eAlertType.error.ToString(), Message = Enums.GetEnumDescription(Enums.eReturnReg.Error), Data = null };
                var resResponse3 = Json(response, JsonRequestBehavior.AllowGet);
                resResponse3.MaxJsonLength = int.MaxValue;
                return resResponse3;
            }

            response = new JsonResponseData { StatusType = eAlertType.error.ToString(), Message = Enums.GetEnumDescription(Enums.eReturnReg.AllFieldsRequired), Data = null };
            var resResponse4 = Json(response, JsonRequestBehavior.AllowGet);
            resResponse4.MaxJsonLength = int.MaxValue;
            return resResponse4;
        }
        public PartialViewResult AchvpopForm()
        {
            ServiceBFYModel model = new ServiceBFYModel();
            //return PartialView("~/Views/ControllerName/PartalView.cshtml", model);
            return PartialView("_BFYPOP", model);
        }
        public PartialViewResult AchvpopView(Guid BFYId, Guid PlanId, Guid AchvtBFYID)
        {
            ServiceBFYModel model = new ServiceBFYModel();
            //return PartialView("~/Views/ControllerName/PartalView.cshtml", model);
            model.ServiceBFYId_pk = AchvtBFYID != Guid.Empty ? AchvtBFYID : Guid.Empty;
          //  model.PlanId_fk = PlanId;
            model.BFYId_fk = BFYId;
            return PartialView("_BFYPOPView", model);
        }

        [HttpPost]
        public JsonResult AddAchBFY(ServiceBFYModel model)
        {
            int res = 0;
            try
            {
                FP_DBEntities _db = new FP_DBEntities();
                JsonResponseData response = new JsonResponseData();
                if (!ModelState.IsValid)
                {
                    var d = Enums.GetEnumDescription(Enums.eReturnReg.AllFieldsRequired);
                    response = new JsonResponseData { StatusType = eAlertType.error.ToString(), Message = Enums.GetEnumDescription(Enums.eReturnReg.AllFieldsRequired), Data = null };
                    var resResponse3 = Json(response, JsonRequestBehavior.AllowGet);
                    resResponse3.MaxJsonLength = int.MaxValue;
                    return resResponse3;
                }
                if (model != null)
                {
                    var tbl = model.ServiceBFYId_pk != Guid.Empty ? _db.tbl_BFYService.Find(model.ServiceBFYId_pk) : new tbl_BFYService();
                    if (tbl != null)
                    {
                        tbl.IsPeerPresent = model.IsPeerPresent;
                        tbl.IsFollowUpHV = model.IsFollowUpHV;
                        if (model.IsContraception == true)
                        {
                            tbl.IsContraception = model.IsContraception;
                            tbl.ContraceptionId_fk = (model.IsContraception == true && model.ContraceptionId_fk != null) ? model.ContraceptionId_fk : null;
                            tbl.ContraceptionOther = (model.IsContraception == true && model.ContraceptionId_fk == 4) ? model.ContraceptionOther : null;
                            tbl.UseMethodId_fk = (model.IsContraception == true && model.ContraceptionId_fk != null && model.UseMethodId_fk != null) ? model.UseMethodId_fk : null;

                            tbl.Location = model.Isservice == true ? model.Location : null;
                            tbl.AashaName = model.Isservice == true ? model.AashaName : null;
                            tbl.Isservice = model.Isservice == true ? true : false;
                            tbl.ServiceProvider = model.Isservice == true ? model.ServiceProvider : null;
                            tbl.ServiceRevcDt = model.Isservice == true ? model.ServiceRevcDt : null;
                        }
                        else
                        {
                            tbl.IsContraception = null;
                            tbl.ContraceptionId_fk = null;
                            tbl.ContraceptionOther = null;
                            tbl.UseMethodId_fk = null;
                            tbl.Location = null;
                            tbl.Isservice = null;
                            tbl.ServiceProvider = null;
                            tbl.ServiceRevcDt = null;
                        }
                        tbl.IsActive = true;
                        if (model.ServiceBFYId_pk == Guid.Empty)
                        {
                            tbl.ServiceBFYId_pk = Guid.NewGuid();
                            tbl.FollowId_fk = model.FollowId_fk;
                            tbl.BFYId_fk = model.BFYId_fk;
                            tbl.CreatedBy = MvcApplication.CUser.Id;
                            tbl.CreatedOn = DateTime.Now;
                            db.tbl_BFYService.Add(tbl);
                            res = db.SaveChanges();
                        }
                        else
                        {
                            tbl.UpdatedBy = MvcApplication.CUser.Id;
                            tbl.UpdatedOn = DateTime.Now;
                            res += _db.SaveChanges();
                        }
                    }
                    if (res > 0)
                    {
                        var AchModel = new ServiceBFYModel();
                        var Achvmtpopmodal = ConvertViewToString("_BFYPOP", AchModel);
                        response = new JsonResponseData { StatusType = eAlertType.success.ToString(), Message = Enums.GetEnumDescription(Enums.eReturnReg.Insert), Data = Achvmtpopmodal };
                        var resResponse3 = Json(response, JsonRequestBehavior.AllowGet);
                        resResponse3.MaxJsonLength = int.MaxValue;
                        return resResponse3;
                    }
                }
                else
                {
                    response = new JsonResponseData { StatusType = eAlertType.error.ToString(), Message = Enums.GetEnumDescription(Enums.eReturnReg.AllFieldsRequired), Data = null };
                    var resResponse3 = Json(response, JsonRequestBehavior.AllowGet);
                    resResponse3.MaxJsonLength = int.MaxValue;
                    return resResponse3;
                }
            }
            catch (Exception)
            {
                response = new JsonResponseData { StatusType = eAlertType.error.ToString(), Message = Enums.GetEnumDescription(Enums.eReturnReg.Error), Data = null };
                var resResponse3 = Json(response, JsonRequestBehavior.AllowGet);
                resResponse3.MaxJsonLength = int.MaxValue;
                return resResponse3;
            }

            response = new JsonResponseData { StatusType = eAlertType.error.ToString(), Message = Enums.GetEnumDescription(Enums.eReturnReg.AllFieldsRequired), Data = null };
            var resResponse4 = Json(response, JsonRequestBehavior.AllowGet);
            resResponse4.MaxJsonLength = int.MaxValue;
            return resResponse4;
        }
        public ActionResult GetPlanBFYList(FilterModel model)
        {
            try
            {
                bool IsCheck = false;
                var tbllist = SP_Model.SP_PlanBFYAddServiceList(model);
                if (tbllist.Rows.Count > 0)
                {
                    IsCheck = true;
                }
                var html = ConvertViewToString("_PlanBFYData", tbllist);
                var res = Json(new { IsSuccess = IsCheck, Data = html }, JsonRequestBehavior.AllowGet);
                res.MaxJsonLength = int.MaxValue;
                return res;
            }
            catch (Exception ex)
            {
                string er = ex.Message;
                return Json(new { IsSuccess = false, Data = "" }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult PlanList()
        {
            FilterModel model = new FilterModel();
            return View(model);
        }
        public ActionResult GetPlanList(FilterModel model)
        {
            try
            {
                bool IsCheck = false;
                var tbllist = SP_Model.SP_PlanList(model);
                if (tbllist.Rows.Count > 0)
                {
                    IsCheck = true;
                }
                var html = ConvertViewToString("_PlanData", tbllist);
                var res = Json(new { IsSuccess = IsCheck, Data = html }, JsonRequestBehavior.AllowGet);
                res.MaxJsonLength = int.MaxValue;
                return res;
            }
            catch (Exception ex)
            {
                string er = ex.Message;
                return Json(new { IsSuccess = false, Data = "" }, JsonRequestBehavior.AllowGet);
            }
        }
        private string ConvertViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (StringWriter writer = new StringWriter())
            {
                ViewEngineResult vResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext vContext = new ViewContext(this.ControllerContext, vResult.View, ViewData, new TempDataDictionary(), writer);
                vResult.View.Render(vContext, writer);
                return writer.ToString();
            }
        }
    }
}