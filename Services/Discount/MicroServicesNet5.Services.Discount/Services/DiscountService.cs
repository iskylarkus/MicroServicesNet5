using Dapper;
using MicroServicesNet5.Services.Discount.Models;
using MicroServicesNet5.Shared.Dtos;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServicesNet5.Services.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbConnection;

        public DiscountService(IConfiguration configuration)
        {
            _configuration = configuration;

            _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSql"));
        }

        public async Task<Response<NoContent>> Delete(int id)
        {
            var status = await _dbConnection.ExecuteAsync("delete from discount where id = @Id", new { Id = id });

            return status > 0 ? Response<NoContent>.Success(204) : Response<NoContent>.Fail("Discount not found", 404);
        }

        public async Task<Response<List<DiscountModel>>> GetAll()
        {
            var discounts = await _dbConnection.QueryAsync<DiscountModel>("select * from discount");

            return Response<List<DiscountModel>>.Success(discounts.ToList(), 200);
        }

        public async Task<Response<DiscountModel>> GetByCodeAndUserId(string code, string userId)
        {
            var discount = (await _dbConnection.QueryAsync<DiscountModel>("select * from discount where userid = @UserId and code = @Code",
                new { UserId = userId, Code = code })).SingleOrDefault();

            if (discount == null)
            {
                return Response<DiscountModel>.Fail("Discount not found", 404);
            }

            return Response<DiscountModel>.Success(discount, 200);
        }

        public async Task<Response<DiscountModel>> GetById(int id)
        {
            var discount = (await _dbConnection.QueryAsync<DiscountModel>("select * from discount where id = @Id", new { Id = id })).SingleOrDefault();

            if (discount == null)
            {
                return Response<DiscountModel>.Fail("Discount not found", 404);
            }

            return Response<DiscountModel>.Success(discount, 200);
        }

        public async Task<Response<NoContent>> Save(DiscountModel discountModel)
        {
            var status = await _dbConnection.ExecuteAsync("insert into discount (userid, rate, code) values (@UserId, @Rate, @Code)", discountModel);

            if (status > 0)
            {
                return Response<NoContent>.Success(204);
            }

            return Response<NoContent>.Fail("an error occurred while adding", 500);
        }

        public async Task<Response<NoContent>> Update(DiscountModel discountModel)
        {
            var status = await _dbConnection.ExecuteAsync("update discount set userid = @UserId, rate = @Rate, code = @Code where id = @Id",
                new { Id = discountModel.Id, UserId = discountModel.UserId, Rate = discountModel.Rate, Code = discountModel.Code });

            if (status > 0)
            {
                return Response<NoContent>.Success(204);
            }

            return Response<NoContent>.Fail("Discount not found", 404);
        }
    }
}
