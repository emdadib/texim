using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using texim.Data;
using texim.Models;

namespace texim.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Route("admin/brand/")]
    public class BrandController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BrandController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("admin/brand/list")]
        public IActionResult Index()
        {
            IEnumerable<Brand> brandlist = _db.Brands;

            return View();
        }

        [Route("admin/brand/add")]
        public IActionResult Create()
        {
            return View();
        }
    }
}
