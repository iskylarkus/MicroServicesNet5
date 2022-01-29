using MicroServicesNet5.Services.Basket.Dtos;
using MicroServicesNet5.Shared.Dtos;
using System.Threading.Tasks;

namespace MicroServicesNet5.Services.Basket.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket(string userId);
        Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);
        Task<Response<bool>> DeleteBasket(string userId);
    }
}
