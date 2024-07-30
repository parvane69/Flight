using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using System.Globalization;
using CsvHelper;
using Flight.Application.Subscriptions.Dto;
using Flight.Application.Routes.Dto;
using Flight.Application.Flights.Dto;
using MediatR;

namespace Flight.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FlightController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("upload/subscriptions")]
        public async Task<IActionResult> UploadCsv(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Please upload a valid CSV file.");

            using (var stream = new StreamReader(file.OpenReadStream()))
            using (var csv = new CsvReader(stream, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<SubscriptionInputDto>().ToList();
                var result = await _mediator.Send(new SubscriptionCommand
                {
                    Items = records,
                });
            }

            return Ok("File uploaded and data saved successfully.");
        }

        [HttpPost("upload/routes")]
        public async Task<IActionResult> UploadCsvRoutes(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Please upload a valid CSV file.");

            using (var stream = new StreamReader(file.OpenReadStream()))
            using (var csv = new CsvReader(stream, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<RouteInputDto>().ToList();
                var result = await _mediator.Send(new RouteCommand
                {
                    Items = records,
                });
            }

            return Ok("File uploaded and data saved successfully.");
        }


        [HttpGet("export")]
        public async Task<IActionResult> ExportFlights([FromQuery] DateTime startDate, [FromQuery] DateTime endDate, [FromQuery] int agencyId)
        {
            var query = new GetFlightsQuery
            {
                StartDate = startDate,
                EndDate = endDate,
                AgencyId = agencyId
            };

            var flights = await _mediator.Send(query);


            using (var memoryStream = new MemoryStream())
            {
                using (var streamWriter = new StreamWriter(memoryStream))
                using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteRecords(flights);
                    streamWriter.Flush();
                    memoryStream.Position = 0;

                    return File(memoryStream.ToArray(), "text/csv", "flights.csv");
                }
            }
        }
    }
}
