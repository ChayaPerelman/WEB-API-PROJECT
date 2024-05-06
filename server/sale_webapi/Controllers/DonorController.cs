using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

//For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
using server.Models;
using sale_webapi.BLL;
using System.Drawing;
using AutoMapper;
using sale_webapi.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Eco.UmlCodeAttributes;

namespace sale_webapi.Controllers
{
    //[Authorize(Roles = "manager")]

    [Route("api/[controller]")]
    [ApiController]

    [Authorize(Roles ="manager")]
    public class DonorController : ControllerBase
    {
        private readonly IDonorservice _donorservice;
        IMapper _mapper;
        public DonorController(IDonorservice donorservice, IMapper mapper)
        {
            this._donorservice = donorservice;
            this._mapper = mapper;

        }

        // GET: api/<DonorController>
        [HttpGet]
        [Route("GetAllDonors")]
        public async Task<ActionResult<List<Donor>>> GetAllDonors()
        {
            try
            {
                return Ok(await _donorservice.GetDonors());
            }

            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET api/<DonorController>/5
        [HttpGet]
        [Route("GetGiftsByDonorId")]
        public async Task<List<Gift>> GetGiftsByDonorId(int id)
        {
            try
            {
                return await _donorservice.GetGiftsByDonorId(id);
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }

        // POST api/<DonorController>
        [HttpPost]
        [Route("AddDonor")]
        public async Task<bool> AddDonor(DonorDTO donor)
        {
            try
            {

                Donor _donor = _mapper.Map<Donor>(donor);
                await _donorservice.AddDonor(_donor);
                return true;
            }

            catch (Exception ex)
            {

                throw ex;
            }

        }

        // PUT api/<DonorController>/5
        [HttpPut]
        [Route("UpdateDonor")]
        public async Task<Donor> UpdateDonor(DonorDTO donordto, int id)
        {
            try
            {

                return await _donorservice.UpdateDonor(donordto, id);

            }

            catch (Exception ex)
            {

                throw ex;
            }

        }

        // DELETE api/<DonorController>/5
        // [Authorize(Roles = "Saller")]

        [HttpDelete]
        [Route("DeleteDonor")]
        public async Task<bool> DeleteDonor(int id)
        {
            try
            {
                var middlewareUser = HttpContext.User;
                if (middlewareUser == null)
                {
                    return false;
                }


                return await _donorservice.DeleteDonor(id);
            }

            catch (Exception ex)
            {

                throw ex;
            }




        
        }

        [HttpGet]
        [Route("SearchDonorsByAll")]
        public async Task<List<Donor>> SearchDonorsByAll(string? fName, string? lName, string? email, string? giftName, string? phoneNumber)
        {

            try
            {
                return await _donorservice.SearchDonorsByAll(fName, lName, email, giftName, phoneNumber);

            }

            catch (Exception ex)
            {

                throw ex;
            }
        }
    } }


