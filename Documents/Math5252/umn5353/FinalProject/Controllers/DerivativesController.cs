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

public class DerivativesController : ControllerBase
{

    [HttpGet("Derivatives")]
    public ActionResult<IEnumerable<Derivative>> GetDerivate() 
    {
       FinancialContext db = new FinancialContext();
        return Ok(db.Derivatives.ToArray());

    }

    [HttpGet("UniqueMarkets")]
    public ActionResult<IEnumerable<string>> GetUniqueMarkets()
    {
        FinancialContext db = new FinancialContext();
        var uniqueMarkets = db.Markets.Select(m => m.Name).Distinct().ToList();
        return Ok(uniqueMarkets);
    }

    [HttpGet("UniqueUnderlyings")]
    public ActionResult<IEnumerable<string>> GetUniqueUnderlyings()
    {
        FinancialContext db = new FinancialContext();
        var uniqueUnderlying = db.Underlyings.Select(m => m.Symbol).Distinct().ToList();
        return Ok(uniqueUnderlying);
    }

    [HttpPost("Derivatives")]
    public ActionResult<Derivative> Post([FromBody] Derivative e) {
        FinancialContext db = new FinancialContext();

        var existingMarkets = db.Markets.FirstOrDefault(u => u.Name == e.Market);
        if (existingMarkets == null)
        {
            return BadRequest("Market with the provided name does not exist.");
        }
        e.MarketId = existingMarkets.Id;

        var existingUnderlying = db.Underlyings.FirstOrDefault(u => u.Symbol == e.Underlying);
        if (existingUnderlying == null)
        {
            return BadRequest("Underlying with the provided name does not exist.");
        }
        e.UnderlyingId = existingUnderlying.Id;

        e.Expiration = DateTime.SpecifyKind(e.Expiration, DateTimeKind.Utc);

        db.Derivatives.Add(e);
        db.SaveChanges();

        return Created(new Uri("/Derivate", UriKind.Relative), e);
        
    }


}