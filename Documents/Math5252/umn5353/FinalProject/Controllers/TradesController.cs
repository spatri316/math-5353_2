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

public class TradeController : ControllerBase
{

    [HttpGet("Trades")]
    public ActionResult<IEnumerable<Trade>> GetTrade() 
    {
       FinancialContext db = new FinancialContext();
        return Ok(db.Trades.ToArray());

    }

    [HttpGet("UniqueInstruments")]
    public ActionResult<IEnumerable<string>> GetUniqueInstruments()
    {
        FinancialContext db = new FinancialContext();
        var uniqueInstruments = db.Instruments.Select(m => m.Symbol).Distinct().ToList();
        return Ok(uniqueInstruments);
    }

    [HttpPost("Trades")]
    public ActionResult<Trade> Post([FromBody] Trade e) {
        FinancialContext db = new FinancialContext();

        var existingInstrument = db.Instruments.FirstOrDefault(u => u.Symbol == e.SymbolName);
        if (existingInstrument == null)
        {
            return BadRequest("Instrument with the provided name does not exist.");
        }
        e.SymbolId = existingInstrument.Id;
        e.Date = DateTime.SpecifyKind(e.Date, DateTimeKind.Utc);

        db.Trades.Add(e);
        db.SaveChanges();

        return Created(new Uri("/Trade", UriKind.Relative), e);
        
    }


}