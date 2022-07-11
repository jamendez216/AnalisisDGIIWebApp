using AnalisisDGII.BL.RecaudacionEfectiva;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnalisisDGIIWebApp.Controllers
{
    public class RecaudacionEfectivaController : Controller
    {
        RecaudacionEfectivaService service = new RecaudacionEfectivaService();
        // GET: ParqueVehicular
        public ActionResult Index()
        {
            if (Session["UserName"] != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Home");
        }

        // POST: ParqueVehicular/Create
        [HttpPost]
        public ActionResult CargarCSV(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);
                    service.CargarCSV(_path);
                    ViewBag.Message = "File Uploaded Successfully!!";
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}