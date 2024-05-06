using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using sale_webapi.BLL;
using sale_webapi.Models;
using server.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sale_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WinnerController : ControllerBase
    {

        private readonly IWinnerService _WinnerService;
        IMapper _mapper;
        public WinnerController(IWinnerService winnerservice, IMapper mapper)
        {
            this._WinnerService = winnerservice;
            this._mapper = mapper;

        }
        // GET: api/<WinnerController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<WinnerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<WinnerController>
        [HttpPost]
        [Route("RAFFELE")]
        public async Task<ObjectToRaffle> Raffele(string giftName)
        {
            
            return await _WinnerService.Raffle(giftName);
        }

        [HttpGet]
        [Route("ReportWinners")]
        public async Task<List<string>> Creating_a_report_winners()
        {

            return await _WinnerService.Creating_a_report_winners();

        }

        // PUT api/<WinnerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WinnerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
