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

public class InstrumentController : ControllerBase
{

    [HttpGet("Instruments")]
    public ActionResult<IEnumerable<Instrument>> GetInstrument() 
    {
       FinancialContext db = new FinancialContext();
        return Ok(db.Instruments.ToArray());

    }
}