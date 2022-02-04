using MicroServicesNet5.Web.Models;
using MicroServicesNet5.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MicroServicesNet5.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IIdentityService _identityService;

        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInput signInput)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            var response = await _identityService.SignIn(signInput);

            if (!response.IsSuccess)
            {
                response.Errors.ForEach(error =>
                {
                    ModelState.AddModelError(string.Empty, error);
                });

                return View();
            }
            
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
