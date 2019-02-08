using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using GulAhmedShop.Models;
using GulAhmedShop.ViewModel;
using System.IO;
namespace GulAhmedShop.Controllers
{
    public class WomenController : Controller
    {
        ApplicationDbContext _context;

        public WomenController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ViewResult Index()
        {

            var viewModel = _context.WomenDress.Include(c => c.SeasonDress).ToList();
            ViewBag.p = _context.SliderImages.ToList();
            ViewBag.w = _context.WomenDress.ToList();

            return View(viewModel);
        }
        [Authorize(Roles = RoleManager.adminRole)]
        public ActionResult Edit(int id)
        {
            var dressInDb = _context.WomenDress.SingleOrDefault(c => c.dressId == id);

            if (dressInDb == null)
                return HttpNotFound();

            var viewModel = new NewDressViewModel
            {
                WomenDress = dressInDb,
                SeasonDress = _context.SeasonDress.ToList()
            };





            return View("New", viewModel);
        }

        [HttpGet]
        [Authorize(Roles = RoleManager.adminRole)]
        public ActionResult New()
        {
            var seasonDress = _context.SeasonDress.ToList();
            var viewModel = new NewDressViewModel
            {
                WomenDress = new WomenDress { price = 1000 },
                SeasonDress = seasonDress

            };

            return View("New", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleManager.adminRole)]
        public ActionResult New(WomenDress womenDress, HttpPostedFileBase ImagePosted, HttpPostedFileBase Image2Posted, HttpPostedFileBase Image3Posted, HttpPostedFileBase Image4Posted)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewDressViewModel
                {
                    WomenDress = womenDress,
                    SeasonDress = _context.SeasonDress.ToList()
                };

                return View("New", viewModel);

            }

            if (womenDress.dressId == 0)
            {
                var fileName = Path.GetFileNameWithoutExtension(ImagePosted.FileName);
                var extension = Path.GetExtension(ImagePosted.FileName);

                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                womenDress.imagePath = "/Content/Images/Women/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/Images/Women/"), fileName);
                ImagePosted.SaveAs(fileName);


                fileName = Path.GetFileNameWithoutExtension(Image2Posted.FileName);
                extension = Path.GetExtension(Image2Posted.FileName);

                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                womenDress.otherImage1Path = "/Content/Images/Women/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/Images/Women/"), fileName);
                Image2Posted.SaveAs(fileName);

                fileName = Path.GetFileNameWithoutExtension(Image3Posted.FileName);
                extension = Path.GetExtension(Image3Posted.FileName);

                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                womenDress.otherImage2Path = "/Content/Images/Women/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/Images/Women/"), fileName);
                Image3Posted.SaveAs(fileName);

                fileName = Path.GetFileNameWithoutExtension(Image4Posted.FileName);
                extension = Path.GetExtension(Image4Posted.FileName);

                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                womenDress.otherImage3Path = "/Content/Images/Women/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/Images/Women/"), fileName);
                Image4Posted.SaveAs(fileName);

                _context.WomenDress.Add(womenDress);


            }
            else
            {
                var dressInDb = _context.WomenDress.Single(c => c.dressId == womenDress.dressId);

                dressInDb.dressName = womenDress.dressName;
                dressInDb.price = womenDress.price;
                dressInDb.SeasonDressseasonId = womenDress.SeasonDressseasonId;
                dressInDb.year = womenDress.year;

                if (ImagePosted != null)
                {
                    var filename = Path.GetFileNameWithoutExtension(ImagePosted.FileName);
                    var extension = Path.GetExtension(ImagePosted.FileName);

                    filename = filename + DateTime.Now.ToString("yymmssfff") + extension;

                    dressInDb.imagePath = "/Content/Images/Women/" + filename;


                    filename = Path.Combine(Server.MapPath("~/Content/Images/Women/"), filename);
                    ImagePosted.SaveAs(filename);
                }
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Women");
        }


        public ActionResult Cart(int id)
        {

            var viewModel = _context.WomenDress.SingleOrDefault(x => x.dressId == id);

            ViewBag.v = viewModel;

            return View(viewModel);
        }

        public ActionResult Checkout()
        {
            ViewBag.c = ok.c;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Checkout(string pid, string qty)
        {
            int id = int.Parse(pid);
            var viewModel = _context.WomenDress.SingleOrDefault(x => x.dressId == id);
            ViewBag.v = viewModel;


            foreach(var item in ok.c)
            {
                if(item.productid == int.Parse(pid))
                    {
                    item.productqty += int.Parse(qty);
                    ViewBag.c = ok.c;
                    return View();
                    }
            }

            var i = new cartItem()
            {
                productid = int.Parse(pid),
                productqty = int.Parse(qty)
            };

            ok.c.Add(i);
            ViewBag.c = ok.c;
            return View();
        }
    }
}