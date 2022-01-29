using MicroServicesNet5.Services.Order.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServicesNet5.Services.Order.Domain.OrderAggregate
{
    public class Address:ValueObject
    {
        public string Province { get; private set; }
        public string District { get; private set; }
        public string Street { get; private set; }
        public string Zipcode { get; private set; }
        public string Line { get; private set; }

        public Address(string province, string district, string street, string zipcode, string line)
        {
            Province = province;
            District = district;
            Street = street;
            Zipcode = zipcode;
            Line = line;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Province;
            yield return District;
            yield return Street;
            yield return Zipcode;
            yield return Line;
        }
    }
}
