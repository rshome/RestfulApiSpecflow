using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using RestSharp;
using RestCountriesSpecFlow.Models;

namespace RestCountriesSpecFlow.Fixtures
{
    public class Countries
    {
        private static Uri uri;
        private static int count { get; set; }
        private static string sCode { get; set; }

        public static CountryResponse GetCountries()
        {
            uri = new Uri("http://restcountries.eu/");

            var client = new RestClient(uri);
            IRestRequest request = new RestRequest("rest/v1/all", Method.GET);

            //send request in json format
            request.RequestFormat = DataFormat.Json;

            // execute the request target
            IRestResponse<Country> response = client.Execute<Country>(request);
             
            var content = response.Content; // raw content as string
            string getcountries = JToken.Parse(content).ToString(Formatting.Indented);

            //deseralise the object into a list format matching the COuntry class.
            var countries = JsonConvert.DeserializeObject<List<Country>>(getcountries);
            //var cArray = countries.ToArray();

            //count = countries.Count;
            var countryResponse = new CountryResponse();

            countryResponse.StatusCode = (int)response.StatusCode;

            //countryResponse.StatusCode = response.StatusCode.ToString();
            countryResponse.Countries = countries;

            return countryResponse;
        }
        
    }
}
