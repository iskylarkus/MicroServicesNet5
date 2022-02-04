using IdentityModel.Client;
using MicroServicesNet5.Shared.Dtos;
using MicroServicesNet5.Web.Models;
using System.Threading.Tasks;

namespace MicroServicesNet5.Web.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<Response<bool>> SignIn(SignInput signInput);

        Task<TokenResponse> GetAccessTokenByRefreshToken();

        Task RevokeRefreshToken();
    }
}
