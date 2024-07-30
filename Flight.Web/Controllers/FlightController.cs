using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flight.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        [HttpPost("addFlights")]
        public async void Create()
        {
            //return await _mediatoR.Send(command);
        }
        [HttpPost("flights")]
        public async void Get()
        {
            //return await _mediatoR.Send(command);
        }
    }
}
