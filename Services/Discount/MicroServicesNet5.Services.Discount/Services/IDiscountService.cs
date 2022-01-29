using MicroServicesNet5.Services.Discount.Models;
using MicroServicesNet5.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroServicesNet5.Services.Discount.Services
{
    public interface IDiscountService
    {
        Task<Response<List<DiscountModel>>> GetAll();
        
        Task<Response<DiscountModel>> GetById(int id);

        Task<Response<NoContent>> Save(DiscountModel discountModel);

        Task<Response<NoContent>> Update(DiscountModel discountModel);

        Task<Response<NoContent>> Delete(int id);

        Task<Response<DiscountModel>> GetByCodeAndUserId(string code, string userId);
    }
}
