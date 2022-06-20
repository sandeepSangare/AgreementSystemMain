using AgreementSystem.Data;
using AgreementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using AgreementSystem.Areas.Identity.Data;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AgreementSystem.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AgreementSystemContext _Cotext;
        private readonly UserManager<AgreementSystemUser> _userManager;

        public HomeController(ILogger<HomeController> logger, AgreementSystemContext cotext, UserManager<AgreementSystemUser> userManager)
        {
            _logger = logger;
            _Cotext = cotext;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        public ActionResult GetAgreement()
        {
            IEnumerable<AgreementView> selection = null;

            selection = (from a in _Cotext.Agreements
                         join pc in _Cotext.Products on a.Product_Id equals pc.Id
                         join c in _Cotext.ProductGroups on pc.Product_Group_Id equals c.Id
                         select new AgreementView
                         {
                             Id=a.ID,
                             Product_Group_Id = a.Product_Group_Id,
                             Group_Description = c.Group_Description,
                             Product_Description = pc.Product_Description,
                             Product_Id = a.Product_Id,
                             Effective_Date = a.Effective_Date,
                             Expiration_Date = a.Expiration_Date,
                             Product_Price = a.Product_Price,
                             New_Price = a.New_Price,
                             Active = a.Active
                         }).ToList().OrderBy(a=>a.Id);

            return Json(selection);


        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            Agreement arg = new Agreement();

            if (id != 0)
            {
                arg = (from a in _Cotext.Agreements
                       join pc in _Cotext.Products on a.Product_Id equals pc.Id
                       join c in _Cotext.ProductGroups on pc.Product_Group_Id equals c.Id
                       where a.ID == id
                       select new Agreement
                       {
                           ID = a.ID,
                           User_Id = a.User_Id,
                           Product_Group_Id = a.Product_Group_Id,
                           Product_Id = a.Product_Id,
                           Effective_Date = a.Effective_Date,
                           Expiration_Date = a.Expiration_Date,
                           Product_Price = a.Product_Price,
                           New_Price = a.New_Price,
                           Active = a.Active
                       }).FirstOrDefault();
            }
            
            var Product_Group_Id = (from ProductGroup in _Cotext.ProductGroups
                                    select new SelectListItem()
                                    {
                                        Text = ProductGroup.Group_Description,
                                        Value = ProductGroup.Id.ToString()

                                    }).ToList();

            var Product_Id = (from Products in _Cotext.Products
                              select new SelectListItem()
                              {
                                  Text = Products.Product_Description,
                                  Value = Products.Id.ToString()

                              }).ToList();
            ViewBag.Product_Group_Id = Product_Group_Id;
            ViewBag.Product_Id = Product_Id;
            
            return PartialView("AgreementAddModel", arg);
        
        }

        [HttpGet]
        public IActionResult Product_Group(int id)
        {
            var Product_Group_Id = _Cotext.Products.Where(c => c.Product_Group_Id == id);
            return Json(Product_Group_Id);
        }


        [HttpPost]
        public IActionResult Create(Agreement arg)
        {
            if (ModelState.IsValid)
            {
                var id = arg.ID;
                arg.User_Id = _userManager.GetUserId(User);
                if (id == 0)
                {
                    _Cotext.Agreements.Add(arg);
                    _Cotext.SaveChanges();
                }
                else
                {
                    _Cotext.Agreements.Update(arg);
                    _Cotext.SaveChanges();
                }
                return Ok();
            }
            return BadRequest("Error in page"); ;
        }

        [HttpPost]
        public IActionResult DeleteAgreement(int? id)
        {
            var Agreements = _Cotext.Agreements.Find(id);
            if (id == null)
            return Json(data: "Not Deleted");
            _Cotext.Agreements.Remove(Agreements);
            _Cotext.SaveChanges();
            return Json(data: "Deleted");
            
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
