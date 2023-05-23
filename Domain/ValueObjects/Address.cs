using Microsoft.EntityFrameworkCore;

namespace Domain.ValueObjects
{
    [Owned]
    public class Address
    {
        public string Street { get; set; } = string.Empty;
        public string Town { get; set; } = string.Empty;
        public string PostCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Address(string street, string town, string postCode, string country, double latitude, double longitude)
        {
            Street = street; Town = town; PostCode = postCode; Country = country; Latitude = latitude; Longitude = longitude;

        }

        public Address()
        {
        }
    }
}