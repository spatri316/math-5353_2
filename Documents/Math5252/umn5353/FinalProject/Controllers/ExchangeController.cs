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

public class ExchangeController : ControllerBase
{

    [HttpGet("Exchanges")]
    public ActionResult<IEnumerable<Exchange>> GetExchange() 
    {
        FinancialContext db = new FinancialContext();
        return Ok(db.Exchanges.ToArray());

    }

    [HttpPost]
    public ActionResult<Exchange> Post([FromBody] Exchange e) {
        FinancialContext db = new FinancialContext();
        if(db.Exchanges.Where(x => x.Name == e.Name).Count() <= 0) {
            db.Exchanges.Add(e);
            db.SaveChanges();
            return Created(new Uri("/Exchange", UriKind.Relative), e);
        }
        else {
            return BadRequest();
        }
    }


}