using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using system.collections.generic;
/// <summary>
/// Summary description for Class1
/// </summary>
 [Route("api/[controller]")]
[ApiController]
public class CompanyController
{
    
    public CompanyController()
	{
        [HttpGet]
        public IActionResult Get()
        {
            Dictionary<string, (double latitude, double longitude)> companies = new Dictionary<string, (double, double)>();

            // Unternehmen hinzufügen
            companies.Add("Google", (37.4220, -122.0841));
            companies.Add("Apple", (37.3349, -122.0090));
            companies.Add("Microsoft", (47.6405, -122.1298));
            companies.Add("Amazon", (47.6062, -122.3321));
            companies.Add("Facebook", (37.4845, -122.1484));
            companies.Add("Tesla", (37.3947, -122.1503));
            companies.Add("IBM", (41.1129, -73.7139));
            companies.Add("Samsung", (37.5665, 126.9780));
            companies.Add("Intel", (37.3876, -122.0575));
            companies.Add("Netflix", (37.2590, -121.9570));
            return Ok(companies);
        }
        
}
