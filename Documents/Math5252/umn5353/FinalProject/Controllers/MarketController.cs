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

public class MarketController : ControllerBase
{

    [HttpGet("Markets")]
    public ActionResult<IEnumerable<Market>> GetMarket() 
    {
       FinancialContext db = new FinancialContext();
        return Ok(db.Markets.ToArray());

    }

    [HttpGet("UniqueUnits")]
    public ActionResult<IEnumerable<string>> GetUniqueUnits()
    {
        FinancialContext db = new FinancialContext();
        var uniqueUnits = db.Units.Select(m => m.Name).Distinct().ToList();
        return Ok(uniqueUnits);
    }


    [HttpGet("UniqueExchanges")]
    public ActionResult<IEnumerable<string>> GetUniqueExchanges()
    {
        FinancialContext db = new FinancialContext();
        var uniqueExchange = db.Exchanges.Select(m => m.ShortCode).Distinct().ToList();
        return Ok(uniqueExchange);
    }

    [HttpGet("UniqueRateCurves")]
    public ActionResult<IEnumerable<string>> GetRateCurveExchanges()
    {
        FinancialContext db = new FinancialContext();
        var uniqueExchange = db.Curves.Select(m => m.Name).Distinct().ToList();
        return Ok(uniqueExchange);
    }

    [HttpPost("Markets")]
    public ActionResult<Market> Post([FromBody] Market e) {
        FinancialContext db = new FinancialContext();

        var existingUnit = db.Units.FirstOrDefault(u => u.Name == e.Unit);
        if (existingUnit == null)
        {
            return BadRequest("Unit with the provided name does not exist.");
        }
        e.UnitId = existingUnit.Id;

        var existingExchange = db.Exchanges.FirstOrDefault(u => u.ShortCode == e.Exchange);
        if (existingExchange == null)
        {
            return BadRequest("Exchange with the provided name does not exist.");
        }
        e.ExchangeId = existingExchange.Id;

        var existingCurve = db.Curves.FirstOrDefault(u => u.Name == e.Curve);
        if (existingCurve == null)
        {
            return BadRequest("Curve with the provided name does not exist.");
        }
        e.RateCurveId = existingCurve.Id;

        db.Markets.Add(e);
        db.SaveChanges();

        return Created(new Uri("/Market", UriKind.Relative), e);
        
    }


}