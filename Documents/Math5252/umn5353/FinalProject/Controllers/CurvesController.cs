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

public class CurvesController : ControllerBase
{

    [HttpGet("Curves")]
    public ActionResult<IEnumerable<RateCurve>> GetCurves() 
    {
        FinancialContext db = new FinancialContext();
        return Ok(db.Curves.ToArray());

    }

    [HttpPost("Curves")]
    public ActionResult<RateCurve> Post([FromBody] RateCurve e) {
        FinancialContext db = new FinancialContext();
        if(db.Curves.Where(x => x.Name == e.Name).Count() <= 0) {
            db.Curves.Add(e);
            db.SaveChanges();
            return Created(new Uri("/Curve", UriKind.Relative), e);
        }
        else {
            return BadRequest();
        }
    }


}