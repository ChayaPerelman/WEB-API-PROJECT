using Microsoft.AspNetCore.Mvc;
using sale_webapi.BLL;
using server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors.Infrastructure;
using AutoMapper;
using System.Drawing;
using sale_webapi.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sale_webapi.Controllers
{
    //[Authorize(Roles = "manager")]

    [Route("api/[controller]")]
    [ApiController]
    
    public class GiftController : ControllerBase
    {
        IMapper _mapper;
        private readonly IGiftService _giftservice;
        public GiftController(IGiftService giftservice, IMapper mapper)
        {
            this._giftservice = giftservice;
            this._mapper = mapper;

        }
        // GET: api/<GiftController>
        [Authorize(Roles = "manager")]
        [HttpGet]
        [Route("GetAllGifts")]
        public async Task<ActionResult<List<Gift>>> GetAllGifts()         
	    {	        
		try
            {
                return Ok(await _giftservice.GetGifts());
            }
	    
	    catch (Exception ex)
	{

		throw ex;
	}
           
        }
        //[Authorize(Roles = "user")]
        [HttpGet]
        [Route("GetAllGifts2")]
        public async Task<ActionResult<List<Gift>>> GetAllGifts2()
        {
            try
            {
                return Ok(await _giftservice.GetGifts());
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }
        [Authorize(Roles = "manager")]
        // GET api/<GiftController>/5
        [HttpGet]
        [Route("GetTheDonorGift")]
        public async Task<DonorDTO> GetTheDonorGift(string name)
        {
            try
            {
                return await _giftservice.GetTheDonorGift(name);
            }

            catch (Exception ex)
            {

                throw ex;
            }

        }


        [Authorize(Roles = "manager")]
        // POST api/<GiftController>
        [HttpPost]
        [Route("AddGift")]
        public async Task<bool> AddGift(GiftDTO gift)
        {

            try
            {
                Gift _gift = _mapper.Map<Gift>(gift);
                await _giftservice.AddGift(_gift);
                return true;
            }

            catch (Exception ex)
            {

                throw ex;
            }


           
        }
        [Authorize(Roles = "manager")]
        // PUT api/<GiftController>/5
        [HttpPut]
        [Route("UpdateGift")]
        public async Task<Gift> UpdateGift(GiftDTO gift,int id)
        {


            try
            {
                return await _giftservice.UpdateGift(gift, id);

            }

            catch (Exception ex)
            {

                throw ex;
            }


        }
        [Authorize(Roles = "manager")]
        // DELETE api/<GiftController>/5
        [HttpDelete]
        [Route("DeleteGift")]
        public async Task<bool> DeleteGift(int id)
        {
            try
            {
                var y = await _giftservice.DeleteGift(id);
                return y;
            }

            catch (Exception ex)
            {

                throw ex;
            }

         
        }
        [Authorize(Roles = "manager")]
        [HttpGet]
        [Route("SearchGiftsByAll")]
        public async Task<List<Gift>> SearchGiftsByAll( string? name, string? donor, int? numOfPurcheses)
        {
            try
            {
                return await _giftservice.SearchGiftsByAll(name, donor, numOfPurcheses);

            }

            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
