using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GulAhmedShop.Models;
using System.IO;

namespace GulAhmedShop.Controllers
{
    [Authorize(Roles = RoleManager.adminRole)]
    public class ImagesController : Controller
    {
        ApplicationDbContext _context;

        public ImagesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Images
        public ActionResult Index()
        {
            return View(_context.SliderImages.ToList());

        }

        public ActionResult AddSliderImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSliderImage(SliderImages picture)
        {
            var fileName = Path.GetFileNameWithoutExtension(picture.imagePosted.FileName);
            var extension = Path.GetExtension(picture.imagePosted.FileName);

            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

            picture.imagePath = "/Content/SliderImages/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Content/SliderImages/"), fileName);
            picture.imagePosted.SaveAs(fileName);


            _context.SliderImages.Add(picture);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(SliderImages picture)
        {
            if (picture.id == 0)
            {
                var fileName = Path.GetFileNameWithoutExtension(picture.imagePosted.FileName);
                var extension = Path.GetExtension(picture.imagePosted.FileName);

                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                picture.imagePath = "/Content/SliderImages/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/SliderImages/"), fileName);
                picture.imagePosted.SaveAs(fileName);
                _context.SliderImages.Add(picture);


            }
            else
            {
                var imageInDb = _context.SliderImages.Single(c => c.id == picture.id);

                imageInDb.imageHeading = picture.imageHeading;

                if (picture.imagePosted != null)
                {
                    var filename = Path.GetFileNameWithoutExtension(picture.imagePosted.FileName);
                    var extension = Path.GetExtension(picture.imagePosted.FileName);

                    filename = filename + DateTime.Now.ToString("yymmssfff") + extension;

                    imageInDb.imagePath = "/Content/SliderImages/" + filename;
                    //imageInDb.imagePath = picture.imagePath;

                    filename = Path.Combine(Server.MapPath("~/Content/SliderImages/"), filename);
                    picture.imagePosted.SaveAs(filename);
                }
            }

            //_context.WomenDress.Add(womenDress);
            _context.SaveChanges();
            return RedirectToAction("Index", "Images");
            
        }

        public ActionResult Edit(int id)
        {
            var picture = _context.SliderImages.SingleOrDefault(c => c.id == id);

            return View("New",picture);
        }

    }
}