using System.Collections.Generic;

namespace RestCountriesSpecFlow.Models
{
    public class CountryResponse
    {
        public int StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public List<Country> Countries { get; set; }
    }
}
