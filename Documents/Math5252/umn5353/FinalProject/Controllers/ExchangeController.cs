using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace portfolio_api.Controllers;

[ApiController]
[Route("[controller]")]

public class ExchangeController : ControllerBase
{

    [HttpGet]
    public ActionResult<IEnnumerable<Exchange>> Get() 
    {
        FinancialContext db = new FinancialContext();
        return Ok(db.Exchange.ToArray();)

    }

    [HttpPost]
    public ActionResult<Exchange> Post([FromBody] Exchange e) {
        FinanceContext db = new FinanceContext();
        if(db.Exchanges.Where(x => x.Name == e.Name).Count() <= 0) {
            db.Exchanges.Add(e);
            db.SaveChanges();
            return Created(new Uri("/Exchange", UriKind.Relative), u);
        }
        else {
            return BadRequest();
        }
    }


}



