using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestCountriesSpecFlow.Fixtures;
using RestCountriesSpecFlow.Models;
using System.Collections.Generic;

namespace RestCountriesSpecFlow
{
    [Binding]
    public class GetCountriesCountSteps
    {
        [BeforeScenario]
        public static void Initialize()
        {
            NoCountries = new CountryResponse();
        }

        private static CountryResponse NoCountries = null;

        [Given(@"I have access to the restcountries API")]
        public void GivenIHaveAccessToTheRestcountriesAPI()
        {
            
        }
        
        [When(@"I generate a restful request (.*)")]
        public void WhenIGenerateARestfulRequest(int p0)
        {
            NoCountries = RestCountriesSpecFlow.Fixtures.Countries.GetCountries();
        }
        
        [Then(@"the api response returns (.*)")]
        public void ThenTheApiResponseReturns(int countries)
        {            
            Assert.AreEqual(countries, NoCountries.Countries.Count);           
        }

        [Then(@"I receive a successful response (.*)")]
        public void ThenIReceiveASuccessfulResponse(int response)
        {
            Assert.AreEqual(response, NoCountries.StatusCode);
            
        }


    }
}
