using AgreementSystem.Areas.Identity.Data;
using AgreementSystem.Data;
using AgreementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgreementSystem.Controllers
{
    [Authorize]
    public class AgreementController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AgreementSystemContext _Cotext;
        private readonly UserManager<AgreementSystemUser> _userManager;

        public AgreementController(ILogger<HomeController> logger, AgreementSystemContext cotext, UserManager<AgreementSystemUser> userManager)
        {
            _logger = logger;
            _Cotext = cotext;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var listAgreement = _Cotext.Agreements.ToList();
            return View(listAgreement);
        }
        
        public IActionResult CreateData()
        {
            return View(null);         
        }

        [HttpPost]
        public IActionResult CreateData(Agreement arg)
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
            return View();
        }
    }
}
