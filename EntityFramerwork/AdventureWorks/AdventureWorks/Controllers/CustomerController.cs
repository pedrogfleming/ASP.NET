using AdventureWorks.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Web.Http;

namespace AdventureWorks.Controllers
{
    
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
       private readonly AdventureContext adventureContext;

        public CustomerController(AdventureContext adventureContext)
        {
            this.adventureContext = adventureContext;
        }

        //[HttpGet(Name = "GetAllClients")]
        //[Microsoft.AspNetCore.Mvc.HttpGet]
        //public async Task<IActionResult> GetClients()
        //{
        //    return Ok(adventureContext.Customers.ToList());
        //}

        //[HttpGet(Name = "GetClientsPage/{Page:int}")]
        //[Microsoft.AspNetCore.Mvc.HttpGet("{Page:int}")]
        [Microsoft.AspNetCore.Mvc.HttpGet]
        //public async Task<IActionResult> GetClientsPage([FromUri] QueryParams Page=null)
        public async Task<IActionResult> GetClientsPage(
            [FromQuery] int Page, 
            [FromQuery] string? firstName="", 
            [FromQuery] string? lastName="",
            [FromQuery] string? Phone="")
        {
            //GetClientsPage([FromQuery] int? Page=null, [FromQuery]string firstName, [FromQuery] string lastName)
            return Ok(adventureContext.Customers
                .Where(c => c.FirstName == firstName && c.LastName == lastName && c.Phone == Phone)
                .Skip(Page * 10 - 10)
                .Take(10)
                .ToList());

            //return Ok(adventureContext.Customers.Skip(Page*10-10).Take(10).ToList());
        }
    }
    public class QueryParams
    {
        public string Page { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
    }
}
