using MicroServicesNet5.Services.Catalog.Dtos;
using MicroServicesNet5.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroServicesNet5.Services.Catalog.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(CategoryDto categoryDto);
        Task<Response<CategoryDto>> GetByIdAsync(string id);
    }
}