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
        var uniqueUnits = db.Markets.Select(m => m.Unit).Distinct().ToList();
        return Ok(uniqueUnits);
    }


    [HttpGet("UniqueExchanges")]
    public ActionResult<IEnumerable<string>> GetUniqueExchanges()
    {
        FinancialContext db = new FinancialContext();
        var uniqueExchange = db.Markets.Select(m => m.Exchange).Distinct().ToList();
        return Ok(uniqueExchange);
    }

    [HttpGet("UniqueRateCurves")]
    public ActionResult<IEnumerable<string>> GetRateCurveExchanges()
    {
        FinancialContext db = new FinancialContext();
        var uniqueExchange = db.Markets.Select(m => m.Curve).Distinct().ToList();
        return Ok(uniqueExchange);
    }

    [HttpPost("Markets")]
    public ActionResult<Market> Post([FromBody] Market e) {
        FinancialContext db = new FinancialContext();
        if(db.Markets.Where(x => x.Name == e.Name).Count() <= 0) {
            db.Markets.Add(e);
            db.SaveChanges();
            return Created(new Uri("/Market", UriKind.Relative), e);
        }
        else {
            return BadRequest();
        }
    }


}