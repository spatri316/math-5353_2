using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyApp;
namespace MyApp.Controllers;

[ApiController]
[Route("[controller]")]

public class UnderlyingController : ControllerBase
{

    [HttpGet("Underlyings")]
    public ActionResult<IEnumerable<Underlying>> GetUnderlying() 
    {
       FinancialContext db = new FinancialContext();
        return Ok(db.Underlyings.ToArray());

    }

    [HttpGet("UniqueMarkets")]
    public ActionResult<IEnumerable<string>> GetUniqueMarkets()
    {
        FinancialContext db = new FinancialContext();
        var uniqueMarkets = db.Markets.Select(m => m.Name).Distinct().ToList();
        return Ok(uniqueMarkets);
    }

    [HttpPost("Underlyings")]
    public ActionResult<Underlying> Post([FromBody] Underlying e) {
        FinancialContext db = new FinancialContext();

        var existingMarket = db.Markets.FirstOrDefault(u => u.Name == e.Market);
        if (existingMarket == null)
        {
            return BadRequest("Instrument with the provided name does not exist.");
        }
        e.MarketId = existingMarket.Id;
        e.Expiration = DateTime.SpecifyKind(e.Expiration, DateTimeKind.Utc);

        db.Underlyings.Add(e);
        db.SaveChanges();

        return Created(new Uri("/Underlying", UriKind.Relative), e);
        
    }


}