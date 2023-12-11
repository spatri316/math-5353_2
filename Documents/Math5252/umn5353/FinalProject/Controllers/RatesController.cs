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

public class RateController : ControllerBase
{

    [HttpGet("Rates")]
    public ActionResult<IEnumerable<Rate>> GetRate() 
    {
       FinancialContext db = new FinancialContext();
        return Ok(db.Rates.ToArray());

    }

    [HttpGet("UniqueCurves")]
    public ActionResult<IEnumerable<string>> GetUniqueCurves()
    {
        FinancialContext db = new FinancialContext();
        var uniqueCurves= db.Curves.Select(m => m.Name).Distinct().ToList();
        return Ok(uniqueCurves);
    }

    [HttpPost("Rates")]
    public ActionResult<Rate> Post([FromBody] Rate e) {
        FinancialContext db = new FinancialContext();

        var existingCurve = db.Curves.FirstOrDefault(u => u.Name == e.CurveName);
        if (existingCurve == null)
        {
            return BadRequest("Curve with the provided name does not exist.");
        }
        e.RateCurveId = existingCurve.Id;

        db.Rates.Add(e);
        db.SaveChanges();

        return Created(new Uri("/Rate", UriKind.Relative), e);
        
    }


}