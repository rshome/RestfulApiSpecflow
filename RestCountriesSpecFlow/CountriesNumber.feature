Feature: GetCountriesCount
	In order to count the number of countries
	As a user with access to the RestCountries API
	I want to be told the number of countries in the API response

@smoke
Scenario Outline: Number of countries
	#Given I have access to the restcountries API
	When I generate a restful request <Countries>
	Then the api response returns <Countries>
	And I receive a successful response <Response>

Examples: 
| Countries | Response |
| 250       | 200      |
