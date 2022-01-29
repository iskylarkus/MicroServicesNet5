using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServicesNet5.Services.Order.Application.Dtos
{
    public class AddressDto
    {
        public string Province { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string Zipcode { get; set; }
        public string Line { get; set; }
    }
}
