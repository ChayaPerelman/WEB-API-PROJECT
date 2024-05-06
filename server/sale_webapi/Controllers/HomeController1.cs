using Microsoft.AspNetCore.Mvc;
using sale_webapi.BLL;
using sale_webapi.DAL;
using sale_webapi.Models;
using server.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sale_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController1 : ControllerBase
    {

        private readonly IHomeService _homeService;
        private readonly ITokenService _tokenService;

        public HomeController1(IHomeService homeservice, ITokenService tokenService)
        {
            this._homeService = homeservice;
            this._tokenService = tokenService;

        }



        [HttpPost]
        [Route("addToCart")]

        public async Task<bool> AddToCart(Gift gift)
        {

            try
            {

                Console.WriteLine("1");
                return await _homeService.AddToCart(gift);
                Console.WriteLine("2");
            }

            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpGet]
        [Route("GetAllGifts")]

        public async Task<List<Gift>> GetAllGifts()
        {

            try
            {
                return await _homeService.GetAllGifts();

            }

            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
