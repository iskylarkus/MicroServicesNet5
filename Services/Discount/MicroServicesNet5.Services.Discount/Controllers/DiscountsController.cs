using MicroServicesNet5.Services.Discount.Models;
using MicroServicesNet5.Services.Discount.Services;
using MicroServicesNet5.Shared.Controller;
using MicroServicesNet5.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MicroServicesNet5.Services.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : CustomBaseController
    {
        private readonly IDiscountService _discountService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public DiscountsController(IDiscountService discountService, ISharedIdentityService sharedIdentityService)
        {
            _discountService = discountService;
            _sharedIdentityService = sharedIdentityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResultInstance(await _discountService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResultInstance(await _discountService.GetById(id));
        }

        [HttpGet]
        //[Route("/api/[controller]/[action]/{code}/{userId}")]
        //[Route("/api/[controller]/GetByCode/{code}")]
        [Route("/api/[controller]/[action]/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            return CreateActionResultInstance(await _discountService.GetByCodeAndUserId(code, _sharedIdentityService.GetUserId));
        }

        [HttpPost]
        public async Task<IActionResult> Save(DiscountModel discountModel)
        {
            return CreateActionResultInstance(await _discountService.Save(discountModel));
        }

        [HttpPut]
        public async Task<IActionResult> Update(DiscountModel discountModel)
        {
            return CreateActionResultInstance(await _discountService.Update(discountModel));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return CreateActionResultInstance(await _discountService.Delete(id));
        }
    }
}
