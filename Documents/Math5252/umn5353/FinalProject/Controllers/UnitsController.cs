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

public class UnitsController : ControllerBase
{

    [HttpGet("Units")]
    public ActionResult<IEnumerable<Units>> GetExchange() 
    {
        FinancialContext db = new FinancialContext();
        return Ok(db.Units.ToArray());

    }

    [HttpPost("Units")]
    public ActionResult<Units> Post([FromBody] Units e) {
        FinancialContext db = new FinancialContext();
        if(db.Units.Where(x => x.Name == e.Name).Count() <= 0) {
            db.Units.Add(e);
            db.SaveChanges();
            return Created(new Uri("/Unit", UriKind.Relative), e);
        }
        else {
            return BadRequest();
        }
    }


}