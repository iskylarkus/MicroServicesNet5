using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServicesNet5.Services.Order.Application.Mapping
{
    public class ObjectMapper
    {
        private static readonly Lazy<IMapper> mapper = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CustomMapping>();
            });

            return config.CreateMapper();
        });

        public static IMapper Mapper => mapper.Value;
    }
}
