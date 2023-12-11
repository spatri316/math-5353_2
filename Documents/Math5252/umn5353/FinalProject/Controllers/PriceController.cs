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

public class PriceController : ControllerBase
{

    [HttpGet("Prices")]
    public ActionResult<IEnumerable<Price>> GetPrice() 
    {
       FinancialContext db = new FinancialContext();
        return Ok(db.HistoricalPrices.ToArray());

    }

    [HttpGet("UniqueInstruments")]
    public ActionResult<IEnumerable<string>> GetUniqueInstruments()
    {
        FinancialContext db = new FinancialContext();
        var uniqueInstruments = db.Instruments.Select(m => m.Symbol).Distinct().ToList();
        return Ok(uniqueInstruments);
    }

    [HttpPost("Prices")]
    public ActionResult<Price> Post([FromBody] Price e) {
        FinancialContext db = new FinancialContext();

        var existingInstrument = db.Instruments.FirstOrDefault(u => u.Symbol == e.InstSymbolName);
        if (existingInstrument == null)
        {
            return BadRequest("Instrument with the provided name does not exist.");
        }
        e.InstSymbolId = existingInstrument.Id;
        e.Date = DateTime.SpecifyKind(e.Date, DateTimeKind.Utc);

        db.HistoricalPrices.Add(e);
        db.SaveChanges();

        return Created(new Uri("/Price", UriKind.Relative), e);
        
    }


}